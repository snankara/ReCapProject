using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CarManager carManager = new CarManager(new EfCarDal());

            Brand brand1 = new Brand { Id = 1, Name = "Mercedes" };
            Brand brand2 = new Brand { Id = 2, Name = "Bmw" };
            Brand brand3 = new Brand { Id = 3, Name = "Volkswagen" };
            Brand brand4 = new Brand { Id = 4, Name = "FIAT" };
            Brand brand5 = new Brand { Id = 5, Name = "Kia" };
            Brand brand6 = new Brand { Id = 6, Name = "Nissan" };
            Brand brand7 = new Brand { Id = 7, Name = "Volvo" };
            Brand brand8 = new Brand { Id = 8, Name = "Seat" };

            Color color1 = new Color { Id = 1, Name = "Black" };
            Color color2 = new Color { Id = 2, Name = "WHITE" };
            Color color3 = new Color { Id = 3, Name = "Red" };

            Car car1 = new Car { Id = 1, BrandId = 2, ColorId = 2, DailyPrice = 1000, Description = "VOLKSWAGEN", ModelYear = "2018" };
            Car car2 = new Car { Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 1400, Description = "Bmw", ModelYear = "2016" };
            Car car3 = new Car { Id = 3, BrandId = 7, ColorId = 1, DailyPrice = 900, Description = "Volvo", ModelYear = "2017" };

            // --- BRAND OPERATIONS --- 
            //brandManager.Add(brand1);
            //brandManager.Add(brand2);
            //brandManager.Add(brand3);
            //brandManager.Add(brand4);
            //brandManager.Add(brand5);
            //brandManager.Add(brand6);
            //brandManager.Add(brand7);
            //brandManager.Add(brand8);

            //brandManager.Delete(brand8);

            //brandManager.Update(brand4);

            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.Name);
            //}

            //foreach (var brand in brandManager.GetById(7))
            //{
            //    Console.WriteLine(brand.Name);
            //}
            // --- BRAND OPERATIONS --- 


            // --- COLOR OPERATIONS ---

            //colorManager.Add(color1);
            //colorManager.Add(color2);
            //colorManager.Add(color3);

            //colorManager.Delete(color3);

            //colorManager.Update(color2);

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.Name);
            //}

            //foreach (var color in colorManager.GetById(1))
            //{
            //    Console.WriteLine(color.Name);
            //}

            // --- COLOR OPERATIONS ---


            //CAR OPERATIONS

            //carManager.Add(car1);
            //carManager.Add(car2);
            //carManager.Add(car3);

            //carManager.Delete(car3);

            ////carManager.Update(car1);

            //foreach (var car in carManager.GetById(1))
            //{
            //    Console.WriteLine(car.Description + "-" + car.ModelYear + "-" + car.DailyPrice);
            //}

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + "-" + car.ModelYear + "-" + car.DailyPrice);
            }

            //foreach (var car in carManager.GetCarsByBrandId(7))
            //{
            //    Console.WriteLine(car.Description);
            //}

            //foreach (var car in carManager.GetCarsByColorId(1))
            //{
            //    Console.WriteLine(car.Description);
            //}

            //CAR OPERATIONS

        }
    }
}
