using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1 , BrandId = 1, ColorId = 1, DailyPrice = 345000 ,ModelYear = 1978 , Description ="Cadillac Eldorado"},
                new Car{CarId = 2, BrandId = 1, ColorId = 2, DailyPrice = 40000, ModelYear = 1960 ,Description ="Cadillac Coupe Deville"},
                new Car{CarId = 3 , BrandId = 2, ColorId = 3,DailyPrice = 775000 ,ModelYear = 1960 , Description = "12.Nesil Toyota Corolla"},
                new Car{CarId = 4, BrandId = 3, ColorId = 5, DailyPrice = 695000, ModelYear = 2014 , Description ="Mercedes - Benz C 250 BlueTEC" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
           return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
