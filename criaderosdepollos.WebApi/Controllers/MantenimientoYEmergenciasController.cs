using AutoMapper;
using CriaderosDePollos.Application;
using CriaderosDePollos.Application.Dtos.MantenimientoYEmergencias;
using CriaderosDePollos.Entities;
using CriaderosDePollos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriaderosDePollos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoYEmergenciasController: ControllerBase
    {

        private readonly ILogger<MantenimientoYEmergenciasController> _logger;
        private readonly IStringService _service;
        private readonly IApplication<MantenimientoYEmergencias> _mantenimientoApp;
        private readonly IMapper _mapper;

        public MantenimientoYEmergenciasController(IApplication<MantenimientoYEmergencias> application, IMapper mapper,
            ILogger<MantenimientoYEmergenciasController> logger, IStringService service)
        {
            _mantenimientoApp = application;
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_mapper.Map<IList<MantenimientoYEmergenciasResponseDto>>(_mantenimientoApp.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? id)
        {
            if (!id.HasValue) return BadRequest();

            MantenimientoYEmergencias registro = _mantenimientoApp.GetById(id.Value);
            if (registro is null) return NotFound();

            return Ok(_mapper.Map<MantenimientoYEmergenciasResponseDto>(registro));
        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear(MantenimientoYEmergenciasRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nuevoMantenimiento = _mapper.Map<MantenimientoYEmergencias>(request);
            _mantenimientoApp.Save(nuevoMantenimiento);

            return Ok(nuevoMantenimiento.Id);
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar(int? id, MantenimientoYEmergenciasRequestDto request)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            MantenimientoYEmergencias registroExistente = _mantenimientoApp.GetById(id.Value);
            if (registroExistente is null) return NotFound();

            _mapper.Map(request, registroExistente);
            _mantenimientoApp.Save(registroExistente);

            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(int? id)
        {
            if (!id.HasValue) return BadRequest();

            MantenimientoYEmergencias registroExistente = _mantenimientoApp.GetById(id.Value);
            if (registroExistente is null) return NotFound();

            _mantenimientoApp.Delete(registroExistente.Id);
            return Ok();
        }
    }
}
