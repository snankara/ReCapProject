﻿using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService 
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int id);
        IDataResult<CarImage> GetById(int id);
        IResult Add(IFormFile file,CarImage entity);
        IResult Delete(CarImage entity);
        IResult Update(IFormFile file,CarImage entity);
    }
}
