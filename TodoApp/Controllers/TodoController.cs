using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TodoController(TodoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos([FromQuery] TodoStatus? status)
        {
            var query = _context.Todos.AsQueryable();
            if (status.HasValue)
            {
                query = query.Where(t => t.Status == status);
            }
            return Ok(await query.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] Todo todo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            todo.CreatedDate = DateTime.UtcNow;
            todo.LastModifiedDate = DateTime.UtcNow;
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] Todo updated)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return NotFound();

            todo.Title = updated.Title;
            todo.Description = updated.Description;
            todo.Status = updated.Status;
            todo.Priority = updated.Priority;
            todo.DueDate = updated.DueDate;
            todo.LastModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return NotFound();

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> MarkAsComplete(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return NotFound();

            todo.Status = TodoStatus.Completed;
            todo.LastModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}