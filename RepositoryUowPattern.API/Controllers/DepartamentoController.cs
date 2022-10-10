using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryUowPattern.API.Data;
using RepositoryUowPattern.API.Models;

namespace RepositoryUowPattern.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly ILogger<DepartamentoController> _logger;
        //private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IUnitOfWork _uow;

        public DepartamentoController(ILogger<DepartamentoController> logger,
            /*IDepartamentoRepository departamentoRepository, */IUnitOfWork uow)
        {
            //_departamentoRepository = departamentoRepository;
            _logger = logger;
            _uow = uow;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id/*, [FromServices] IDepartamentoRepository repository*/)
        {
            //Exemplo usando [FromService]
            //var departamento = await repository.GetByIdAsync(id);
            //return Ok(departamento);

            //var result = await _departamentoRepository.GetByIdAsync(id);
            var result = await _uow.DepartamentoRepository.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDepartamento(Departamento departamento)
        {
            //_departamentoRepository.Add(departamento);
            _uow.DepartamentoRepository.Add(departamento);
            //var save = _departamentoRepository.Save();

            _uow.Commit();

            return Ok(departamento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDepartamento(int id)
        {
            var departamento = await _uow.DepartamentoRepository.GetByIdAsync(id);

            _uow.DepartamentoRepository.Delete(departamento);

            _uow.Commit();

            return Ok(departamento);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartamentoAsync([FromQuery] string descricao)
        {
            var departamentos = await _uow.DepartamentoRepository
                .GetDataAsync(departamento => departamento.Descricao.Contains(descricao),
                departamentos => departamentos.Include(lbda => lbda.Colaboradores),
                take: 2);

            return Ok(departamentos);
        }
    }
}