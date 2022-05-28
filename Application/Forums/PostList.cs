using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Forums
{
    public class PostList
    {
        public class Query: IRequest<List<Post>> {}

        public class PostHandler : IRequestHandler<Query, List<Post>>
        {
  
        private readonly DataContext _context;

        public PostHandler(DataContext context)
        {
            _context = context;

        }

        public async Task<List<Post>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Posts.ToListAsync();
        }
        }
    }
}