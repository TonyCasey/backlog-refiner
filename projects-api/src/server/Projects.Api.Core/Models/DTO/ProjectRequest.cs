using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Api.Core.Models.DTO
{
    public class ProjectRequest
    {
        public Guid? UserGuid { get; set; }

        public Guid? TeamGuid { get; set; }

        public string Name { get; set; }
    }
}
