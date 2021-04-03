using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string CarName { get; set; } 
        public string FirstName { get; set; } //user table
        public string LastName { get; set; } //user table
        public decimal DailyPrice { get; set; } 
        public DateTime RentDate { get; set; } //rental table
        public DateTime? ReturnDate { get; set; } //rental table
    }
}
