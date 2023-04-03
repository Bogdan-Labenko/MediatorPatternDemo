using MediatorDemo.Models;
using MediatR;

namespace MediatorDemo.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<Product>;
}
