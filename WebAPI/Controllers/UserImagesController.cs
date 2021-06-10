using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImagesController : ControllerBase
    {
        IUserImageService _userImageService;

        public UserImagesController(IUserImageService userImageService)
        {
            _userImageService = userImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("image"))] IFormFile file, [FromForm] UserImage entity)
        {
            var result = _userImageService.Add(file, entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Add([FromForm(Name = ("id"))] int id)
        {
            var userImage = _userImageService.GetById(id).Data;
            var result = _userImageService.Delete(userImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("image"))] IFormFile file, [FromForm] UserImage entity)
        {
            var result = _userImageService.Update(file, entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userId)
        {
            var result = _userImageService.GetById(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
