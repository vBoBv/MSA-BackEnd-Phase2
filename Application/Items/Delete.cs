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
  public class Delete
  {
    public class Command : IRequest
    {
      public Guid Id { get; set; }
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

        _context.Remove(item);

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
