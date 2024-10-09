using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate;

namespace TesteLocadoraDeCarros.Application.UserProfiles.Commands
{
    public class CreateUserCommand : IRequest<UserProfile>
    {
        public string Nome { get; private set; }
        public string Documento { get; private set; }
    }
}
