using Microsoft.AspNetCore.Mvc;
using RepositoryUowPattern.API.Data.Repository;

namespace RepositoryUowPattern.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly ILogger<DepartamentoController> _logger;
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(ILogger<DepartamentoController> logger, IDepartamentoRepository departamentoRepository)
        {
            _logger = logger;
            _departamentoRepository = departamentoRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id/*, [FromServices] IDepartamentoRepository repository*/)
        {
            //Exemplo usando [FromService]
            //var departamento = await repository.GetByIdAsync(id);
            //return Ok(departamento);

            var result = await _departamentoRepository.GetByIdAsync(id);
            return Ok(result);
        }
    }
}