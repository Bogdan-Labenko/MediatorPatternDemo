using MediatorDemo.Commands;
using MediatorDemo.Database;
using MediatorDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MediatorDemo.Handlers.Products
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product?>
    {
        private readonly AppDbContext _context;
        public AddProductHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(request.product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return request.product;
        }
    }
}
