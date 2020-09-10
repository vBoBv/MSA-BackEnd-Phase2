using Domain;
using MediatR;
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
    public class Query : IRequest<Item>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Item>
    {
      private DataContext _context;

      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Item> Handle(Query request, CancellationToken cancellationToken)
      {
        var item = await _context.Items.FindAsync(request.Id);

        return item;
      }
    }
  }
}
