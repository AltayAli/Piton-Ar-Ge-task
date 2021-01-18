using Microsoft.AspNetCore.Mvc;
using System;
using TaskManager.Service;
using TaskManager.Service.DTOs;

namespace TaskManager.BackEnd.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITaskManagerServices _service;
        public UsersController(ITaskManagerServices service) => _service = service;

        [HttpPost]
        public IActionResult Create(UserRegisterDTO dto)
        {
            try
            {
                var userId = _service.UsersService.Create(dto);
                return Created("", userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,UserRegisterDTO dto)
        {
            try
            {
               _service.UsersService.Update(id,dto);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
               _service.UsersService.Delete(id);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
