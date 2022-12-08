using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Dal
{
    public class DashBoadDal

    {
        public MainForm Parent;
        public DashBoadDal(MainForm mainform)
        {
            this.Parent = mainform;
        }
        public List<DashBoad> GetDashBoad()
        {
          return this.Parent.dashboad;    
        }

        public void AddDashBoad(DashBoad dashboad)
        {
           this.Parent.dashboad.Add(dashboad);
        }

    }
}
