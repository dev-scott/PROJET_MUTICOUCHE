using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Dal
{
    public class LoginDal
    {
        public MainForm Parent;
        public LoginDal(MainForm  mainform)
        {
            this.Parent = mainform;
        }
        public List<Login> GetLogin(string username, string password)
        {
            return this.Parent.login;
        }
        public void AddLogin(Login login)
        {
            this.Parent.login.Add(login);
        }
        
        }
}
