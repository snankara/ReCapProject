using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext carRentalContext = new CarRentalContext())
            {
                var result = from rental in carRentalContext.Rentals
                             join car in carRentalContext.Cars on rental.CarId equals car.CarId
                             join user in carRentalContext.Users on rental.CustomerId equals user.Id
                             select new RentalDetailDto { CarName = car.CarName, FirstName = user.FirstName, LastName = user.LastName,DailyPrice = car.DailyPrice, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate};
                return result.ToList();
            }
        }
    }
}
