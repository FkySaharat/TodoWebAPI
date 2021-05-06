using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Data;

namespace TodoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoPriorityTypesController : ControllerBase
    {
        private readonly TodoWebAPIContext _context;

        public TodoPriorityTypesController(TodoWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/TodoPriorityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoPriorityType>>> GetTodoPriorityType()
        {
            return await _context.TodoPriorityType.ToListAsync();
        }

        // GET: api/TodoPriorityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoPriorityType>> GetTodoPriorityType(int id)
        {
            var todoPriorityType = await _context.TodoPriorityType.FindAsync(id);

            if (todoPriorityType == null)
            {
                return NotFound();
            }

            return todoPriorityType;
        }

        // PUT: api/TodoPriorityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoPriorityType(int id, TodoPriorityType todoPriorityType)
        {
            if (id != todoPriorityType.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoPriorityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoPriorityTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoPriorityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoPriorityType>> PostTodoPriorityType(TodoPriorityType todoPriorityType)
        {
            _context.TodoPriorityType.Add(todoPriorityType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoPriorityType", new { id = todoPriorityType.Id }, todoPriorityType);
        }

        // DELETE: api/TodoPriorityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoPriorityType(int id)
        {
            var todoPriorityType = await _context.TodoPriorityType.FindAsync(id);
            if (todoPriorityType == null)
            {
                return NotFound();
            }

            _context.TodoPriorityType.Remove(todoPriorityType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoPriorityTypeExists(int id)
        {
            return _context.TodoPriorityType.Any(e => e.Id == id);
        }
    }
}
