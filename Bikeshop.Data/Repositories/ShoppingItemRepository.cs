using System.Linq;
using Bikeshop.Models.Repositories.Interfaces;

namespace Bikeshop.Models.Repositories
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly AppDbContext _bikeDbContext;

        public ShoppingItemRepository(AppDbContext bikeDbContext)
        {
            _bikeDbContext = bikeDbContext;
        }

        public void AddItem(ShoppingItem shoppingItem)
        {
            _bikeDbContext.ShoppingItems.Add(shoppingItem);
            _bikeDbContext.SaveChanges();
        }

        public ShoppingItem GetItem(int productId, int bagId)
        {
            var item = _bikeDbContext.ShoppingItems.FirstOrDefault(b => b.Product.Id == productId && b.Bag.Id == bagId);
            return item;
        }

        public void UpdateShoppingItem(ShoppingItem shoppingItem)
        {
            _bikeDbContext.ShoppingItems.Update(shoppingItem);
            _bikeDbContext.SaveChanges();
        }
    }
}
