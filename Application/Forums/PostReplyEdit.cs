using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;    
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var postReply = await _context.PostReplies.FindAsync(request.PostReply.Id);

                _mapper.Map(request.PostReply, postReply);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}