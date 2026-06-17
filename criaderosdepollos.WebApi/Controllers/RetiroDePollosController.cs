using AutoMapper;
using CriaderosDePollos.Application;
using CriaderosDePollos.Application.Dtos.RetiroDePollos;
using CriaderosDePollos.Entities;
using CriaderosDePollos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriaderosDePollos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetiroDePollosController : ControllerBase
    {
        private readonly ILogger<RetiroDePollosController> _logger;
        private readonly IStringService _service;
        private readonly IApplication<RetiroDePollos> _retiroApp;
        private readonly IMapper _mapper;

        public RetiroDePollosController(IApplication<RetiroDePollos> application, IMapper mapper,
            ILogger<RetiroDePollosController> logger, IStringService service)
        {
            _retiroApp = application;
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_mapper.Map<IList<RetiroDePollosResponseDto>>(_retiroApp.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? id)
        {
            if (!id.HasValue) return BadRequest();

            RetiroDePollos retiro = _retiroApp.GetById(id.Value);
            if (retiro is null) return NotFound();

            return Ok(_mapper.Map<RetiroDePollosResponseDto>(retiro));
        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear(RetiroDePollosRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nuevoRetiro = _mapper.Map<RetiroDePollos>(request);
            _retiroApp.Save(nuevoRetiro);

            return Ok(nuevoRetiro.Id);
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar(int? id, RetiroDePollosRequestDto request)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            RetiroDePollos retiroExistente = _retiroApp.GetById(id.Value);
            if (retiroExistente is null) return NotFound();

            _mapper.Map(request, retiroExistente);
            _retiroApp.Save(retiroExistente);

            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(int? id)
        {
            if (!id.HasValue) return BadRequest();

            RetiroDePollos retiroExistente = _retiroApp.GetById(id.Value);
            if (retiroExistente is null) return NotFound();

            _retiroApp.Delete(retiroExistente.Id);
            return Ok();
        }
    }
}
