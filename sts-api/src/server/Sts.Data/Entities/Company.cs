using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sts.Data.Entities
{
    public class Company : BaseEntity
    {
        public long CompanyId { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string DomainName { get; set; }

    }
}
