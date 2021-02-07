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

            // --- BRAND OPERATIONS --- 

            //brandManager.Add(new Brand { BrandName = "Mercedes" });
            //brandManager.Add(new Brand { BrandName = "Bmw" });
            //brandManager.Add(new Brand { BrandName = "Volkswagen" });
            //brandManager.Add(new Brand { BrandName = "FIAT" });
            //brandManager.Add(new Brand { BrandName = "Kia" });
            //brandManager.Add(new Brand { BrandName = "Nissan" });
            //brandManager.Add(new Brand { BrandName = "Volvo" });
            //brandManager.Add(new Brand { BrandName = "Seat" });

            //brandManager.Delete(new Brand { BrandId = 8, BrandName = "Seat" });

            //brandManager.Update(new Brand {BrandId = 4, BrandName = "Fiat" });

            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}

            //Console.WriteLine(brandManager.GetById(7).BrandName);

            // --- BRAND OPERATIONS --- 


            // --- COLOR OPERATIONS ---

            //colorManager.Add(new Color { ColorName = "Black" });
            //colorManager.Add(new Color { ColorName = "WHITE" });
            //colorManager.Add(new Color { ColorName = "Red" });

            //colorManager.Delete(new Color { ColorId = 3, ColorName = "Red" });

            //colorManager.Update(new Color {ColorId = 2, ColorName = "White" });

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}

            //Console.WriteLine(colorManager.GetById(1).ColorName);

            // --- COLOR OPERATIONS ---


            //CAR OPERATIONS

            //carManager.Add(new Car { CarName = "Volkswagen", BrandId = 2, ColorId = 2, DailyPrice = 1000, Description = "VOLKSWAGEN", ModelYear = "2018" });
            //carManager.Add(new Car { CarName = "Bmw", BrandId = 2, ColorId = 1, DailyPrice = 1400, Description = "Bmw", ModelYear = "2016" });
            //carManager.Add(new Car { CarName = "Volvo", BrandId = 7, ColorId = 1, DailyPrice = 900, Description = "Volvo", ModelYear = "2017" });

            //carManager.Delete(new Car { CarId = 3, CarName = "Volvo", BrandId = 7, ColorId = 1, DailyPrice = 900, Description = "Volvo", ModelYear = "2017" });

            //carManager.Update(new Car {CarId = 1, CarName = "Volkswagen", BrandId = 3, ColorId = 2, DailyPrice = 1000, Description = "VOLKSWAGEN", ModelYear = "2018" });

            //Console.WriteLine(carManager.GetById(1).CarName);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarName + "-" + car.ModelYear + "-" + car.DailyPrice);
            //}

            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(car.CarName);
            //}

            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(car.CarName);
            //}

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
            //CAR OPERATIONS

        }
    }
}
