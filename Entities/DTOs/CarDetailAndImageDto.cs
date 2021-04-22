using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailAndImageDto:IDto
    {
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int CarId { get; set; }
        public int MinFindeksScore { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string ModelYear { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        //public List<DateTime> ImageDate { get; set; }
        public List<string> ImagePath { get; set; }
    }
}
