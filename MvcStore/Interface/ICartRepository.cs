namespace MvcStore.Interface
{
    public interface ICartRepository
    {
        bool? PurchaseCheck(int CartId);
        bool? PurchaseCheckInit();
    }
}