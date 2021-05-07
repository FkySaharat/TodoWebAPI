using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWebAPI.Controllers;
using TodoWebAPI.Data;
using TodoWebAPI.Services;
using Xunit;
using System.Linq;

namespace ApiTest
{
    public class TodoServiceTest
    {
            
  

        [Fact]
        public async Task Get_TodoItems_Complete()
        {
            var dbContext = DbMock.CreateTestingDatabase(nameof(Get_TodoItems_Complete));
            var mockTodoes = new List<TodoItem>(){
                new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Title ="Test1",
                },
                 new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Title ="Test2",
                }
            };

            dbContext.Seed(mockTodoes);
            var service = new TodoService(dbContext);
            var result = await service.GetTodoItems();
            //release the allocated memory
            dbContext.Dispose();

            Assert.NotEmpty(result);
            Assert.IsType<List<TodoItem>>(result);
            Assert.Equal(mockTodoes, result);
        }

        [Fact]
        public async Task Get_TodoItems_NotFound()
        {
            var dbContext = DbMock.CreateTestingDatabase(nameof(Get_TodoItems_NotFound));
            var service = new TodoService(dbContext);
            var result = await service.GetTodoItems();
            //release the allocated memory
            dbContext.Dispose();
            Assert.Empty(result);
        }

        [Fact]
        public async Task Get_TodoItem_Complete()
        {
            var dbContext = DbMock.CreateTestingDatabase(nameof(Get_TodoItem_Complete));
            var mockTodoes = new List<TodoItem>(){
                new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Title ="Test1",
                },
                 new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Title ="Test2",
                }
            };

            dbContext.Seed(mockTodoes);
            var service = new TodoService(dbContext);
            var result = await service.GetTodoItem(mockTodoes.First().Id);
            //release the allocated memory
            dbContext.Dispose();
            Assert.NotNull(result);
            Assert.IsType<TodoItem>(result);
        }

        [Fact]
        public async Task Get_TodoItem_NotFound()
        {
            var dbContext = DbMock.CreateTestingDatabase(nameof(Get_TodoItem_NotFound));
            
            var service = new TodoService(dbContext);
            var result = await service.GetTodoItem(Guid.NewGuid());
            //release the allocated memory
            dbContext.Dispose();
            Assert.Null(result);
        }

    }
}
