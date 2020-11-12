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
using Tickets.Api.Core;
using Tickets.Api.Core.Models.DTO;
using Tickets.Api.Core.Models.DTO.Ticket;
using Tickets.Api.Core.Models.DTO.TicketMember;
using Tickets.Api.Core.Services;
using Tickets.Api.Data.Entities;

namespace Tickets.Api.Api.Controllers
{

    [ApiController]
    [Authorize]
    public class TicketController : ApiController
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;

        }


        // SEARCH: api/Ticket/5
        [HttpGet, Route("Search")]
        [ProducesResponseType(typeof(SearchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Search([FromQuery] SearchModel model)
        {
            if (ModelState.IsValid)
            {
                InitUserCredentials();
                var results = _mapper.Map( _ticketService.Search(model, CompanyGuid), new List<TicketResponseModel>());
                var response = new SearchResponse() { Data = results };
                return Ok(response);
            }

            return new NoContentResult();
        }

        // GET: api/Ticket/5
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(TicketResponseModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public  async Task<IActionResult> Get(Guid guid)
        {
            if (ModelState.IsValid)
            {

                Ticket ticket = await _ticketService.Get(guid);

                if (ticket == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (ticket.CompanyGuid != CompanyGuid)
                    return Unauthorized();

                return Ok(_mapper.Map(ticket, new TicketResponseModel()));

            }

            return new NoContentResult();
        }

        // POST: api/Ticket
        [HttpPost]
        [ProducesResponseType(typeof(TicketResponseModel), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] TicketRequestModel model)
        {
            Ticket newRecord = null;

            if (ModelState.IsValid)
            {
                InitUserCredentials();

                newRecord = new Ticket
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
                    await _ticketService.Save(newRecord);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return CreatedAtAction(nameof(Post), _mapper.Map(newRecord, new TicketResponseModel()));
        }

        // PUT: api/Ticket/5
        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody] TicketRequestModel model, Guid guid)
        {

            if (ModelState.IsValid)
            {
                if(guid == Guid.Empty)
                    return new BadRequestResult();

                Ticket record = await _ticketService.Get(guid);

                if(record == null)
                    return new NoContentResult();

                InitUserCredentials();

                //if (record.UserGuid != UserGuid)
                //{
                //    return new UnauthorizedResult();
                //}

                var mapped = _mapper.Map(model, record);
                mapped.LastUpdateTime = DateTime.Now;
                mapped.LastUpdateUserGuid = UserGuid;

                try
                {
                    await _ticketService.Save(mapped);
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

                Ticket record = await _ticketService.Get(guid);

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
                    await _ticketService.Save(record);
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
