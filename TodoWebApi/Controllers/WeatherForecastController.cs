using Microsoft.AspNetCore.Mvc;
using Application.Service;

namespace TodoWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TodoService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TodoService todoService)
        {
            _logger = logger;
            _service = todoService;
        }

        [HttpGet("weather", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("todos", Name = "GetAllTodos")]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _service.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpPost("todos", Name = "AddTodo")]
        public async Task<IActionResult> AddTodo([FromBody] string title)
        {
            var todos = await _service.AddTodoAsync(title);
            return Ok(todos);
        }
    }
}
