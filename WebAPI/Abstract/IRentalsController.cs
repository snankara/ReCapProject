using Core.WebAPI;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Abstract
{
    public interface IRentalsController : IControllerRepository<Rental>
    {
        IActionResult GetRentalDetails();
    }
}
