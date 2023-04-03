using MediatorDemo.Models;
using MediatR;

namespace MediatorDemo.Commands
{
    public record AddProductCommand(Product product) : IRequest<Product>;
}
