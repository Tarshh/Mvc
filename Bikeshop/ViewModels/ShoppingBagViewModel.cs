using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bikeshop.Models;

namespace Bikeshop.ViewModels
{
    public class ShoppingBagViewModel
    {
        public List<ShoppingItem> ShoppingItems { get; set; }
        public decimal Price { get; set; }
    }
}
