using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Sts.Core;
using Sts.Core.Models;
using Sts.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sts.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet("current")]
        [Authorize]
        [ProducesResponseType(typeof(UserModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Current()
        {

            InitUserCredentials();

            var user = await _usersService.Get(UserGuid);

            if (user == null)
                return NotFound();


            return Ok(_mapper.Map(user, new UserModel()));
        }


        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="model">The credentials.</param>
        /// <returns>A JWT token.</returns>
        /// <response code="200">If the credentials have a match.</response>
        /// <response code="400">If the credentials don't match/don't meet the requirements.</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(JwtModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model) =>
            (await _usersService.Login(model))
            .Match(Ok, Error);

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="model">The user model.</param>
        /// <returns>A user model.</returns>
        /// <response code="201">A user was created.</response>
        /// <response code="400">Invalid input.</response>
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel model) =>
            (await _usersService.Register(model))
            .Match(u => CreatedAtAction(nameof(Register), u), Error);


        // GET: 
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(UserModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(Guid guid)
        {
            if (ModelState.IsValid)
            {

                var record = await _usersService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CompanyGuid != CompanyGuid)
                    return Unauthorized();

                return Ok(_mapper.Map(record, new UserModel()));

            }

            return new NoContentResult();
        }
    }
}