using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Email.Core.Models;
using Email.Core.Models.SendGrid;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Email.Core.Services
{
    public interface ISendGridService
    {
        Task<Response> SendEmail(SendGridRequest request);
    }
}
