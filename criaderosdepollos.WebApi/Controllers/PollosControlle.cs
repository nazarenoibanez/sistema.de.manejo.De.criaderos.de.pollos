using AutoMapper;
using CriaderosDePollos.Application;
using CriaderosDePollos.Application.Dtos.Galpones;
using CriaderosDePollos.Application.Dtos.Pollos;
using CriaderosDePollos.Entities;
using CriaderosDePollos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriaderosDePollos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollosControlle : ControllerBase
    {
        private readonly ILogger<PollosControlle> _logger;
        private readonly IStringService _service;
        private readonly IApplication<Pollos> _Pollos;
        private readonly IMapper _mapper;

        public PollosControlle(ILogger<PollosControlle> logger, IStringService service,
            IApplication<Pollos> pollos, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _Pollos = pollos;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_mapper.Map<IList<PollosResponseDto>>(_Pollos.GetAll()));

        }
        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            Pollos galpon = _Pollos.GetById(id.Value);
            if (galpon is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PollosRequestDto>(galpon));

        }
        [HttpPost]
        [Route("Crear")]
        public IActionResult crear(PollosRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pollos = _mapper.Map<Pollos>(request);
            _Pollos.Save(pollos);
            return Ok(pollos.Id);
        }
        [HttpPut]
        [Route("Editar")]
        public IActionResult editar(int? id, PollosRequestDto pollosRequest)
        {
            if (!id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Pollos PollosEdi = _Pollos.GetById(id.Value);
            if (PollosEdi is null)
            {
                return NotFound();
            }
            _mapper.Map(pollosRequest, PollosEdi);
            _Pollos.Save(PollosEdi);
            return Ok();
        }
        [HttpDelete]
        [Route("eliminar")]
        public IActionResult eliminar(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            Pollos pollosEli = _Pollos.GetById(id.Value);
            if (pollosEli is null)
            {
                return NotFound();
            }
            _Pollos.Delete(pollosEli.Id);
            return Ok();
        }
    }
}

