using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Type.Commons
{
    public class Car
    {
        public int Id;
        public String Name;
        public String Model;
        public string Available;
        public int Price;
        

        public static int INC_ID;

        public Car(String Name, String Model , String Available , int Price)
        {
            this.Name = Name;
            this.Model = Model;
            this.Available = Available;
            this.Price = Price;
            this.Id = ++INC_ID;
        }

        public Car(int Id, String Name, String Model, String Availab , int Price)
        {
            this.Name = Name;
            this.Model = Model;
            this.Available = Available;
            this.Price = Price;
            this.Id = Id;
        }

        public bool IsNull()
        {
            return this == null;
        }

    }
}
