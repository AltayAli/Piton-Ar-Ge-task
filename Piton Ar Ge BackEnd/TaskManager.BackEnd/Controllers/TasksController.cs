using Microsoft.AspNetCore.Mvc;
using System;
using TaskManager.Data.Models;
using TaskManager.Repository.Repositories;

namespace TaskManager.BackEnd.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository _repo;
        public TasksController(ITasksRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_repo.GetList());
        }
        [HttpGet]
        public IActionResult GetUndoList()
        {
            return Ok(_repo.GetUndoList());
        }

        [HttpGet("{id}")]
        public IActionResult GetSimple(int id)
        {
            return Ok(_repo.GetSingle(id));
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            try
            {
                _repo.Create(task);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Task task)
        {
            try
            {
                _repo.Update(id,task);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult DoUndo(int id)
        {
            try
            {
                return Ok(_repo.DoUnDo(id));
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
                _repo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
