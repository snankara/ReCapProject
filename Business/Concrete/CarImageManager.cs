using Business.Abstract;
using Business.Constants;
using Core.Utilities.WebAPI;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Business;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file,CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfCarImagesLimitExceeded(entity.CarId));
            if (result != null)
            {
                return result;
            }

            entity.ImagePath = FileHelper.AddAsync(file);
            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);

            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarImage entity)
        {
            entity.ImagePath = FileHelper.DeleteAsync(_carImageDal.GetById(e => e.Id == entity.Id).ImagePath);
            if (entity.ImagePath == null)
            {
                _carImageDal.Delete(entity);

                return new SuccessResult(Messages.Deleted);
            }

            return new ErrorResult(Messages.Exception);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }
        public IDataResult<List<CarImage>> GetAllByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId == id), Messages.Listed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(c=>c.Id == id), Messages.Listed);
        }

        public IResult Update(IFormFile file,CarImage entity)
        {
            entity.ImagePath = FileHelper.UpdateAsync(_carImageDal.GetById(e => e.Id == entity.Id).ImagePath, file);
            entity.Date = DateTime.Now;
            _carImageDal.Update(entity);

            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfCarImagesLimitExceeded(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }

            return new SuccessResult();
        }
    }
}
