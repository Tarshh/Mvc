using System;
using Bikeshop.Models.Repositories.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bikeshop.Models.Repositories
{
    public class ShoppingBagRepository : IShoppingBagRepository
    {
        private readonly AppDbContext _bikeDbContext;

        public ShoppingBagRepository(AppDbContext bikeDbContext)
        {
            _bikeDbContext = bikeDbContext;
        }

        public void AddItem(ShoppingBag shoppingBag)
        {
            _bikeDbContext.ShoppingBags.Add(shoppingBag);
            _bikeDbContext.SaveChanges();
        }

        public ShoppingBag GetShoppingBag(string customerId)
        {
            var userShoppingBag = _bikeDbContext.ShoppingBags.Include(s => s.Items).ThenInclude(i => i.Product).FirstOrDefault(s => s.Customer.Id == customerId);
            if (userShoppingBag == null)
            {
                userShoppingBag = new ShoppingBag
                {
                    UserId = customerId,
                    Date = DateTime.Now,
                };
                _bikeDbContext.ShoppingBags.Add(userShoppingBag);
                _bikeDbContext.SaveChanges();
                return userShoppingBag;
            }

            return userShoppingBag;
        }

        public void UpdateItem(ShoppingBag shoppingBag)
        {
            _bikeDbContext.ShoppingBags.Update(shoppingBag);
            _bikeDbContext.SaveChanges();

        }
    }
}
