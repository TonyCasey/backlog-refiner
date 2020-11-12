using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sts.Core.Models;
using Sts.Data.Entities;

namespace Sts.Core.Mappings
{
    public class CompanyMapping : Profile
    {
        public CompanyMapping()
        {
            CreateMap<Company, CompanyModel>().ReverseMap();
        }
    }
}
