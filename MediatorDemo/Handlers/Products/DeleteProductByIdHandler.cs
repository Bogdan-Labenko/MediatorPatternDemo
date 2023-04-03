using MediatorDemo.Commands;
using MediatorDemo.Database;
using MediatorDemo.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorDemo.Handlers.Products
{
    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdCommand, Product?>
    {
        private readonly AppDbContext _context;
        public DeleteProductByIdHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product?> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.id, cancellationToken);
            if (res == default)
            {
                return default;
            }
            else
            {
                _context.Products.Remove(res);
                await _context.SaveChangesAsync(cancellationToken);
                return res;
            }
        }
    }
}
