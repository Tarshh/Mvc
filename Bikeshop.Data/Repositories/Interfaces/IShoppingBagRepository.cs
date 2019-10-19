using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bikeshop.Models.Repositories.Interfaces
{
    public interface IShoppingBagRepository
    {
        void AddItem(ShoppingBag shoppingBag);
        ShoppingBag GetShoppingBag(string customerId);
        void UpdateItem(ShoppingBag shoppingBag);


    }
}
