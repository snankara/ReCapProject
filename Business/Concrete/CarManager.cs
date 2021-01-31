using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
            Console.WriteLine("Added : {0} !",car.Description);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Deleted : {0} !", car.Description);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById(int brandId)
        {
            return _carDal.GetById(brandId);
            
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Updated : {0} !", car.Description);

        }
    }
}
