using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Fiyat bilgisi tanımlanmıştır.");
            }
            else
            {
                Console.WriteLine("Lütfen girdğiniz fiyat 0 ' dan büyük olmalıdır.");
            }
        }

        public void Delete(Car car)
        {
            using (CarsModelsContext context = new CarsModelsContext())
            {
                context.Cars.Remove(context.Cars.SingleOrDefault(c => c.CarId == car.CarId));
                context.SaveChanges();
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min);
        }

        public List<Car> GetById()
        {
            return _carDal.GetById();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine(car.CarId + " "+ car.ModelYear+ " " + car.DailyPrice);
        }
    }
}
