using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetByBrandIdAndColorId(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        //IDataResult<CarDetailAndImageDto> CarDetailAndImage(int carId);
        IDataResult<List<CarDetailAndImageDto>> GetCarAndImageDetails();
        IDataResult<List<CarDetailAndImageDto>> GetCarAndImageDetailsByCarId(int carId);
        IDataResult<List<CarDetailAndImageDto>> GetCarAndImageDetailsByBrandId(int brandId);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetById(int id);
        IResult Add(Car entity);
        IResult Delete(Car entity);
        IResult Update(Car entity);

    }
}
