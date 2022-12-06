using GestionLocation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionLocation.Controller
{
     class CarController
    {
        public CarService carService;


        public CarController(MainForm parent)
        {
            this.carService = new CarService(parent);

        }

    
        /*
        public List<Car> FindAll()
        {

            return carService.FindAll();


        }

        */

        public Car FindByName(String name)
        {
            return carService.FindByName(name);


        }

        public List<Car> FilterByName(String name)
        {

            return carService.Filter(name);
        }
        /*
        public int Delete(int id)
        {

            return carService.Delete(id);


        }
        public Car Update(Car car)
        {
            return carService.Update(car);
        }
        
        */
        
    }
}
