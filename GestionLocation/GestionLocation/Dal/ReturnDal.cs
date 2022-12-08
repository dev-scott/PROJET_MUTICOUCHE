using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Dal
{
    public class ReturnDal
    {
        public MainForm Parent;
        public ReturnDal(MainForm mainform)
        {
            this.Parent = mainform;
        }
        public List<Return> ReturnDals()
        {
            return this.Parent.returns;
        }
        public void AddReturn(Return returns)
        {
            this.Parent.returns.Add(returns);
        }
        public List<Return> FindAllByName(String Name)
        {
            return Parent.returns.FindAll(delegate (Return Item)
            {
                return Item.Name.ToLower().Contains(Name.ToLower());
            });
        }

        public Return FindByName(String Name)
        {
            return Parent.returns.Find(delegate (Return Item)
            {
                return Item.Name == Name;
            });
        }
    }
}