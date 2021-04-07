using MvcStore.Repo;
namespace MvcStore.Models
{
    public class Item
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public float Price {get; set;}
        public int QuantitySold {get; set;}
    }

    
}