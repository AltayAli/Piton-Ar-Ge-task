using Microsoft.AspNetCore.Mvc;
using System;
using TaskManager.Service;
using TaskManager.Service.DTOs;

namespace TaskManager.BackEnd.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskManagerServices _service;
        public TasksController(ITaskManagerServices service) => _service = service;

        [HttpGet("userId")]
        public IActionResult GetTasks(int userId)
        {
            try
            {
                return Ok(_service.TasksServices.GetTasksList(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                return Ok(_service.TasksServices.GetSimpleTask(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(TaskOperationModel dto)
        {
            try
            {
                _service.TasksServices.Create(dto);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskOperationModel dto)
        {
            try
            {
                _service.TasksServices.Update(id, dto);
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
                _service.TasksServices.Delete(id);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
