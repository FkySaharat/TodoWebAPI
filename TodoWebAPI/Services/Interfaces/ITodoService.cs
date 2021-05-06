using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWebAPI.Data;

namespace TodoWebAPI.Services.Interfaces
{
    public interface ITodoService
    {
       public Task<List<TodoItem>> GetTodoItems();
       public Task<TodoItem> GetTodoItem(Guid id);
       public Task<TodoItem> UpdateItem(Guid id, TodoItem contract);
       public Task<TodoItem> CreateItem(TodoItem contract);
       public Task<TodoItem> DeleteItem(Guid id);
       public bool TodoItemExists(Guid id);

    }
}
