using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext carRentalContext = new CarRentalContext())
            {
                var result = from rental in filter == null ? carRentalContext.Rentals: carRentalContext.Rentals.Where(filter)
                             join car in carRentalContext.Cars on rental.CarId equals car.CarId
                             join user in carRentalContext.Users on rental.CustomerId equals user.Id
                             join customer in carRentalContext.Customers on rental.CustomerId equals customer.UserId
                             select new RentalDetailDto { CarName = car.CarName, FirstName = user.FirstName, 
                                 LastName = user.LastName,DailyPrice = car.DailyPrice, 
                                 RentDate = rental.RentDate, ReturnDate = rental.ReturnDate,
                                 CarId =car.CarId, CustomerId = customer.UserId};
                return result.ToList();
            }
        }
    }
}
