﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODOList.Database;
using TODOList.Database.Model;

namespace TODOList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            using (var dbContext = new TasksDatabaseContext())
            {
                return dbContext.Tasks.ToList();
            }
        }

        [HttpPost]
        public void Post([FromBody] string taskTitle)
        {
            using (var dbContext = new TasksDatabaseContext())
            {
                Task objectToAdd = new Task { Title = taskTitle };
                dbContext.Tasks.Add(objectToAdd);
                dbContext.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] bool done)
        {
            using (var dbContext = new TasksDatabaseContext())
            {
                Task objectToUpdate = dbContext.Tasks.FirstOrDefault(t => t.ID == id);
                objectToUpdate.Done = done;
                dbContext.SaveChanges();
            }
        }
    }
}
