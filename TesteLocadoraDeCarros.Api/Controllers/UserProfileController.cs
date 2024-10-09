using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteLocadoraDeCarros.Api.Contracts.UserProfile.Requests;
using TesteLocadoraDeCarros.Api.Contracts.UserProfile.Responses;
using TesteLocadoraDeCarros.Application.UserProfiles.Commands;
using TesteLocadoraDeCarros.Application.UserProfiles.Queries;

namespace TesteLocadoraDeCarros.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserProfileController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var query = new GetAllUserProfiles();
            var response = await _mediator.Send(query);
            var profiles = _mapper.Map<List<UserProfileResponse>>(response);
            return Ok(profiles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreate profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = response.Id}, userProfile);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileById { UserProfileId = Guid.Parse(id)};
            var response = await _mediator.Send(query);
            var userProfile = _mapper.Map<UserProfileResponse>(response);
            return Ok(userProfile);
        }
    }
}
