using AutoMapper;
using CriaderosDePollos.Application;
using CriaderosDePollos.Application.Dtos.RetiroDePollos;
using CriaderosDePollos.Application.Dtos.Trabajador;
using CriaderosDePollos.Entities;
using CriaderosDePollos.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CriaderosDePollos.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        private readonly ILogger<TrabajadorController> _logger;
        private readonly IStringService _service;
        private readonly IApplication<trabajador> _trabajoApp;
        private readonly IMapper _mapper;

        public TrabajadorController(ILogger<TrabajadorController> logger, IStringService service, IApplication<trabajador> trabajoApp, IMapper mapper)
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
        [Route("Editar")]
        public IActionResult Editar(int? id, TrabajadorRequestDto request)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var trabajadorEditar = _trabajoApp.GetById(id.Value);
            if (trabajadorEditar is null) return NotFound();

            _mapper.Map(request, trabajadorEditar);
            _trabajoApp.Save(trabajadorEditar);

            return Ok();
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

        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var trabajadorEliminar = _trabajoApp.GetById(id.Value);
            if (trabajadorEliminar is null) return NotFound();

            _trabajoApp.Delete(trabajadorEliminar.Id);

            return Ok();
        }
    }
}


