using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.WebAPI
{
    public interface IControllerRepository<TEntity> where TEntity:class, IEntity, new()
    {
        IActionResult GetAll();
        IActionResult GetById(int id);
        IActionResult Add(TEntity entity);
        IActionResult Update(TEntity entity);
        IActionResult Delete(TEntity entity);
    }
}
