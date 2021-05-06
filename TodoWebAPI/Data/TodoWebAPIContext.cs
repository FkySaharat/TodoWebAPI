using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Data;

namespace TodoWebAPI.Data
{
    public class TodoWebAPIContext : DbContext
    {
        public TodoWebAPIContext (DbContextOptions<TodoWebAPIContext> options)
            : base(options)
        {
        }
        

        public DbSet<TodoWebAPI.Data.TodoItem> TodoItem { get; set; }

        public DbSet<TodoWebAPI.Data.TodoPriorityType> TodoPriorityType { get; set; }
    }
}
