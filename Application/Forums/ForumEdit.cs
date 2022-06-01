using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Forums
{
    public class ForumEdit
    {
        public class Command : IRequest
        {
            public Forum Forum { get; set; }
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
                var forum = await _context.Forums.FindAsync(request.Forum.Id);

                forum.Title = request.Forum.Title ?? forum.Title;

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}