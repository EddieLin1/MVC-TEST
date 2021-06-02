using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcStore.Models
{
    public class CartItem
    {

        [Key]
        public int Id {get; set;}
        public int CartId {get; set;}
        public int ItemId{get; set;}
        [Range(1,100, ErrorMessage = "Please pick an int between 1-100")]
        public int Quantity {get; set;}
        [NotMapped]
        public Item item {get; set;}
         
        public string Description {
            get {return item.Description; }
        }
        public double TotalPrice {
            get{return item.Price * Quantity; }
        }

    }

}