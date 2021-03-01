using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Data.SqlTypes;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandTests();

            //ColorTests();

            //CarTests();

            //UserTests();

            //CustomerTests();

            //RentalTests();

            //CarImageManager carImageManager = new CarImageManager(new EfCarImageDal());
            //CarImage image1 = new CarImage { CarId = 1, ImagePath = "‪C:/Users/SNAN/Desktop/share-icon-2.png", Date = DateTime.Now };
            //carImageManager.Add(image1);
        }

        private static void RentalTests()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = null }).Message);
            Console.WriteLine(rentalManager.Add(new Rental { CarId = 2, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = null }).Message);
            Console.WriteLine(rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = null }).Message);
            Console.WriteLine(rentalManager.Update(new Rental { Id = 1007, CarId = 1, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = new DateTime(2021, 02, 13) }).Message);
            Console.WriteLine(rentalManager.Update(new Rental { Id = 1008, CarId = 1002, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = new DateTime(2021, 02, 13) }).Message);
            Console.WriteLine(rentalManager.Add(new Rental { CarId = 2, CustomerId = 1004, RentDate = DateTime.Now, ReturnDate = null }).Message);
            Console.WriteLine(rentalManager.Add(new Rental { CarId = 2, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = null }).Message);

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentDate + "-" + rental.ReturnDate);
            }
            Console.WriteLine(rentalManager.GetAll().Message);
        }

        private static void CustomerTests()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Console.WriteLine(customerManager.Update(new Customer { UserId = 2, CompanyName = "GHI COMPANY" }).Message);

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
            Console.WriteLine(customerManager.GetAll().Message);

            Console.WriteLine(customerManager.GetById(2).Data.CompanyName);
        }

        private static void UserTests()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //Console.WriteLine(userManager.Add(new User { FirstName = "Mehmet", LastName = "Sayar", Email = "example@outlook.com", Password = "abcde12" }).Message);

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }

            Console.WriteLine(userManager.GetAll().Message);

            Console.WriteLine(userManager.GetById(1004).Data.FirstName);
        }

        private static void CarTests()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { CarName = "Volkswagen", BrandId = 2, ColorId = 2, DailyPrice = 1000, Description = "VOLKSWAGEN", ModelYear = "2018" });
            carManager.Add(new Car { CarName = "Bmw", BrandId = 2, ColorId = 1, DailyPrice = 1400, Description = "Bmw", ModelYear = "2016" });
            carManager.Add(new Car { CarName = "Volvo", BrandId = 7, ColorId = 1, DailyPrice = 900, Description = "Volvo", ModelYear = "2017" });

            carManager.Delete(new Car { CarId = 3, CarName = "Volvo", BrandId = 7, ColorId = 1, DailyPrice = 900, Description = "Volvo", ModelYear = "2017" });

            carManager.Update(new Car { CarId = 2, CarName = "Bmw", BrandId = 2, ColorId = 1, DailyPrice = 1400, Description = "", ModelYear = "2016" });

            Console.WriteLine(carManager.GetById(1));

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName + "-" + car.ModelYear + "-" + car.DailyPrice);
            }

            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.CarName);
            }

            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(car.CarName);
            }


            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
        }

        private static void ColorTests()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { ColorName = "Black" });
            colorManager.Add(new Color { ColorName = "WHITE" });
            colorManager.Add(new Color { ColorName = "Red" });

            colorManager.Delete(new Color { ColorId = 3, ColorName = "Red" });

            colorManager.Update(new Color { ColorId = 2, ColorName = "White" });

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine(colorManager.GetById(1));
        }

        private static void BrandTests()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand { BrandName = "Mercedes" });
            brandManager.Add(new Brand { BrandName = "Bmw" });
            brandManager.Add(new Brand { BrandName = "Volkswagen" });
            brandManager.Add(new Brand { BrandName = "FIAT" });
            brandManager.Add(new Brand { BrandName = "Kia" });
            brandManager.Add(new Brand { BrandName = "Nissan" });
            brandManager.Add(new Brand { BrandName = "Volvo" });
            brandManager.Add(new Brand { BrandName = "Seat" });

            brandManager.Delete(new Brand { BrandId = 8, BrandName = "Seat" });

            brandManager.Update(new Brand { BrandId = 4, BrandName = "Fiat" });

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine(brandManager.GetById(5));
        }
    }
}
