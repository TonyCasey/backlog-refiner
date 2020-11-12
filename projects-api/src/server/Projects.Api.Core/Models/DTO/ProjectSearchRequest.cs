using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Api.Core.Models.DTO
{
    public class ProjectSearchRequest
    {
        public Guid? TeamGuid { get; set; }

        public Guid? CompanyGuid { get; set; }

        public Guid? UserGuid { get; set; }

        public Guid? ProjectGuid { get; set; }
    }
}
