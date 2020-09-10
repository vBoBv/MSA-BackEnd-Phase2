using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Items
{
  public class Edit
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
        var item = await _context.Items.FindAsync(request.Id);

        if (item == null)
          throw new Exception("Item not found");

        item.Name = request.Name ?? item.Name;
        item.Description = request.Description ?? item.Description;
        item.Possession = request.Possession ?? item.Possession;

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
