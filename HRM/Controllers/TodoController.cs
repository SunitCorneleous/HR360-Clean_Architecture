using Microsoft.AspNetCore.Mvc;
using Application.Service;

namespace HRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _service;

        public TodoController(TodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _service.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] string title)
        {
            var id = await _service.AddTodoAsync(title);
            return Ok(new { Id = id, Title = title, IsCompleted = false });
        }
    }
}
