using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projects.Api.Core;
using Projects.Api.Core.Models.DTO;
using Projects.Api.Core.Services;
using Projects.Api.Data.Entities;
using Serilog;

namespace Projects.Api.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }


        // SEARCH: api/Project/5
        [HttpGet, Route("Search")]
        [ProducesResponseType(typeof(ProjectSearchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Search([FromQuery] ProjectSearchRequest model)
        {
            if (ModelState.IsValid)
            {
                InitUserCredentials();
                var results = _mapper.Map(_projectService.Search(model, CompanyGuid), new List<ProjectResponse>());
                var response = new ProjectSearchResponse() { Data = results };
                return Ok(response);
            }

            return new NoContentResult();
        }

        // GET: api/Project/5
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(ProjectResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(Guid guid)
        {
            if (ModelState.IsValid)
            {

                var record = await _projectService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CompanyGuid != CompanyGuid)
                    return Unauthorized();

                return Ok(_mapper.Map(record, new ProjectResponse()));

            }

            return new NoContentResult();
        }

        // POST: api/Ticket
        [HttpPost]
        [ProducesResponseType(typeof(ProjectResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProjectRequest model)
        {
            Project newRecord = null;

            if (ModelState.IsValid)
            {
                InitUserCredentials();

                newRecord = new Project()
                {
                    Guid = Guid.NewGuid(),
                    UserGuid = UserGuid,
                    CompanyGuid = CompanyGuid,
                    CreationTime = DateTime.UtcNow,
                    CreationUserGuid = UserGuid
                };

                newRecord = _mapper.Map(model, newRecord);

                try
                {
                    await _projectService.Save(newRecord);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return CreatedAtAction(nameof(Post), _mapper.Map(newRecord, new ProjectResponse()));
        }

        // PUT: api/Project/5
        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody] ProjectRequest model, Guid guid)
        {

            if (ModelState.IsValid)
            {
                if (guid == Guid.Empty)
                    return new BadRequestResult();

                var record = await _projectService.Get(guid);

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
                    await _projectService.Save(mapped);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return new OkResult();
        }

        // DELETE: api/ApiWithActions/5
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

                var record = await _projectService.Get(guid);

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
                    await _projectService.Save(record);
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