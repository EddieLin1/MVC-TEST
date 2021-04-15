using MvcStore.Repo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace MvcStore.Models
{
    public class Item
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public float Price {get; set;}
        public int QuantitySold {get; set;}
        [NotMapped]
      public string ImageURL {
            get{return "~/images/" + Id +".jpg";}
        } 
   
        
    }

    
}