using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Tickets.Api.Core;
using Tickets.Api.Core.Models.DTO.Ticket;
using Tickets.Api.Core.Models.DTO.TicketMember;
using Tickets.Api.Core.Services;
using Tickets.Api.Data.Entities;

namespace Tickets.Api.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class TicketMemberController : ApiController
    {
        private readonly ITicketMemberService _ticketMemberService;
        private readonly IMapper _mapper;

        public TicketMemberController(ITicketMemberService ticketMemberService, IMapper mapper)
        {
            _ticketMemberService = ticketMemberService;
            _mapper = mapper;
        }

        // SEARCH: api/TicketMember/5
        [HttpGet, Route("Search")]
        [ProducesResponseType(typeof(TicketMemberSearchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Search([FromQuery] TicketMemberSearchModel model)
        {
            if (ModelState.IsValid)
            {
                InitUserCredentials();
                var results = _mapper.Map(_ticketMemberService.Search(model, CompanyGuid), new List<TicketMemberResponse>());
                var response = new TicketMemberSearchResponse() { Data = results };
                return Ok(response);
            }

            return new NoContentResult();
        }

        // GET: api/TicketMember/5
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(TicketMemberResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(Guid guid)
        {
            if (ModelState.IsValid)
            {

                var record = await _ticketMemberService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CompanyGuid != CompanyGuid)
                    return Unauthorized();

                return Ok(_mapper.Map(record, new TicketMemberResponse()));

            }

            return new NoContentResult();
        }

        // POST: api/TicketMember
        [HttpPost]
        [ProducesResponseType(typeof(TicketMemberResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] TicketMemberRequest model)
        {
            TicketMember newRecord = null;

            if (ModelState.IsValid)
            {
                InitUserCredentials();

                var existing = _ticketMemberService.Search(new TicketMemberSearchModel
                {
                    TeamUserGuid = model.TeamUserGuid,
                    UserGuid = model.UserGuid,
                    TicketGuid = model.TicketGuid
                }, CompanyGuid);

                if (existing.Any())
                    return Ok(_mapper.Map(existing.FirstOrDefault(), new TicketMemberResponse()));

                newRecord = new TicketMember
                {
                    Guid = Guid.NewGuid(),
                    TicketGuid = (Guid)model.TicketGuid,
                    TeamUserGuid = (Guid)model.TeamUserGuid,
                    CompanyGuid = CompanyGuid,
                    UserGuid = (Guid)model.UserGuid,
                    CreationTime = DateTime.UtcNow,
                    CreationUserGuid = UserGuid
                };

                newRecord = _mapper.Map(model, newRecord);

                try
                {
                    await _ticketMemberService.Save(newRecord);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return CreatedAtAction(nameof(Post), _mapper.Map(newRecord, new TicketMemberResponse()));
        }

        // PUT: api/TicketMember/5
        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody] TicketMemberRequest model, Guid guid)
        {

            if (ModelState.IsValid)
            {
                if (guid == Guid.Empty)
                    return new BadRequestResult();

                var record = await _ticketMemberService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CreationUserGuid != UserGuid)
                {
                    return new UnauthorizedResult();
                }

                var mapped = _mapper.Map(model, record);
                mapped.LastUpdateTime = DateTime.Now;
                mapped.LastUpdateUserGuid = UserGuid;

                try
                {
                    await _ticketMemberService.Save(mapped);
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

                var record = await _ticketMemberService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CreationUserGuid != UserGuid)
                {
                    return new UnauthorizedResult();
                }

                record.Deleted = true;
                record.LastUpdateTime = DateTime.UtcNow;
                record.LastUpdateUserGuid = UserGuid;

                try
                {
                    await _ticketMemberService.Save(record);
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