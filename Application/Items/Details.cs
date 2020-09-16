using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Items
{
    public class Details
    {
        public class Query : IRequest<ItemDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ItemDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ItemDto> Handle(Query request, CancellationToken cancellationToken)
            {
                //var item = await _context.Items
                //            .Include(x => x.Bids)
                //            .ThenInclude(x => x.AppUser)
                //            .SingleOrDefaultAsync(x => x.Id == request.Id);
                var item = await _context.Items
                            .FindAsync(request.Id);

                var itemToReturn = _mapper.Map<Item, ItemDto>(item);

                return itemToReturn;
            }
        }
    }
}
