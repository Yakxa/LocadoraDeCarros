using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Application.UserProfiles.Commands;
using TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate;

namespace TesteLocadoraDeCarros.Application.MappingProfiles
{
    public class UserProfileMap : Profile
    {
        public UserProfileMap() 
        {
            CreateMap<CreateUserCommand, UserProfile>();
        }
    }
}
