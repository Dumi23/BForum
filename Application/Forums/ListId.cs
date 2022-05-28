using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Forums
{
    public class ListId
    {
        public class Query: IRequest<Forum>
        {
            public int Id {get; set;}
        }

        public class Handler: IRequestHandler<Query, Forum>
        {
        private readonly DataContext _context;

            public Handler (DataContext context)
            {
                _context = context;
            }

            public async Task<Forum> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Forums.FindAsync(request.Id);
            }
        }
    }
}