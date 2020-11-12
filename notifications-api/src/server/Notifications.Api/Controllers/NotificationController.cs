using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notifications.Core;
using Notifications.Core.Models.DTO;
using Notifications.Core.Services;
using Notifications.Data.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Notifications.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class NotificationController : ApiController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }


        [HttpGet, Route("Search")]
        [ProducesResponseType(typeof(SearchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Search([FromQuery] SearchRequest model)
        {
            if (ModelState.IsValid)
            {
                InitUserCredentials();

                if (model.UserGuid == null) // get for the logged in user by default
                    model.UserGuid = UserGuid;

                var results = _mapper.Map( _notificationService.Search(model, CompanyGuid), new List<NotificationResponse>());
                var response = new SearchResponse() { Data = results };
                return Ok(response);
            }

            return new NoContentResult();
        }


        // GET: 
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(NotificationResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public  async Task<IActionResult> Get(Guid guid)
        {
            if (ModelState.IsValid)
            {

                var record = await _notificationService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CompanyGuid != CompanyGuid)
                    return Unauthorized();

                return Ok(_mapper.Map(record, new NotificationResponse()));

            }

            return new NoContentResult();
        }

        // POST: 
        [HttpPost]
        [ProducesResponseType(typeof(NotificationResponse), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] NotificationRequest model)
        {
            Notification newRecord = null;

            if (ModelState.IsValid)
            {
                InitUserCredentials();

                newRecord = new Notification
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
                    await _notificationService.Save(newRecord);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return CreatedAtAction(nameof(Post), _mapper.Map(newRecord, new NotificationResponse()));
        }

        // PUT: 
        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody] NotificationRequest model, Guid guid)
        {

            if (ModelState.IsValid)
            {
                if(guid == Guid.Empty)
                    return new BadRequestResult();

                var record = await _notificationService.Get(guid);

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
                mapped.Body = record.Body; // don't update this
                mapped.Title = record.Title; // don't update this

                try
                {
                    await _notificationService.Save(mapped);
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

                var record = await _notificationService.Get(guid);

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
                    await _notificationService.Save(record);
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
