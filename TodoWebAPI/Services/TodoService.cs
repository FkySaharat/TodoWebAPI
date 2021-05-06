using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWebAPI.Data;
using TodoWebAPI.Services.Interfaces;

namespace TodoWebAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoWebAPIContext _context;
        public TodoService(TodoWebAPIContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> CreateItem(TodoItem item)
        { 
      
            _context.Add(item);
           await _context.SaveChangesAsync();
           
           
            return item;
        }

        public async Task<TodoItem> DeleteItem(Guid id)
        {
            var todo = _context.TodoItem.Find(id);
            _context.Remove(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<TodoItem> GetTodoItem(Guid id)
        {
            var todo = await _context.TodoItem.FindAsync(id);

            if(todo == null)
            {
                return null;
            }

            return todo;
             
        }

        public async Task<List<TodoItem>> GetTodoItems()
        {
            var todoes = await _context.TodoItem.ToListAsync();
            if (todoes == null)
            {
                return null;
            }
            return todoes;
        }

        public async Task<TodoItem> UpdateItem(Guid id, TodoItem updateItem)
        {
     
            var todo =  _context.TodoItem.First(el => el.Id ==id);
            if(todo != null){
                todo.Title = updateItem.Title;
                todo.priorityType = updateItem.priorityType;
                todo.status = updateItem.status;
                await _context.SaveChangesAsync();
            }
          
            return todo;
        }

        public bool TodoItemExists(Guid id)
        {
            return _context.TodoItem.Any(e => e.Id == id);
        }
    }
}
