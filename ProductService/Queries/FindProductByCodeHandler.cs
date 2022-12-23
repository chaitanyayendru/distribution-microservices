using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductService.Api.Queries;
using ProductService.Api.Queries.Dtos;
using ProductService.Domain;

namespace ProductService.Queries
{
    public class FindProductByCodeHandler : IRequestHandler<FindProductByCodeQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public FindProductByCodeHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }       

        public async Task<ProductDto> Handle(FindProductByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetByCode(request.ProductCode);

            return result != null ? new ProductDto
            {
                Code = result.Code,
                Name = result.Name,
                Description = result.Description,
                Image = result.Image,
                MaxRetailPrice = result.MaxRetailPrice,
                Icon = result.ProductIcon
            } : null;
        }
    }
}
