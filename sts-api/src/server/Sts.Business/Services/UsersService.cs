using System;
using AutoMapper;
using Sts.Business.Extensions;
using Sts.Core;
using Sts.Core.Identity;
using Sts.Core.Models;
using Sts.Core.Services;
using Sts.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Optional;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sts.Core.Models.DTO.TeamUser;
using Sts.Data.EntityFramework;

namespace Sts.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly ICompanyService _companyService;
        private readonly ApplicationDbContext _dbContext;
        private readonly ITeamService _teamService;
        private readonly ITeamUserService _teamUserService;

        protected UserManager<User> UserManager { get; }
        protected IJwtFactory JwtFactory { get; }
        protected IMapper Mapper { get; }

        public UsersService(
            UserManager<User> userManager,
            IJwtFactory jwtFactory,
            IMapper mapper,
            ICompanyService companyService,
            ApplicationDbContext dbContext,
            ITeamService teamService,
            ITeamUserService teamUserService)
        {
            _companyService = companyService;
            _dbContext = dbContext;
            _teamService = teamService;
            _teamUserService = teamUserService;
            UserManager = userManager;
            JwtFactory = jwtFactory;
            Mapper = mapper;
        }

        public async Task<Option<JwtModel, Error>> Login(LoginUserModel model)
        {
            var loginResult = await (await UserManager.FindByEmailAsync(model.Email))
                .SomeNotNull()
                .FilterAsync(async user => await UserManager.CheckPasswordAsync(user, model.Password));



            return loginResult.Match(
                user =>
                {
                    Company company = _companyService.GetCompany(user.Email.Split('@')[1]);

                    return new JwtModel
                    {
                        TokenString = JwtFactory.GenerateEncodedToken(user.Id, user.Email, new List<Claim>
                        {
                            new Claim("CompanyGuid",   company.Guid.ToString()),
                            new Claim("CompanyName", company.Name),
                            new Claim("CompanyDomain", company.DomainName)
                        } )
                    }.Some<JwtModel, Error>();
                },
                () => Option.None<JwtModel, Error>(new Error("Invalid credentials.")));
        }

        public async Task<Option<UserModel, Error>> Register(RegisterUserModel model)
        {
            var user = Mapper.Map<User>(model);

            var result = await UserManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                var company = _companyService.GetCompany(model.Email.Split('@')[1], model.CompanyName);

                if (company == null)
                {
                    company = _companyService.AddUpdateCompany(new Company
                    {
                        CreationTime = DateTime.Now,
                        CreationUserGuid = new Guid(user.Id),
                        DomainName = model.Email.Split('@')[1],
                        Name = model.CompanyName
                    });

                    Team team = await _teamService.Save(new Team
                    {
                        Guid = Guid.NewGuid(),
                        CreationTime = DateTime.Now,
                        CreationUserGuid = new Guid(user.Id),
                        CompanyGuid = company.Guid,
                        OwnerGuid = new Guid(user.Id),
                        Name = "Default team"

                    });

                    TeamUser teamUser = await _teamUserService.Save(new TeamUser
                    {
                        Guid = Guid.NewGuid(),
                        CreationTime = DateTime.Now,
                        CreationUserGuid = new Guid(user.Id),
                        CompanyGuid = company.Guid,
                        UserGuid = new Guid(user.Id),
                        TeamGuid = team.Guid
                    });
                }

                user.CompanyGuid = company.Guid;
                user.RegistrationDate = DateTime.Now;


                await UserManager.UpdateAsync(user);
            }


            var creationResult = result
                .SomeWhen(
                    x => x.Succeeded,
                    x => x.Errors.Select(e => e.Description).ToArray());

            return creationResult.Match(
                some: _ => Mapper.Map<UserModel>(user).Some<UserModel, Error>(),
                none: errors => Option.None<UserModel, Error>(new Error(errors)));
        }

        public async Task<User> Get(Guid guid)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == guid.ToString());
        }

    }
}
