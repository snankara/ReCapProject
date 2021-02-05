using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand entity)
        {
            _brandDal.Add(entity);
            Console.WriteLine("Brand Added : {0}",entity.BrandName);
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            Console.WriteLine("Brand Deleted");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetById(b=>b.BrandId == id);

        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
            Console.WriteLine("Brand Updated : {0}", entity.BrandName);
        }
    }
}
