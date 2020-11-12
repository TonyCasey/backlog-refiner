using System;
using System.Collections.Generic;
using System.Text;

namespace TestCases.Data.Entities
{
    public class TestCase : BaseEntity
    {
        public long TestCaseId { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid BoardGuid { get; set; }

        public Guid UserGuid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Steps { get; set; }

        public string ExpectedResults { get; set; }
    }
}
