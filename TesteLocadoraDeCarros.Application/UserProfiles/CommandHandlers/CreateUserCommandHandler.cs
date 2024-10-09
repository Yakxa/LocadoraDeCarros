using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Application.UserProfiles.Commands;
using TesteLocadoraDeCarros.Dal;
using TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate;

namespace TesteLocadoraDeCarros.Application.UserProfiles.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        private readonly DataContext _context;

        public CreateUserCommandHandler(DataContext context) {
            _context = context; 
        }

        // Toda lógica de Command vai ser implementada usando o context
        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), request.Nome, request.Documento);

            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            return userProfile;
        }
    }
}
