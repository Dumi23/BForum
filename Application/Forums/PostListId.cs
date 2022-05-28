using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Forums
{
    public class PostListId
    {
        public class Query: IRequest<Post> 
        {
            public int Id { get; set; }
        }

        public class Handler: IRequestHandler<Query, Post>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Post> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Posts.FindAsync(request.Id);
            }
        }
    }
}