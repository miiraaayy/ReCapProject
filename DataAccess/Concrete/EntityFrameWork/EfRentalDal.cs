using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarsModelsContext>, IRentalDal
    {
        public List<RentalDetailDto> GetCarDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarsModelsContext context = new CarsModelsContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.CarId
                             join cu in context.Customers on r.CustomerId equals cu.UserId
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 CarName = c.Description,
                                 CustomerName = cu.CompanyName,
                                 UserName = u.FirstName + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate,
                             };
                return result.ToList();
            }
           
            
            
        }

    }
}

