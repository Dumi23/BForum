using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Forums
{
    public class List
    {
        public class Query: IRequest<List<Forum>>{}

        public class Handler : IRequestHandler<Query, List<Forum>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Forum>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Forums.ToListAsync();
            }

        }

        
    }
}