using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailAndImageDto:IDto
    {
        public List<CarDetailDto> Car { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
