using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiHelpDents.Domain.Entities;
using ApiHelpDents.Infraestructure.Repositories;
using ApiHelpDents.Domain.Interfaces;
using Microsoft.Extensions.Options;
using AutoMapper;
using ApiHelpDents.Domain.Dtos.Requests;
using ApiHelpDents.Domain.Dtos.Responses;

namespace ApiHelpDents.Controller{

    [Route("api/[controller]")]
    [ApiController]

    public class AsesorTurnoController : ControllerBase{

        private readonly IHttpContextAccessor _httpContext;
        private readonly IAsesorHasTurnoRepository _repository;
        private readonly IMapper _mapper;

        public AsesorTurnoController (IHttpContextAccessor httpContext, IAsesorHasTurnoRepository repository, IMapper mapper){
            
            this._httpContext = httpContext;
            this._mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll(){

            var query = await _repository.GetAll();
            var response = _mapper.Map<IEnumerable<AsesorHasTurno>, IEnumerable<AsesorTurnoResponse>>(query);
            return Ok(response);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id){

            var esp = await _repository.GetById(id);
            var respuesta = _mapper.Map<AsesorHasTurno,AsesorTurnoResponse>(esp);
            if(respuesta == null){
                return NoContent();
            }

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AsesorTurnoCreateRequest esp){
            
            var entity = _mapper.Map<AsesorTurnoCreateRequest, AsesorHasTurno>(esp);
            var id = await _repository.Create(entity);
            if(id <= 0){
                return Conflict("No se puede realizar el registro");
            }

            return Ok();
            
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id){

            if(id <= 0 || !_repository.Exist(i => i.Id == id))
                return NotFound("El registro no fu?? encontrado, veifica tu informaci??n...");

            var delete = await _repository.Delete(id);

            if(!delete)
                return Conflict("Ocurri?? un fallo al intentar eliminar el registro...");

            return Ok("Se ha eliminado el registro correctamente...");

        }
    }

}