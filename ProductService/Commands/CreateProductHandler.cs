using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductService.Api.Commands;
using ProductService.Api.Commands.Dtos;
using ProductService.DataAccess;
using ProductService.Domain;

namespace ProductService.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _products;
        private readonly IUnitOfWork _uow;

        public CreateProductHandler(IProductRepository products, IUnitOfWork unitOfWork)
        {
            _products = products;
            _uow = unitOfWork;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var draft = Product.CreateProduct
            (
                request.Product.Code,
                request.Product.Name,
                request.Product.Image,
                request.Product.Description,
                request.Product.MaxRetailPrice,
                request.Product.Icon
            );

            await _products.Add(draft);
            if (await _uow.Commit())
                return new CreateProductResult
                {
                    ProductId = draft.Id
                };
            else
                return null;

        }
    }
}