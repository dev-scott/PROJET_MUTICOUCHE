using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionLocation.Type.Commons;

namespace GestionLocation.Dal
{
    public class CarDal
    {

        public MainForm Parent;
        public CarDal(MainForm mainForm)
        {
            this.Parent = mainForm;
        }

        // Buildings
        public List<Car> GetCars()
        {
            return this.Parent.cars;
        }

        public void AddCars(Car car)
        {
            this.Parent.cars.Add(car);
        }

        /**
         * DAL to find Building by ID
         * @param int Id
         * @return Bulding building
         * */
        public Car FindById(int Id)
        {
            List<Car> cars = GetCars();
            return cars.Find(delegate (Car item)
            {
                return item.Id == Id;
            });
        }

        public Car Update(Car car)
        {
            int CarIndex = Parent.cars.FindIndex(delegate (Car item)
            {
                return item.Id == car.Id;
            });

            if (CarIndex >= 0)
            {
                Parent.cars[CarIndex] = car;
                return car;
            }
            else
            {
                throw new Exception("Objet car non existant!");
            }
        }

        public int Delete(int Id)
        {
            int CArIndex = Parent.cars.FindIndex(delegate (Car car)
            {
                return car.Id == Id;
            });

            if (CArIndex >= 0)
            {
                Parent.cars.RemoveAt(CArIndex);
                return CArIndex;
            }
            else
            {
                throw new Exception("Objet Car non existant!", new KeyNotFoundException("Objet non existant dans la collection"));
            }
        }

        public List<Car> FindAllByName(String Name)
        {
            return Parent.cars.FindAll(delegate (Car Item)
            {
                return Item.Name.ToLower().Contains(Name.ToLower());
            });
        }

        public Car FindByName(String Name)
        {
            return Parent.cars.Find(delegate (Car Item)
            {
                return Item.Name == Name;
            });
        }

    }
}
