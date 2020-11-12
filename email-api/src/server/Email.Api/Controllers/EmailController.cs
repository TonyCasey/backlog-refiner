using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Email.Core;
using Email.Core.Models;
using Email.Core.Models.DTO;
using Email.Core.Models.SendGrid;
using Email.Core.Services;
using Email.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using Serilog;
using User = Email.Data.Entities.User;

namespace Email.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class EmailController : ApiController
    {
        private readonly IEmailService _emailService;
        private readonly ISendGridService _sendGridService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public EmailController(IEmailService emailService, ISendGridService sendGridService, IUserService userService, IMapper mapper)
        {
            _emailService = emailService;
            _sendGridService = sendGridService;
            _userService = userService;
            _mapper = mapper;
        }

        
        // SEARCH: api/Email/5
        [HttpGet, Route("Search")]
        [ProducesResponseType(typeof(EmailSearchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Search([FromQuery] EmailSearchRequest model)
        {
            if (ModelState.IsValid)
            {
                InitUserCredentials();
                var results = _mapper.Map( _emailService.Search(model, CompanyGuid), new List<EmailResponse>());
                var response = new EmailSearchResponse() { Data = results };
                return Ok(response);
            }

            return new NoContentResult();
        }

        // GET: api/Email/5
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(EmailResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public  async Task<IActionResult> Get(Guid guid)
        {
            if (ModelState.IsValid)
            {

                var record = await _emailService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CompanyGuid != CompanyGuid)
                    return Unauthorized();

                return Ok(_mapper.Map(record, new EmailResponse()));

            }

            return new NoContentResult();
        }

        // POST: api/Email
        [HttpPost]
        [ProducesResponseType(typeof(EmailResponse), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] EmailRequest model)
        {
            Data.Entities.Email newRecord = null;

            if (ModelState.IsValid)
            {
                InitUserCredentials();

                newRecord = new Data.Entities.Email
                {
                    Guid = Guid.NewGuid(),
                    CompanyGuid = CompanyGuid,
                    CreationTime = DateTime.UtcNow,
                    CreationUserGuid = UserGuid
                };

                newRecord = _mapper.Map(model, newRecord);

                try
                {
                    

                    User user = await _userService.Get((Guid)model.ToUserGuid);
                    
                    if (user != null)
                    {

                        var toEmailAddress = user.Email;

                        #if !RELEASE
                            toEmailAddress = "tcasey@backlogrefiner.com";
                        #endif

                        var response = await _sendGridService.SendEmail(new SendGridRequest
                        {
                            To = new []{new EmailAddress( toEmailAddress ) },
                            DynamicTemplateData = new SendGridDynamicData
                            {
                                TicketGuid = (Guid)model.TicketGuid
                            },
                            Template = (Enumerations.SendGridTemplateEnum)model.SendGridTemplate
                        });

                        if (response.StatusCode != HttpStatusCode.BadRequest)
                        {
                            var messageKvp = response.Headers.FirstOrDefault(x => x.Key == "X-Message-Id");

                            if (messageKvp.Value.Any())
                                newRecord.SendGridId = messageKvp.Value.FirstOrDefault();

                            await _emailService.Save(newRecord);
                        }

                    }

                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return CreatedAtAction(nameof(Post), _mapper.Map(newRecord, new EmailResponse()));
        }

        // PUT: api/Email/5
        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody] EmailRequest model, Guid guid)
        {

            if (ModelState.IsValid)
            {
                if(guid == Guid.Empty)
                    return new BadRequestResult();

                var record = await _emailService.Get(guid);

                if(record == null)
                    return new NoContentResult();

                InitUserCredentials();

                var mapped = _mapper.Map(model, record);
                mapped.LastUpdateTime = DateTime.Now;
                mapped.LastUpdateUserGuid = UserGuid;

                try
                {
                    await _emailService.Save(mapped);
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

                var record = await _emailService.Get(guid);

                if (record == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (record.CreationUserGuid != UserGuid)
                {
                    return new UnauthorizedResult();
                }

                record.Deleted = true;

                try
                {
                    await _emailService.Save(record);
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