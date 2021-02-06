using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Ekleme başarıyla gerçekleştirilmiştir.");
            }
            else
            {
                Console.WriteLine("Lütfen girdiğiniz marka 2 karakterli olmak zorundadır!");
            }
        }

        public void Delete(Brand brand)
        {
            using (CarsModelsContext context = new CarsModelsContext())
            {
                context.Brands.Remove(context.Brands.SingleOrDefault(b => b.BrandId == brand.BrandId));
                context.SaveChanges();
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
