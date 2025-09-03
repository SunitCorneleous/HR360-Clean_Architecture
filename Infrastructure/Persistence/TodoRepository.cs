using Application.Interfaces;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Infrastructure.Persistence
{
    public class TodoRepository : ITodoRepository
    {
        // in-memory dummy storage
        private static readonly List<TodoItem> _todos = new()
        {
            new TodoItem { Id = 1, Title = "Learn Clean Architecture", IsCompleted = false },
            new TodoItem { Id = 2, Title = "Build a ToDo API", IsCompleted = true }
        };

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await Task.FromResult(_todos);
        }

        public async Task<int> AddAsync(string title)
        {
            var newId = _todos.Any() ? _todos.Max(t => t.Id) + 1 : 1;

            var todo = new TodoItem
            {
                Id = newId,
                Title = title,
                IsCompleted = false
            };

            _todos.Add(todo);

            return await Task.FromResult(newId);
        }
    }
}
