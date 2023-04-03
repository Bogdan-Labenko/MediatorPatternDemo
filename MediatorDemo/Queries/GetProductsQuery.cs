using MediatorDemo.Models;
using MediatR;

namespace MediatorDemo.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;
}
