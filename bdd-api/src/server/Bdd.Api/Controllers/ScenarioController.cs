using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Bdd.Core;
using Bdd.Core.Models.DTO;
using Bdd.Core.Services;
using Bdd.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Bdd.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ScenarioController : ApiController
    {
        private readonly IScenarioService _scenarioService;
        private readonly IMapper _mapper;

        public ScenarioController(IScenarioService scenarioService, IMapper mapper)
        {
            _scenarioService = scenarioService;
            _mapper = mapper;
        }

         [HttpGet, Route("Search")]
        [ProducesResponseType(typeof(ScenarioSearchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Search([FromQuery] ScenarioSearchRequest model)
        {
            if (ModelState.IsValid)
            {
                InitUserCredentials();
                var results = _mapper.Map( _scenarioService.Search(model, CompanyGuid), new List<ScenarioResponse>());
                var response = new ScenarioSearchResponse() { Data = results };
                return Ok(response);
            }

            return new NoContentResult();
        }


        // GET: 
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(ScenarioResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public  async Task<IActionResult> Get(Guid guid)
        {
            if (ModelState.IsValid)
            {

                Scenario record = await _scenarioService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CompanyGuid != CompanyGuid)
                    return Unauthorized();

                return Ok(_mapper.Map(record, new ScenarioResponse()));

            }

            return new NoContentResult();
        }

        // POST: 
        [HttpPost]
        [ProducesResponseType(typeof(ScenarioResponse), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] ScenarioRequest model)
        {
            Scenario newRecord = null;

            if (ModelState.IsValid)
            {
                InitUserCredentials();

                newRecord = new Scenario
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
                    await _scenarioService.Save(newRecord);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return CreatedAtAction(nameof(Post), _mapper.Map(newRecord, new ScenarioResponse()));
        }

        // PUT: 
        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody] ScenarioRequest model, Guid guid)
        {

            if (ModelState.IsValid)
            {
                if(guid == Guid.Empty)
                    return new BadRequestResult();

                Scenario record = await _scenarioService.Get(guid);

                if(record == null)
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
                    await _scenarioService.Save(mapped);
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

                Scenario record = await _scenarioService.Get(guid);

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
                    await _scenarioService.Save(record);
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
