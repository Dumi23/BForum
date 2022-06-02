using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using AutoMapper;

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
            private readonly IMapper _mapper;
            
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var forum = await _context.Forums.FindAsync(request.Forum.Id);

                _mapper.Map(request.Forum, forum);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}