using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            CarTest();
            CrudTest(carManager, brandManager, colorManager);

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }


        private static void CrudTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Arabalar Listeleniyor...");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " ) Arabanın modeli :  " + car.ModelYear + " -  Ürün Fiyatı " + car.DailyPrice + " - Ürün Açıklaması :  " + car.Description);
            }
            foreach (var car in carManager.GetById())
            {
                Console.WriteLine(car.CarId);
            }
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Araba Marka Seçenekleri yükleniyor.. ");

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " ) Araba markası : " + brand.BrandName);
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Araba Renk Seçenekleri yükleniyor...");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " ) Araba renk seçenekleri : " + color.ColorName);
            }

            Console.WriteLine("-------------------------------------------------------");

            carManager.Add(new Car { ModelYear = 2018, DailyPrice = 75000, Description = "Temiz ve rahat" });
            carManager.Update(new Car { CarId = 4, ModelYear = 2018, DailyPrice = 75000 });
            brandManager.Add(new Brand { BrandName = "Toyota" });
            colorManager.Add(new Color { ColorName = "Kahverengi" });



            carManager.Delete(new Car { CarId = 2009 });
            brandManager.Delete(new Brand { BrandId = 1015 });
            colorManager.Delete(new Color { ColorId = 8 });
        }
    }
}
