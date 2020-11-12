using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Email.Data;

namespace Email.Core.Models.DTO
{
    public class EmailRequest
    {
        [Required]
        public Guid? ToUserGuid { get; set; }

        [Required]
        public Guid? BoardGuid { get; set; }

        [Required]
        public Guid? TicketGuid { get; set; }


        public Guid? NotificationGuid { get; set; }

        [Required]
        public Enumerations.SendGridTemplateEnum? SendGridTemplate { get; set; }


    }
}
