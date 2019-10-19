using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Bikeshop.Models
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> bikes;

        public MockProductRepository()
        {
            if (bikes == null)
            {
                InitializeBikes();
            }
        }

        private void InitializeBikes()
        {
            bikes = new List<Product>
            {
                new Product {Id = 1, Name = "Cube Racebike", Price = 3999, Image = "../images/CubeRace.jpg"},
                new Product {Id = 2, Name = "Marin Mountainbike", Price = 4850, Image = "../images/MarinMtb.jpg"},
                new Product {Id = 3, Name = "GT Mountainbike", Price = 3820, Image = "../images/gtMtb.jpg"},
                new Product {Id = 4, Name = "Orbea Racebike", Price = 3200, Image = "../images/OrbeaRace.jpg"},
                new Product {Id = 2, Name = "Rondo Racebike", Price = 3820, Image = "../images/rondoRace.jpg"},
                new Product {Id = 6, Name = "Kona Mountainbike", Price = 2590, Image = "../images/KonaMtb.jpg"},
            };
        }

        public IEnumerable<Product> GetAllBikes()
        {
            return bikes;
        }

        public Product GetBikeById(int bikeId)
        {
            return bikes.FirstOrDefault(b => b.Id == bikeId);
        }
    }

}