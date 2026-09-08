using AutoMapper;
using CriaderosDePollos.Application;
using CriaderosDePollos.Application.Dtos.RetiroDePollos;
using CriaderosDePollos.Application.Dtos.Trabajador;
using CriaderosDePollos.Entities;
using CriaderosDePollos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriaderosDePollos.WebApi.Controllers
{
    public class TrabajadorController:ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class LogeoEmpleadoController : ControllerBase
        {
            private readonly ILogger<TrabajadorController> _logger;
            private readonly IStringService _service;
            private readonly IApplication<trabajador> _trabajoApp;
            private readonly IMapper _mapper;

            public LogeoEmpleadoController(ILogger<TrabajadorController> logger, IStringService service, IApplication<trabajador> trabajoApp, IMapper mapper)
            {
                _logger = logger;
                _service = service;
                _trabajoApp = trabajoApp;
                _mapper = mapper;
            }

            [HttpGet]
            [Route("All")]
            public IActionResult All()
            {
                return Ok(_mapper.Map<IList<TrabajadorResponseDto>>(_trabajoApp.GetAll()));
            }

            [HttpGet]
            [Route("ById")]
            public IActionResult ById(int? id)
            {
                if (!id.HasValue) return BadRequest();

                var logeo = _trabajoApp.GetById(id.Value);
                if (logeo is null) return NotFound();

                return Ok(_mapper.Map<TrabajadorResponseDto>(logeo));
            }

            [HttpPost]
            [Route("Registrar")]
            public IActionResult Crear(TrabajadorRequestDto request)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var nuevoTrabajador = _mapper.Map<trabajador>(request);
                _trabajoApp.Save(nuevoTrabajador);

                return Ok(nuevoTrabajador.Id);
            }

            [HttpPut]
            [Route("RegistrarSalida")]
            public IActionResult RegistrarSalida(int id)
            {
                var logeo = _trabajoApp.GetById(id);
                if (logeo is null) return NotFound("El registro de ingreso no existe.");

                logeo.FechaSalida = DateTime.Now;
                _trabajoApp.Save(logeo);

                return Ok();
            }
        }
    }
}

