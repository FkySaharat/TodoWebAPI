using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebAPI.Data;

namespace ApiTest
{

    public static class DbMockExtension
    {
        public static void Seed(this TodoWebAPIContext context, List<TodoItem> mockTodoes = null)
        {
            if (mockTodoes != null)
            {
                context.TodoItem.AddRange(mockTodoes);
                context.SaveChanges();
            }
        }
    }

    public static class DbMock
    {

        public static TodoWebAPIContext CreateTestingDatabase(string dbName)
        {
            var options = new DbContextOptionsBuilder<TodoWebAPIContext>().UseInMemoryDatabase(databaseName: dbName).Options;

            var dbContext = new TodoWebAPIContext(options);

            return dbContext;
        }
    }

}
