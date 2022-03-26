using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiHelpDents.Domain.Entities;
using ApiHelpDents.Domain.Interfaces;
using AutoMapper;
using ApiHelpDents.Domain.Dtos.Requests;
using ApiHelpDents.Domain.Dtos.Responses;

namespace ApiHelpDents.Controller{

    [Route("api/[controller]")]
    [ApiController]

    public class SolicitudController : ControllerBase{

        private readonly IHttpContextAccessor _httpContext;
        private readonly ISolicitudRepository _repository;
        private readonly IMapper _mapper;

        public SolicitudController(IHttpContextAccessor httpContext, ISolicitudRepository repository, IMapper mapper){

            this._httpContext = httpContext;
            this._mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll(){
            var query = await _repository.GetAll();
            var response = _mapper.Map<IEnumerable<Solicitud>, IEnumerable<SolicitudResponse>>(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id){
            var entity = await _repository.GetById(id);
            if(entity == null){
                return NoContent();
            }
            var response = _mapper.Map<Solicitud, SolicitudResponse>(entity);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SolicitudCreateRequest solicitud){
            
            var entity = _mapper.Map<SolicitudCreateRequest, Solicitud>(solicitud);
            var id = await _repository.Create(entity);
            if(id <= 0){
                return Conflict("No se puede realizar el registro");
            }

            var urlresult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/administrador/{id}";
            return Created(urlresult, id);  
        }

        [HttpPut]
        [Route("{id:int}/{estado}")]
        public async Task<IActionResult> Update(int id, string estado){

            if(id <= 0 || !_repository.Exist(i => i.IdSolicitud == id))
                return NotFound("El registro no fué encontrado, veifica tu información...");

            var update = await _repository.Update(id, estado);

            if(!update)
                return Conflict("Ocurrió un fallo al intentar realizar la modificación...");

            return Ok("Se han actualizado los datos correctamente...");

        }
    }
}