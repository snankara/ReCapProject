﻿using Core.DataAccess.EntityFramework;
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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarRentalContext carRentalContext = new CarRentalContext())
            {
                var result = from customer in filter == null ? carRentalContext.Customers : carRentalContext.Customers.Where(filter)
                             join user in carRentalContext.Users on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.UserId,
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 CompanyName = customer.CompanyName
                             };
                return result.ToList();

            }
        }
    }
}
