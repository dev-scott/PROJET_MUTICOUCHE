using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Dal
{
    public class RentalDal
    {
        public MainForm Parent;
        public RentalDal(MainForm mainform)
        {
            this.Parent = mainform;
        }
        public List<Rental> GetRental()
        {
            return this.Parent.rental;
        }
        public void AddRental(Rental rental)
        {
            this.Parent.rental.Add(rental);
        }
        public List<Rental> FindAllByName(String Name)
        {
            return Parent.rental.FindAll(delegate (Rental Item)
            {
                return Item.Name.ToLower().Contains(Name.ToLower());
            });
        }

        public Rental FindByName(String Name)
        {
            return Parent.rental.Find(delegate (Rental Item)
            {
                return Item.Name == Name;
            });
        }
    }
}