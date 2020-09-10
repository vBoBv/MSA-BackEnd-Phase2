using MediatR;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Items
{
  public class List
  {
    public class Query : IRequest<List<Item>> { }

    public class Handler : IRequestHandler<Query, List<Item>>
    {
      private DataContext _context;

      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<List<Item>> Handle(Query request, CancellationToken cancellationToken)
      {
        var items = await _context.Items.ToListAsync();

        return items;
      }
    }
  }
}