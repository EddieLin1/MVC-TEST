using MvcStore.Models;



namespace MvcStore.Interface
{
    public interface IShoppingCartItemsRepository
    {
       // Task<IEnumerable<Cart>> GetAllCartItemsAsync();
        CartItem GetCartItemById(int id);
        Cart GetAllCartItems();
        void AddNew(Item item, int Quantity, int CartId);
        CartItem item2CartItem(Item item, int Quantity);
        void SaveChanges();
        void Remove(CartItem item);
        void AddMore(int id, int Quantity);
        int CurrentCartNum(bool purchased_check);


    }
}