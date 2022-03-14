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

    public class AsesorEspecialidadController : ControllerBase{

        private readonly IHttpContextAccessor _httpContext;
        private readonly IAsesorHasEspecialidadRepository _repository;
        private readonly IMapper _mapper;

        public AsesorEspecialidadController (IHttpContextAccessor httpContext, IAsesorHasEspecialidadRepository repository, IMapper mapper){
            
            this._httpContext = httpContext;
            this._mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll(){

            var query = await _repository.GetAll();
            var response = _mapper.Map<IEnumerable<AsesorHasEspecialidad>, IEnumerable<AsesorEspResponse>>(query);
            return Ok(response);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id){

            var esp = await _repository.GetById(id);
            var respuesta = _mapper.Map<AsesorHasEspecialidad,AsesorEspResponse>(esp);
            if(respuesta == null){
                return NoContent();
            }

            return Ok(respuesta);
        }

        [HttpGet]
        [Route("esp/{id:int}")]
        public async Task<IActionResult> GetByIdEspecialidad(int id){

            var esp = await _repository.GetByEspecialidadId(id);
            var respuesta = _mapper.Map<IEnumerable<AsesorHasEspecialidad>, IEnumerable<AsesorEspResponse>> (esp);
            if(respuesta == null){
                return NoContent();
            }

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AsesorEspCreateRequest esp){
            
            var entity = _mapper.Map<AsesorEspCreateRequest, AsesorHasEspecialidad>(esp);
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
                return NotFound("El registro no fué encontrado, veifica tu información...");

            var delete = await _repository.Delete(id);

            if(!delete)
                return Conflict("Ocurrió un fallo al intentar eliminar el registro...");

            return Ok("Se ha eliminado el registro correctamente...");

        }
    }

}