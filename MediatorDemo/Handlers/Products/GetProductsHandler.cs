using MediatorDemo.Database;
using MediatorDemo.Models;
using MediatorDemo.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorDemo.Handlers.Products
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly AppDbContext _context;
        public GetProductsHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
