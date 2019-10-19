using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bikeshop.Models;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bikeshop.ViewModels
{
    public class DetailPageModel
    {
        public DetailPageModel()
        {
            Product = new Product();
            ShoppingItem = new ShoppingItem();
            Quantities = new List<SelectListItem>
            {
                new SelectListItem("1", "1"),
                new SelectListItem("2", "2"),
                new SelectListItem("3", "3"),
                new SelectListItem("4", "4"),
                new SelectListItem("5", "5")
            };
        }
        public Product Product { get; set; }
        public ShoppingItem ShoppingItem { get; set; }

        public IEnumerable<SelectListItem> Quantities {get;}
    }
}
