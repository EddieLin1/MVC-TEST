namespace MvcStore.Models
{
    public class Pet
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public double Price {get; set;}
        public string Description {get; set;}
        public int Quantity {get; private set;}

        public Pet()
        {
            this.Quantity = 1;
        }
        public void add_Quantity(int x)
        {
            this.Quantity += x;
        } 
        public void sub_Quantity(int x)
        {
            this.Quantity -= x;
        } 
    }
}