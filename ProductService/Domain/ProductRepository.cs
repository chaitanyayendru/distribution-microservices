using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.DataAccess;
using ProductService.DataAccess.DataConfig;
using ProductService.DataAccess.MongoPersistence;

namespace ProductService.Domain
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoContext context) : base(context)
        {
        }
    }
}
