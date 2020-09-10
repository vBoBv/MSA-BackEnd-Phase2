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
  public class Create
  {
    public class Command : IRequest
    {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public string Possession { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private DataContext _context;

      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var item = new Item
        {
          Id = request.Id,
          Name = request.Name,
          Description = request.Description,
          Possession = request.Possession
        };

        _context.Items.Add(item);
        var success = await _context.SaveChangesAsync() > 0;

        if (success)
        {
          return Unit.Value;
        }
        else
        {
          throw new Exception("An error occured during saving");
        }

      }
    }
  }
}
