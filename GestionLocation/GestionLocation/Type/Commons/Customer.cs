using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Type.Commons
{
    public class Customer
    {

        public int Id;
        public String Name;
        public int Phone;


        public static int INC_ID;

        public Customer(String Name, int Phone)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.Id = ++INC_ID;
        }

        public Customer(int Id, String Name, int Phone)
        {
            this.Name = Name;
            
            this.Phone = Phone;
            this.Id = Id;
        }

        public bool IsNull()
        {
            return this == null;
        }


    }
}
