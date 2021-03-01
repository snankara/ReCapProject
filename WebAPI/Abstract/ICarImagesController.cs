using Core.WebAPI;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Abstract
{
    interface ICarImagesController : IControllerRepository<CarImage>
    {
    }
}
