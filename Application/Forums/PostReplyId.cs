using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Forums
{
    public class PostReplyId
    {
        public class Query: IRequest<PostReply> 
        {
            public int Id { get; set; }
        }

        public class Handler: IRequestHandler<Query, PostReply>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;  
            }

            public async Task<PostReply> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.PostReplies.FindAsync(request.Id);
            }
        }
    }
}