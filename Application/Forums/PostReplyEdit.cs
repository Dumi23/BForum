using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Forums
{
    public class PostReplyEdit
    {
        public class Command: IRequest
        {
            public PostReply PostReply { get; set; }
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
                var postReply = await _context.PostReplies.FindAsync(request.PostReply.Id);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}