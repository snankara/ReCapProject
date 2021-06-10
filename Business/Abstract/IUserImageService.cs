using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IDataResult<List<UserImage>> GetAll();
        IDataResult<UserImage> GetById(int id);
        IResult Add(IFormFile file, UserImage entity);
        IResult Delete(UserImage entity);
        IResult Update(IFormFile file, UserImage entity);

    }
}
