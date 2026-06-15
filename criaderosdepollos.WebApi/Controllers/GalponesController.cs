using AutoMapper;
using CriaderosDePollos.Application;
using CriaderosDePollos.Application.Dtos.Galpones;
using CriaderosDePollos.Entities;
using CriaderosDePollos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriaderosDePollos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalponesController : ControllerBase
    {
        private readonly ILogger<GalponesController> _logger;
        private readonly IStringService _service;
        private readonly IApplication<Galpones> _Galpones;
        private readonly IMapper _mapper;
       

        public GalponesController(ILogger<GalponesController> logger, IApplication<Galpones> application, IMapper mapper, IStringService service)
        {
            _logger = logger;
            _Galpones = application;
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult All()
        {
            return Ok(_mapper.Map<IList<GalponesResponseDto>>(_Galpones.GetAll()));

        }
        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            Galpones galpon = _Galpones.GetById(id.Value);
            if (galpon is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GalponesResponseDto>(galpon));

        }
        [HttpPost]
        public IActionResult crear(GalponesRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var galpon = _mapper.Map<Galpones>(request);
            _Galpones.Save(galpon);
            return Ok(galpon.Id);
        }
        [HttpPut]
        public IActionResult editar(int? id, GalponesRequestDto galponesRequest)
        {
            if (!id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Galpones galponEdi = _Galpones.GetById(id.Value);
            if (galponEdi is null)
            {
                return NotFound();
            }
            _mapper.Map(galponesRequest, galponEdi);
            _Galpones.Save(galponEdi);
            return Ok();
        }
        [HttpDelete]
        public IActionResult eliminar(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            Galpones galponEli = _Galpones.GetById(id.Value);
            if (galponEli is null)
            {
                return NotFound();
            }
            _Galpones.Delete(galponEli.Id);
            return Ok();
        }
    }
}
