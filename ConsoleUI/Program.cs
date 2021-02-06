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

            Console.WriteLine("Arabalar Listeleniyor...");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " ) Arabanın modeli :  " + car.ModelYear + " -  Ürün Fiyatı " + car.DailyPrice + " - Ürün Açıklaması :  " + car.Description);
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
            brandManager.Add(new Brand { BrandName = "Toyota" });

            //carManager.Delete(new Car { CarId = 5  });
            //brandManager.Delete(new Brand { BrandId = 4 });



        }
    }
}
