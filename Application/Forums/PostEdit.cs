using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Forums
{
    public class PostEdit
    {
        public class Command: IRequest
        {
            public Post Post { get; set; }
        }
    

        public class Handler: IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FindAsync(request.Post.Id);

                post.Title = request.Post.Title ?? post.Title;

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}