﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;
        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]      
        public ActionResult GetTasks()
        {          
            return Ok(_tasksService.GetTasks());
        }

        [HttpGet("{id}")]
        public ActionResult GetTask([FromRoute] Guid id)
        {
            try
            {
                 return Ok(_tasksService.GetTask(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateTask([FromBody] CreateModelRequest request)
        {
            _tasksService.CreateTask(request);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateTask([FromQuery] ToDoTask updateTask)
        {
            try
            {
                _tasksService.UpdateTask(updateTask);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(Guid id)
        {
            try
            {
                _tasksService.DeleteTask(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
