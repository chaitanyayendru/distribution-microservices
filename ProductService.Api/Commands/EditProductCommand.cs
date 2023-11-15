using System;
using MediatR;

namespace ProductService.Api.Commands
{
    public class EditProductCommand : IRequest<EditProductResult>
    {
        public Guid ProductId { get; set; }

        public int Status { get; set; }
    }
}