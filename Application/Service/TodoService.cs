using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class TodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<int> AddTodoAsync(string title)
        {
            return _repository.AddAsync(title);
        }
    }
}
