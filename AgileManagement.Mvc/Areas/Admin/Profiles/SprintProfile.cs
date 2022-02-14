using AgileManagement.Application;
using AgileManagement.Mvc.Areas.Admin.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileManagement.Mvc.Areas.Admin.Profiles
{
    public class SprintProfile:Profile
    {
        public SprintProfile()
        {
            CreateMap<SprintInputModel, AddSprintRequestDto>();
        }
    }
}
