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
    public class PostReplyList
    {
        public class Query: IRequest<List<PostReply>> {}

        public class PostReplytHandler: IRequestHandler<Query, List<PostReply>>
        {
            private readonly DataContext _context;
            
            public PostReplytHandler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<PostReply>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.PostReplies.ToListAsync();
            }
        }
    }
}