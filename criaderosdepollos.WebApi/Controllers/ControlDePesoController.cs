using AutoMapper;
using CriaderosDePollos.Application;
using CriaderosDePollos.Application.Dtos.ControlDePeso;
using CriaderosDePollos.Application.Dtos.Galpones;
using CriaderosDePollos.Entities;
using CriaderosDePollos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriaderosDePollos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlDePesoController: ControllerBase
    {
        private readonly ILogger<ControlDePesoController> _logger;
        private readonly IStringService _service;
        private readonly IApplication<ControlDePeso> _controlPesoApp;
        private readonly IMapper _mapper;

        public ControlDePesoController(IApplication<ControlDePeso> application, IMapper mapper,
            ILogger<ControlDePesoController> logger, IStringService service)
        {
            _controlPesoApp = application;
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_mapper.Map<IList<ControlDePesoResponseDto>>(_controlPesoApp.GetAll()));

        }

        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? id)
        {
            if (!id.HasValue) return BadRequest();

            ControlDePeso registro = _controlPesoApp.GetById(id.Value);
            if (registro is null) return NotFound();

            return Ok(_mapper.Map<ControlDePesoResponseDto>(registro));
        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear(ControlDePesoRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nuevoRegistro = _mapper.Map<ControlDePeso>(request);
            _controlPesoApp.Save(nuevoRegistro);

            return Ok(nuevoRegistro.Id);
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar(int? id, ControlDePesoRequestDto request)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            ControlDePeso registroExistente = _controlPesoApp.GetById(id.Value);
            if (registroExistente is null) return NotFound();

            _mapper.Map(request, registroExistente);
            _controlPesoApp.Save(registroExistente);

            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(int? id)
        {
            if (!id.HasValue) return BadRequest();

            ControlDePeso registroExistente = _controlPesoApp.GetById(id.Value);
            if (registroExistente is null) return NotFound();

            _controlPesoApp.Delete(registroExistente.Id);
            return Ok();
        }
    }
}
