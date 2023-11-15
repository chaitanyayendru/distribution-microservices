using MediatR;
using ProductService.Api.Commands.Dtos;

namespace ProductService.Api.Commands
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public ProductAdditionDto Product { get; set; }
    }
}