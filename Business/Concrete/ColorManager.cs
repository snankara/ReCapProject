using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color entity)
        {
            _colorDal.Add(entity);
            Console.WriteLine("Color Added : {0}",entity.Name);
        }

        public void Delete(Color entity)
        {
            _colorDal.Delete(entity);
            Console.WriteLine("Color Deleted");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
            
        }

        public List<Color> GetById(int id)
        {
            return _colorDal.GetAll(c => c.Id == id);
        }

        public void Update(Color entity)
        {
            _colorDal.Update(entity);
            Console.WriteLine("Color Updated : {0}", entity.Name);

        }
    }
}
