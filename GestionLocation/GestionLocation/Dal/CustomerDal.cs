using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Dal
{
    public class CustomerDal
    {
        public MainForm Parent;

        public CustomerDal(MainForm mainForm)
        {

            this.Parent = mainForm;

        }

        public List<Customer> GetCustomer()
        {

            return this.Parent.customer;
            

        }

        public void AddCustomer(Customer customer)
        {

            this.Parent.customer.Add(customer);
        }

        public List<Customer> FindAllByName(String Name)
        {
            return Parent.customer.FindAll(delegate (Customer Item)
            { return Item.Name.ToLower().Contains(Name.ToLower()); 
                });
        }

        public Customer FindByName(String Name)
        {
            return Parent.customer.Find(delegate (Customer Item)
            {
                return Item.Name == Name;
            });
        }

    }
}
