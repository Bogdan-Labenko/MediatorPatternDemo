using MediatorDemo.Models;
using MediatR;

namespace MediatorDemo.Commands
{
    public record DeleteProductByIdCommand(int id) : IRequest<Product>; 
}
