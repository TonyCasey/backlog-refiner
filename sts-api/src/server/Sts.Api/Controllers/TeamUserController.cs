using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Sts.Core;
using Sts.Core.Models.DTO;
using Sts.Core.Models.DTO.TeamUser;
using Sts.Core.Services;
using Sts.Data.Entities;

namespace Sts.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class TeamUserController : ApiController
    {
        private readonly ITeamUserService _teamUserService;
        private readonly ITeamService _teamService;
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public TeamUserController(ITeamUserService teamUserService, ITeamService teamService, IUsersService usersService, IMapper mapper)
        {
            _teamUserService = teamUserService;
            _teamService = teamService;
            _usersService = usersService;
            _mapper = mapper;
        }


        [HttpGet, Route("Search")]
        [ProducesResponseType(typeof(TeamUserSearchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Search([FromQuery] TeamUserSearchRequest model)
        {
            if (ModelState.IsValid)
            {
                InitUserCredentials();
                var results = _mapper.Map(_teamUserService.Search(model, CompanyGuid), new List<TeamUserResponse>());

                foreach (TeamUserResponse teamUserResponse in results)
                {
                    var user = await _usersService.Get(teamUserResponse.UserGuid);
                    teamUserResponse.FirstName = user.FirstName;
                    teamUserResponse.LastName = user.LastName;
                    teamUserResponse.Avatar = user.Avatar;
                }

                var response = new TeamUserSearchResponse() { Data = results };
                return Ok(response);
            }

            return new NoContentResult();
        }


        // GET: 
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(TeamUserResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(Guid guid)
        {
            if (ModelState.IsValid)
            {

                TeamUser record = await _teamUserService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CompanyGuid != CompanyGuid)
                    return Unauthorized();

                return Ok(_mapper.Map(record, new TeamUserResponse()));

            }

            return new NoContentResult();
        }

        // POST: 
        [HttpPost]
        [ProducesResponseType(typeof(TeamUserResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] TeamUserRequest model)
        {
            TeamUser newRecord = null;

            if (ModelState.IsValid)
            {
                InitUserCredentials();

                // check for user
                var user = await _usersService.Get(model.UserGuid);

                if (user == null || user.CompanyGuid != CompanyGuid)
                    return BadRequest();

                var team = await _teamService.Get(model.TeamGuid);

                if (team == null || team.CompanyGuid != CompanyGuid)
                    return BadRequest();



                newRecord = new TeamUser
                {
                    Guid = Guid.NewGuid(),
                    CompanyGuid = CompanyGuid,
                    CreationTime = DateTime.UtcNow,
                    CreationUserGuid = UserGuid,
                    TeamGuid = team.Guid,
                    UserGuid = model.UserGuid,
                };

                newRecord = _mapper.Map(model, newRecord);

                try
                {
                    await _teamUserService.Save(newRecord);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return CreatedAtAction(nameof(Post), _mapper.Map(newRecord, new TeamUserResponse()));
        }

        // PUT: 
        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody] TeamUserRequest model, Guid guid)
        {

            if (ModelState.IsValid)
            {
                if (guid == Guid.Empty)
                    return new BadRequestResult();

                TeamUser record = await _teamUserService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.UserGuid != UserGuid)
                {
                    return new UnauthorizedResult();
                }

                var mapped = _mapper.Map(model, record);
                mapped.LastUpdateTime = DateTime.Now;
                mapped.LastUpdateUserGuid = UserGuid;

                try
                {
                    await _teamUserService.Save(mapped);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return new OkResult();
        }

        // DELETE: 
        [HttpDelete("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(Guid guid)
        {
            if (ModelState.IsValid)
            {
                if (guid == Guid.Empty)
                    return new BadRequestResult();

                TeamUser record = await _teamUserService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.UserGuid != UserGuid)
                {
                    return new UnauthorizedResult();
                }

                record.Deleted = true;

                try
                {
                    await _teamUserService.Save(record);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return new OkResult();
        }
    }
}
