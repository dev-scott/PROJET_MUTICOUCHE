using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Dal
{
    public class UserDal
    {
        public MainForm Parent;
        public UserDal(MainForm mainform)
        {
            this.Parent = mainform;
        }
        public List<Users> GetUsers()
        {
            return this.Parent.users;
        }
        public void AddUsers(Users users)
        {
            this.Parent.users.Add(users);
        }
        public List<Users> FindAllByName(String Name)
        {
            return Parent.users.FindAll(delegate (Users Item)
            {
                return Item.Name.ToLower().Contains(Name.ToLower());
            });
        }

        public Users FindByName(String Name)
        {
            return Parent.users.Find(delegate (Users Item)
            {
                return Item.Name == Name;
            });
        }
    }
}