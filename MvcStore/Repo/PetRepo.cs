using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcStore.Models;


namespace MvcStore.Repo
{
    public class PetRepo
    {
        public IEnumerable<Pet> GetAllPets(){
            return PetDataSource();
        }

        public Pet GetPet(int Id)
        {
            return GetPetById(Id);
        }
        public Pet GetPetById(int id)
        {
            return PetDataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        private IEnumerable<Pet> PetDataSource(){
            return new List<Pet>()
            {
                new Pet(){Id = 1, Name = "Dog", Price = 499.99, Description = "Fluffy Dog goes woof"},
                new Pet(){Id = 2, Name = "Cat", Price = 299.99, Description = "Fluffy Cat goes meow"},
                new Pet(){Id = 3, Name = "Fish", Price = 9.99, Description = "Slimy Fish goes blub"},
                new Pet(){Id = 4, Name = "Bird", Price = 59.99, Description = "Pretty Bird goes chirp"},
                new Pet(){Id = 5, Name = "Snake", Price = 89.99, Description = "Long Snake goes hisss"}
            };
        }
    }
}