using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Email.Core.Models;
using SendGrid.Helpers.Mail;

namespace Email.Core.Mappings
{
    public class SendGridMappings : Profile
    {
        public SendGridMappings()
        {
            //CreateMap<SendEmailRequestDto, SendGridRequest>();
            //CreateMap<EmailAddressDto, EmailAddress>();
        }
    }
}
