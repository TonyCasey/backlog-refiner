using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestCases.Core.Models.DTO
{
    public class TestCaseRequest
    {

        [Required]
        public Guid? TicketGuid { get; set; }

        [Required]
        public Guid? BoardGuid { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Steps { get; set; }

        [Required]
        public string ExpectedResults { get; set; }
    }
}
