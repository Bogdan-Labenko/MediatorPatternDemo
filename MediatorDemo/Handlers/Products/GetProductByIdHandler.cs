using MediatorDemo.Database;
using MediatorDemo.Models;
using MediatorDemo.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorDemo.Handlers.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product?>
    {
        private readonly AppDbContext _context;
        public GetProductByIdHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == request.id, cancellationToken);
        }
    }
}
