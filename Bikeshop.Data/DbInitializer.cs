using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Bikeshop.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                context.AddRange(
                    new Product { Name = "Cube Racebike", Price = 3999, Image = "../images/CubeRace.jpg" },
                    new Product {  Name = "Marin Mountainbike", Price = 4850, Image = "../images/MarinMtb.jpg" },
                    new Product {  Name = "GT Mountainbike", Price = 3820, Image = "../images/gtMtb.jpg" },
                    new Product {  Name = "Orbea Racebike", Price = 3200, Image = "../images/OrbeaRace.jpg" },
                    new Product { Name = "Rondo Racebike", Price = 3820, Image = "../images/rondoRace.jpg" },
                    new Product { Name = "Kona Mountainbike", Price = 2590, Image = "../images/KonaMtb.jpg" }
                    );

                context.SaveChanges();
            }
        }
    }
}
