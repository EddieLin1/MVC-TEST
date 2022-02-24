using MvcStore.Models;
namespace MvcStore.Interface
{
    public interface ICartRepository
    {
        bool PurchaseCheck(int CartId);
        bool PurchaseCheckInit();
        void SaveChanges();
        Cart get_cart(int cart_id);
        int get_current_cartnum();
        void add_cart(Cart model);
    }
}