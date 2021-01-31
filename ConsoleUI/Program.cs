using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car car1 = new Car { Id = 5, BrandId = 3, ColorId = 4, ModelYear = "2016", DailyPrice = 550, Description = "Car5" };
            Car car2 = new Car { Id = 6, BrandId = 3, ColorId = 5, ModelYear = "2019", DailyPrice = 800, Description = "Car6" };

            //carManager.Add(car1);
            //carManager.Add(car2);
            //carManager.Delete(car2);
            //carManager.Update(car1);

            //foreach (var car in carManager.GetById(1))
            //{
            //    Console.WriteLine(car.Description + "-" + car.ModelYear + "-" + car.DailyPrice);
            //}

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + "-" + car.ModelYear + "-" + car.DailyPrice);
            }
        }
    }
}
