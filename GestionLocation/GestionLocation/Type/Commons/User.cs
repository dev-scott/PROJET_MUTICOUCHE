using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Type.Commons
{
    internal class User
    {


        public int Id;
        public String Name;
        public String Password;


        public static int INC_ID;

        public User(String Name, String Password )
        {
            this.Name = Name;
            this.Password = Password;
            this.Id = ++INC_ID;
        }

        public User(int Id, String Name, String Password)
        {
            this.Name = Name;

            this.Password = Password;
            this.Id = Id;
        }

        public bool IsNull()
        {
            return this == null;
        }
    }
}
