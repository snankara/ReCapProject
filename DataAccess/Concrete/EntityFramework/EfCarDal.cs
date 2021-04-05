﻿using Core.DataAccess;
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

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext carRentalContext = new CarRentalContext())
            {
                var result = from car in filter == null ? carRentalContext.Cars : carRentalContext.Cars.Where(filter)
                             join brand in carRentalContext.Brands on car.BrandId equals brand.BrandId
                             join color in carRentalContext.Colors on car.ColorId equals color.ColorId
                             select new CarDetailDto { 
                                 CarName = car.CarName, 
                                 BrandName = brand.BrandName, 
                                 ColorName = color.ColorName, 
                                 DailyPrice = car.DailyPrice, 
                                 Description = car.Description,
                                 CarId = car.CarId,
                                 ModelYear = car.ModelYear,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 Status = !carRentalContext.Rentals.Any(r => r.CarId == car.CarId && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))
                             };

                return result.ToList();
            }

        }
    }
}
