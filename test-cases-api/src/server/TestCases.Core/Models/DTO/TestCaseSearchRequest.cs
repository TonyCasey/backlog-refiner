using System;
using System.Collections.Generic;
using System.Text;

namespace TestCases.Core.Models.DTO
{
    public class TestCaseSearchRequest
    {
        public Guid? TicketGuid { get; set; }

        public Guid? BoardGuid { get; set; }
    }
}
