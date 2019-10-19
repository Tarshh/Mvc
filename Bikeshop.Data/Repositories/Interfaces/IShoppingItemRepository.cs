namespace Bikeshop.Models.Repositories.Interfaces
{
    public interface IShoppingItemRepository
    {
        void AddItem(ShoppingItem shoppingItem);
        ShoppingItem GetItem(int productId, int bagId);
        void UpdateShoppingItem(ShoppingItem shoppingItem);
    }
}
