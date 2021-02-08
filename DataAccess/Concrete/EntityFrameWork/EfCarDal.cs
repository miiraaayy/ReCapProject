using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsModelsContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsModelsContext context = new CarsModelsContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.CarId equals b.BrandId
                             join co in context.Colors
                             on c.CarId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName =b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                                 
                             };

                return result.ToList();

            }
        }
    }
}
