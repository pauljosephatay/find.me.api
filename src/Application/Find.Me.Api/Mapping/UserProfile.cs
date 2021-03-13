using AutoMapper;
using Find.Me.Api.ViewModels;
using Find.Me.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Find.Me.Api.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserSummary>();
            CreateMap<Address, AddressVM>();
        }
    }
}
