﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
            _carDal.Add(entity);

            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<CarDetailAndImageDto>> GetCarAndImageDetails()
        {

            return new SuccessDataResult<List<CarDetailAndImageDto>>(_carDal.GetCarAndImageDetails(), Messages.Listed);
        }

        public IDataResult<List<CarDetailAndImageDto>> GetCarAndImageDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailAndImageDto>>(_carDal.GetCarAndImageDetails(c => c.CarId == carId), Messages.Listed);
        }

        public IDataResult<List<CarDetailAndImageDto>> GetCarAndImageDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailAndImageDto>>(_carDal.GetCarAndImageDetails(c => c.BrandId == brandId), Messages.Listed);
        }
        public IDataResult<List<CarDetailAndImageDto>> GetCarAndImageDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailAndImageDto>>(_carDal.GetCarAndImageDetails(c => c.ColorId == colorId), Messages.Listed);
        }

        //[SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);

        }

        [PerformanceAspect(3)]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetByBrandIdAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId), Messages.Listed);
        }

        public IDataResult <List<CarDetailDto>> GetById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == id),Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == id),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == id),Messages.Listed);
        }

        //[SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.Updated);

        }

    }
}
