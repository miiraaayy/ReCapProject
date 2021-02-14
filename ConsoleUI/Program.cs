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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
          
            
            //CustomerAdded(customerManager);
            //RentAdded(rentalManager);
            //CarTest();
            //CrudTest(carManager, brandManager, colorManager);

        }

        private static void CustomerAdded(CustomerManager customerManager)
        {
            var result = customerManager.Add(new Customer { CompanyName = "145" });
            Console.WriteLine(result.Message);
        }

        private static void RentAdded(RentalManager rentalManager)
        {
            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentalId = 1, RentDate = new DateTime(2021, 2, 20) });
            Console.WriteLine(result.Message);
        }

        private static void UserAddedAndDeleted(UserManager userManager)
        {
            var result = userManager.Add(new User { FirstName = "Elif", LastName = "Bakıcı", Email = "elif.14@gmail.com", Password = "123654" });
            Console.WriteLine(result.Message);
            var result2 = userManager.Delete(new User { Id = 3 });
            Console.WriteLine(result2.Message);
        }


        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                   

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
           
        }


        private static void CrudTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Arabalar Listeleniyor...");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " ) Arabanın modeli :  " + car.ModelYear + " -  Ürün Fiyatı " + car.DailyPrice + " - Ürün Açıklaması :  " + car.Description);
            }
            
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Araba Marka Seçenekleri yükleniyor.. ");

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " ) Araba markası : " + brand.BrandName);
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Araba Renk Seçenekleri yükleniyor...");
            foreach (var color in colorManager.GetAll().Data)
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
