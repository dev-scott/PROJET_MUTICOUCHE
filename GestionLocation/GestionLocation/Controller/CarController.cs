using GestionLocation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Controller
{
    internal class CarController
    {
        public CarService carService;


        public CarController(MainForm parent)
        {
            this.carService = new CarService(parent);

        }
        
    }
}
