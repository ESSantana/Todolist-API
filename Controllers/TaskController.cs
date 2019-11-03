using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Entities;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Attributes

        private readonly ITaskService taskService;
        private readonly IMapper mapper;
        
        #endregion
        
        #region Constructor
        
        public TaskController(ITaskService taskService, IMapper mapper, IHttpContextAccessor accessor)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        #endregion

        #region Endpoints

        [HttpGet]
        public ActionResult<List<TaskViewModel>> Get()
        {
            var result = taskService.Get();
            return result != null ? (ActionResult)Ok(result.Select(r => mapper.Map<TaskViewModel>(r)).ToList()) : NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<TaskViewModel> GetTask(int id)
        {
            var result = taskService.GetTask(id);
            return result != null ? (ActionResult)Ok(mapper.Map<TaskViewModel>(result)) : NoContent();
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] TaskDTO task)
        {
            var result = taskService.Post(mapper.Map<Task>(task));
            return result ? Ok() : (ActionResult)Problem();
        }

        [HttpPost("update")]
        public ActionResult Update([FromBody] TaskDTO task)
        {
            var result = taskService.Update(mapper.Map<Task>(task));
            return result ? Ok() : (ActionResult)Problem();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            return taskService.Delete(id) 
                ? (ActionResult)Ok("Task removed") 
                : NotFound("Invalid ID!");
        }

        #endregion
    }
}