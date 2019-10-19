using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Bikeshop.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _bikeDbContext;

        public ProductRepository(AppDbContext bikeDbContext)
        {
            _bikeDbContext = bikeDbContext;
        }

        public IEnumerable<Product> GetAllBikes()
        {
            return _bikeDbContext.Products;
        }

        public Product GetBikeById(int bikeId)
        {
            return _bikeDbContext.Products.FirstOrDefault(b => b.Id == bikeId);
        }
    }
}
