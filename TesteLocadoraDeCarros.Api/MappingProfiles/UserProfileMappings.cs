using AutoMapper;
using TesteLocadoraDeCarros.Api.Contracts.UserProfile.Requests;
using TesteLocadoraDeCarros.Api.Contracts.UserProfile.Responses;
using TesteLocadoraDeCarros.Application.UserProfiles.Commands;
using TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate;

namespace TesteLocadoraDeCarros.Api.MappingProfiles
{
    public class UserProfileMappings : Profile
    {
        public UserProfileMappings()
        {
            CreateMap<UserProfileCreate, CreateUserCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
        }
    }
}
