using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Email.Core.Models;
using Email.Core.Models.SendGrid;
using Email.Core.Services;
using Email.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace Email.Business.Services
{
    public class SendGridService : ISendGridService
    {
        private readonly IOptions<SendGridConfigurationOptions> _options;
        ISendGridClient _client;
        JsonSerializerSettings _serializerSettings;


        public SendGridService(IOptions<SendGridConfigurationOptions> options)
        {
            _options = options;
            _client = new SendGridClient(options.Value.ApiKey);

            _serializerSettings = new JsonSerializerSettings();
            _serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public SendGridService(ISendGridClient sendGridClient)
        {
            _client = sendGridClient;
            _serializerSettings = new JsonSerializerSettings();
            _serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public async Task<Response> SendEmail(SendGridRequest sendGridRequest)
        {
            var msg = new SendGridMessage();

            msg.SetFrom(_options.Value.FromEmailAddress, _options.Value.FromAlias);

            msg.AddTos(sendGridRequest.To.ToList());

            if (sendGridRequest.Cc?.Length > 0)
                msg.AddCcs(sendGridRequest.Cc.ToList());

            if (sendGridRequest.Bcc?.Length > 0)
                msg.AddBccs(sendGridRequest.Bcc.ToList());

            if (_options.Value.ReplyToEmailAddress != null)
                msg.ReplyTo = new EmailAddress(_options.Value.ReplyToEmailAddress);

            sendGridRequest.DynamicTemplateData.BaseUrl = _options.Value.BaseUrl;

            var dynamicTemplateDataObject = sendGridRequest.DynamicTemplateData;
            
            msg.SetTemplateData(dynamicTemplateDataObject);

            switch (sendGridRequest.Template)
            {
                case Enumerations.SendGridTemplateEnum.AddedToTickAddedToTicketTemplate:
                    msg.SetTemplateId(_options.Value.AddedToTicketTemplate);
                    break;
                case Enumerations.SendGridTemplateEnum.TicketUpdatedTemplate:
                    msg.SetTemplateId(_options.Value.TicketUpdatedTemplate);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            try
            {
                return await _client.SendEmailAsync(msg);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
