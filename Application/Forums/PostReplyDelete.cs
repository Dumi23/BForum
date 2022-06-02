using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Forums
{
    public class PostReplyDelete
    {
        public class Command: IRequest
        {
            public int Id { get; set; }
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
                var postReply = await _context.Forums.FindAsync(request.Id);

                _context.Remove(postReply);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}