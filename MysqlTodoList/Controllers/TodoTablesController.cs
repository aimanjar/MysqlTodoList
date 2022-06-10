using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySQLTodoList.Data;
using MySQLTodoList.Models;

namespace MysqlTodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTablesController : ControllerBase
    {
        private readonly MySQLTodoListContext _context;

        public TodoTablesController(MySQLTodoListContext context)
        {
            _context = context;
        }

        // GET: api/TodoTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTable>>> GetTodoTables()
        {
          if (_context.TodoTables == null)
          {
              return NotFound();
          }
            return await _context.TodoTables.ToListAsync();
        }

        // GET: api/TodoTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTable>> GetTodoTable(int id)
        {
          if (_context.TodoTables == null)
          {
              return NotFound();
          }
            var todoTable = await _context.TodoTables.FindAsync(id);

            if (todoTable == null)
            {
                return NotFound();
            }

            return todoTable;
        }

        // PUT: api/TodoTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoTable(int id, TodoTable todoTable)
        {
            if (id != todoTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoTableExists(id))
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

        // POST: api/TodoTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoTable>> PostTodoTable(TodoTable todoTable)
        {
          if (_context.TodoTables == null)
          {
              return Problem("Entity set 'MySQLTodoListContext.TodoTables'  is null.");
          }
            _context.TodoTables.Add(todoTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TodoTableExists(todoTable.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTodoTable", new { id = todoTable.Id }, todoTable);
        }

        // DELETE: api/TodoTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoTable(int id)
        {
            if (_context.TodoTables == null)
            {
                return NotFound();
            }
            var todoTable = await _context.TodoTables.FindAsync(id);
            if (todoTable == null)
            {
                return NotFound();
            }

            _context.TodoTables.Remove(todoTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoTableExists(int id)
        {
            return (_context.TodoTables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
