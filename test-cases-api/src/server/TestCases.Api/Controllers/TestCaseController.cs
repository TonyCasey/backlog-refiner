using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TestCases.Core;
using TestCases.Core.Models.DTO;
using TestCases.Core.Services;
using TestCases.Data.Entities;

namespace TestCases.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class TestCaseController : ApiController
    {
        private readonly ITestCaseService _testCaseService;
        private readonly IMapper _mapper;

        public TestCaseController(ITestCaseService testCaseService, IMapper mapper)
        {
            _testCaseService = testCaseService;
            _mapper = mapper;
        }

        [HttpGet, Route("Search")]
        [ProducesResponseType(typeof(TestCaseSearchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Search([FromQuery] TestCaseSearchRequest model)
        {
            if (ModelState.IsValid)
            {
                InitUserCredentials();
                var results = _mapper.Map( _testCaseService.Search(model, CompanyGuid), new List<TestCaseResponse>());
                var response = new TestCaseSearchResponse() { Data = results };
                return Ok(response);
            }

            return new NoContentResult();
        }


        // GET: 
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(TestCaseResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public  async Task<IActionResult> Get(Guid guid)
        {
            if (ModelState.IsValid)
            {

                var record = await _testCaseService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CompanyGuid != CompanyGuid)
                    return Unauthorized();

                return Ok(_mapper.Map(record, new TestCaseResponse()));

            }

            return new NoContentResult();
        }

        // POST: 
        [HttpPost]
        [ProducesResponseType(typeof(TestCaseResponse), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] TestCaseRequest model)
        {
            TestCase newRecord = null;

            if (ModelState.IsValid)
            {
                InitUserCredentials();

                newRecord = new TestCase
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
                    await _testCaseService.Save(newRecord);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return CreatedAtAction(nameof(Post), _mapper.Map(newRecord, new TestCaseResponse()));
        }

        // PUT: 
        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody] TestCaseRequest model, Guid guid)
        {

            if (ModelState.IsValid)
            {
                if(guid == Guid.Empty)
                    return new BadRequestResult();

                var record = await _testCaseService.Get(guid);

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
                    await _testCaseService.Save(mapped);
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

                var record = await _testCaseService.Get(guid);

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
                    await _testCaseService.Save(record);
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