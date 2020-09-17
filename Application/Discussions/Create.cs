using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Discussions
{
    public class Create
    {
        public class Command : IRequest<DiscussionDto>
        {
            public Guid ItemId { get; set; }
            public string UserName { get; set; }
            public string Comment { get; set; }
        }

        public class Handler : IRequestHandler<Command, DiscussionDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;


            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DiscussionDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var item = await _context.Items.FindAsync(request.ItemId);

                if(item == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Item = "Not Found" });
                }

                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == request.UserName);

                var discussion = new Discussion
                {
                    Comment = request.Comment,
                    CreateAt = DateTime.Now,
                    Author = user,
                    Item = item
                };

                item.Discussions.Add(discussion);

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                {
                    return _mapper.Map<DiscussionDto>(discussion);
                }
                else
                {
                    throw new Exception("An error occured during saving");
                }

            }
        }
    }
}
