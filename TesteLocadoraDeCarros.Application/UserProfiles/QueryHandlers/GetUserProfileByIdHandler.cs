using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLocadoraDeCarros.Application.UserProfiles.Queries;
using TesteLocadoraDeCarros.Dal;
using TesteLocadoraDeCarros.Domain.Aggregates.UserProfileAggregate;

namespace TesteLocadoraDeCarros.Application.UserProfiles.QueryHandlers
{
    public class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileById, UserProfile>
    {
        private readonly DataContext _context;
        public GetUserProfileByIdHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<UserProfile> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(up => up.Id == request.UserProfileId);
        }
    }
}
