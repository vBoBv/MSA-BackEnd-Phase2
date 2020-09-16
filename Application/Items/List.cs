using MediatR;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Application.Items
{
    public class List
    {
        public class Query : IRequest<List<ItemDto>> { }

        public class Handler : IRequestHandler<Query, List<ItemDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ItemDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                //var items = await _context.Items
                //            .Include(x => x.Bids)
                //            .ThenInclude(x => x.AppUser)
                //            .ToListAsync();

                var items = await _context.Items
                            .ToListAsync();

                var itemsToReturn = _mapper.Map<List<Item>, List<ItemDto>>(items);

                return itemsToReturn;
            }
        }
    }
}