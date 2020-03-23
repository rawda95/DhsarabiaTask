using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DhsarabiaTask.API.Models;
using DhsarabiaTask.Data.Models;

namespace DhsarabiaTask.API.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<DTOEmployee, Employee>();
        }
    }
}
