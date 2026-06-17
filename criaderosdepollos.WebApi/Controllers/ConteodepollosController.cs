using AutoMapper;
using CriaderoDePollos.Entities;
using CriaderosDePollos.Application;
using CriaderosDePollos.Application.Dtos.ConteoDePollos;
using CriaderosDePollos.Application.Dtos.Galpones;
using CriaderosDePollos.Entities;
using CriaderosDePollos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriaderosDePollos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteodepollosController : ControllerBase
    {
        private readonly ILogger<ConteodepollosController> _logger;
        private readonly IStringService _service;
        private readonly IApplication<Conteodepollos> _conteoDePollo;
        private readonly IMapper _mapper;

        public ConteodepollosController(IApplication<Conteodepollos> application, IMapper mapper,
            ILogger<ConteodepollosController> logger, IStringService service)
        {
            _conteoDePollo = application;
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_mapper.Map<IList<ConteodepollosRequestDto>>(_conteoDePollo.GetAll()));

        }

        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? id)
        {
            if (!id.HasValue) return BadRequest();

            Conteodepollos conteo = _conteoDePollo.GetById(id.Value);
            if (conteo is null) return NotFound();

            return Ok(_mapper.Map<ConteodepollosResponseDto>(conteo));
        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear(ConteodepollosRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nuevoConteo = _mapper.Map<Conteodepollos>(request);
            _conteoDePollo.Save(nuevoConteo);

            return Ok(nuevoConteo.Id);
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar(int? id, ConteodepollosRequestDto request)
        {
            if (!id.HasValue) return BadRequest("ID requerido.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Conteodepollos conteoExistente = _conteoDePollo.GetById(id.Value);
            if (conteoExistente is null) return NotFound("El registro a editar no existe.");

            _mapper.Map(request, conteoExistente);
            _conteoDePollo.Save(conteoExistente);

            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(int? id)
        {
            if (!id.HasValue) return BadRequest("ID requerido.");

            Conteodepollos conteoExistente = _conteoDePollo.GetById(id.Value);
            if (conteoExistente is null) return NotFound("El registro a eliminar no existe.");

            _conteoDePollo.Delete(conteoExistente.Id);
            return Ok();
        }
    }
}
