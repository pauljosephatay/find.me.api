using AutoMapper;
using Find.Me.Api.Repository.Entities;
using Find.Me.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Find.Me.Api.Repository.Mapping
{
    public class UserEntityToDomainProfile : Profile
    {

        public UserEntityToDomainProfile()
        {
            CreateMap<UserEntity, User>().ConstructUsing(ConstructUser);
            CreateMap<AddressValueObject, Address>().ConstructUsing(ConstructAddress);
        }        

        private static User ConstructUser(UserEntity user, ResolutionContext context)
        {
            var addressVO = user.Address;
            var address = context.Mapper.Map<Address>(addressVO);
            return new User( user.Id, user.Name, address);
        }

        private static Address ConstructAddress(AddressValueObject addressVO, ResolutionContext context)
        {
            return new Address(
                addressVO.Lat,
                addressVO.Lng,
                addressVO.Name,
                addressVO.WithPets,
                addressVO.PetPhoto
                );
        }
    }
}
