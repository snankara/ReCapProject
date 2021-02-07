using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IServiceRepository<TEntity> where TEntity: class,IEntity, new()
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);

    }
}
