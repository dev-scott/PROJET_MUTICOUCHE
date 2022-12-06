using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionLocation.Dal;
using GestionLocation.Type.Commons;

namespace GestionLocation.Service
{
    public class CarService
    {

        public CarDal carDal;

        public CarService(MainForm parent)
        {
            this.carDal = new CarDal(parent);

        }

        public void Save( Car car)
        {

            if (!Exists(Car.Name))
            {

                this.carDal.AddCar(car);
             

            }
            else
            {

                throw new Exception("L voiture que vous voulez creer existe dejas");

            }



        }

        public bool Exists(string CarName)
        {

            List<Car> cars = carDal.GetCars();
            List<Car> FoundCars = cars.FindAll(delegate (Car item)
                {

                    return item.Name == CarName;

                });

            return FoundCars.Count>0 ? true : false;


        }

        public Car Update(Car car )
        {

            Car ExisCar = this.carDal.FindById(car.Id);
            if (!ExisCar.IsNull())
            {

                ExisCar.Name = car.Name;
                ExisCar.Model = car.Model;
                ExisCar.Available = car.Available;
                ExisCar.Price = car.Price;

                return carDal.Update(ExisCar);

            }
            else
            {

                throw new Exception("Building non existant");

            }





        }


        public int Delete(int Id)
        {
            Car CarToDelete = carDal.FindById(Id);
            if (!CarToDelete.IsNull())
            {
                // supprimer le building
                return carDal.Delete(Id);
            }
            else
            {
                throw new Exception("La voiture que vous voulez supprimer n'existe pas!");
            }
        }

        public List<Car> Filter(String Name)
        {
            return carDal.FindAllByName(Name);
        }

        public Car FindByName(String Name)
        {
            return carDal.FindByName(Name);
        }

        public List<Car> FindAll()
        {
            return carDal.GetBuildings();
        }



    }
}
