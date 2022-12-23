using ProductService.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Domain
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
