using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.WebAPI;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        IUserImageDal _userImageDal;

        public UserImageManager(IUserImageDal userImageDal)
        {
            _userImageDal = userImageDal;
        }

        public IResult Add(IFormFile file, UserImage entity)
        {
            entity.ImagePath = UserFileHelper.AddAsync(file);
            entity.Date = DateTime.Now;
            _userImageDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(UserImage entity)
        {
            entity.ImagePath = UserFileHelper.DeleteAsync(_userImageDal.GetById(e => e.Id == entity.Id).ImagePath);
            if (entity.ImagePath == null)
            {
                return new SuccessResult(Messages.Deleted);
            }

            return new ErrorResult(Messages.Exception);
        }

        public IDataResult<List<UserImage>> GetAll()
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<UserImage> GetById(int userId)
        {
            return new SuccessDataResult<UserImage>(_userImageDal.GetById(e => e.UserId == userId), Messages.Listed);
        }

        public IResult Update(IFormFile file, UserImage entity)
        {
            var userImage = _userImageDal.GetById(e=>e.UserId == entity.UserId);
            entity.ImagePath = UserFileHelper.UpdateAsync(userImage.ImagePath, file);
            entity.Date = DateTime.Now;
            entity.Id = userImage.Id;
            _userImageDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
