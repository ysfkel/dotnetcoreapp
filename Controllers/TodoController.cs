using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using yoasp.Models;

namespace yoasp.Controllers
{
    [Route("api/[controller]")]
    public class TodoController:Controller
    {
        private ITodoRepository repo;
        
        public TodoController(ITodoRepository repo)
        {
            this.repo=repo;
        }
        
        public IEnumerable<TodoItem>GetAll()
        {
            return repo.GetAll();
        }
        
        [HttpGet("{id}",Name="GetTodo")]
        public IActionResult GetById(string id)
        {
            var item=repo.Find(id);
            if(item==null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if(item==null)
            {
                return BadRequest();
            }
            repo.Add(item);
            return CreatedAtRoute("GetTodo",new {
                id=item.Key
            },item);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(string id,[FromBody]TodoItem item)
        {
            if(ItemDoesNotExists(item,id))
            {
                return BadRequest();
            }
            
            var todo=repo.Find(id);
            if(todo==null)
            {
                return NotFound();
            }
            
            repo.Update(item);
            return new NoContentResult();
            
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo=repo.Find(id);
            if(todo==null)
            {
                return BadRequest();
            }
            repo.Remove(id);
            return new NoContentResult();
        }
        
        private bool ItemDoesNotExists(TodoItem item,string id)
        {
            return item==null || item.Key!=id;
        }
    }
}