using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductService.Api.Commands;
using ProductService.DataAccess;
using ProductService.Domain;

namespace ProductService.Commands
{
    public class EditProductHandler : IRequestHandler<EditProductCommand, EditProductResult>
    {
        private readonly IProductRepository _products;
        private readonly IUnitOfWork _uow;

        public EditProductHandler(IProductRepository products, IUnitOfWork unitOfWork)
        {
            _products = products;
            _uow= unitOfWork;
        }

        public async Task<EditProductResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _products.GetById(request.ProductId);
            product.Edit(request.Status);

            if (await _uow.Commit())
                return new EditProductResult
                {
                    ProductId = product.Id
                };
            else
                return null;
        }
    }
}