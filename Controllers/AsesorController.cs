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

    public class AsesorController : ControllerBase{

        private readonly IHttpContextAccessor _httpContext;
        private readonly IAsesorRepository _repository;
        private readonly IUsuarioRepository _repositoryUser;
        private readonly IEspecialidadRepository _repositoryEsp;
        private readonly ITurnoRepository _repositoryTurno;

        private readonly IAsesorHasEspecialidadRepository _repositoryAHE;
        private readonly IAsesorHasTurnoRepository _repositoryAHT;

        private readonly IMapper _mapper;

        public AsesorController(IHttpContextAccessor httpContext, IAsesorRepository repository, 
                                IUsuarioRepository repositoryUser, IEspecialidadRepository repositoryEsp, 
                                ITurnoRepository repositoryTurno, IAsesorHasEspecialidadRepository repositoryAHE, IAsesorHasTurnoRepository repositoryAHT, 
                                IMapper mapper){
            
            this._httpContext = httpContext;
            this._mapper = mapper;
            _repository = repository;
            _repositoryUser = repositoryUser;
            _repositoryEsp = repositoryEsp;
            _repositoryTurno = repositoryTurno;
            _repositoryAHE = repositoryAHE;
            _repositoryAHT = repositoryAHT;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll(){

            var query = await _repository.GetAll();

            foreach(var entity in query){
                
                
                Usuario usuario = await _repositoryUser.GetById(entity.UsuarioIdUsuario);

                entity.UsuarioIdUsuarioNavigation.Nombre = usuario.Nombre;
                entity.UsuarioIdUsuarioNavigation.Apellido = usuario.Apellido;
                

                
            }
            
            var response = _mapper.Map<IEnumerable<Asesor>, IEnumerable<AsesorResponse>>(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id){

            var entity = await _repository.GetById(id);
            
            if(entity == null){
                return NoContent();
            }

            var usuario = await _repositoryUser.GetById(entity.UsuarioIdUsuario);

            entity.UsuarioIdUsuarioNavigation.Nombre = usuario.Nombre;
            entity.UsuarioIdUsuarioNavigation.Apellido = usuario.Apellido;

            var respuesta = _mapper.Map<Asesor,AsesorResponse>(entity);

            return Ok(respuesta);
        }

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> Filter(int? idEspecialidad, int? idTurno, double? Costo){

            FilterAsesor fa = new FilterAsesor();
            fa.idEspecialidad = idEspecialidad;
            fa.idTurno = idTurno;
            fa.Costo = Costo;


            var query = await _repository.GetByFilter(fa);
            
            
            foreach(var entity in query){
            
                var u = await _repositoryUser.GetById(entity.UsuarioIdUsuario);
                entity.UsuarioIdUsuarioNavigation = u;
                
            }

            

            var response = _mapper.Map<IEnumerable<Asesor>,IEnumerable<AsesorResponse>>(query);    
            return Ok(response);
        }
        /*
        [HttpGet]
        [Route("search/filters")]
        public async Task<IActionResult> GetByFilter([FromBody] AsesorFilterRequest asesor)
        {
            var entity = _mapper.Map<AsesorFilterRequest, Asesor>(asesor);
            var query = await _repository.GetByFilter(entity);
            
            
            if(query.Count() == 0){
                return NoContent();
            }

            foreach(var entity1 in query){
                
                
                Usuario usuario = await _repositoryUser.GetById(entity1.ClaveUsuario);
                Especialidad esp = await _repositoryEsp.GetById(entity1.ClaveEsp);
                Turno turno = await _repositoryTurno.GetById(entity1.ClaveTurno);

                entity1.ClaveUsuarioNavigation.Nombres = usuario.Nombres;
                entity1.ClaveUsuarioNavigation.Apellidos = usuario.Apellidos;
                entity1.ClaveTurnoNavigation.NombreTurno = turno.NombreTurno;
                entity1.ClaveEspNavigation.NombreEsp = esp.NombreEsp;

                
            }

            var response = _mapper.Map<IEnumerable<Asesor>,IEnumerable<AsesorResponse>>(query);      
            return Ok(response);
        }
        */

        [HttpGet]
        [Route("search/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var query = await _repository.GetByName(name);
            
            

            foreach(var entity in query){
                
                
                Usuario usuario = await _repositoryUser.GetById(entity.UsuarioIdUsuario);
                

                entity.UsuarioIdUsuarioNavigation.Nombre = usuario.Nombre;
                entity.UsuarioIdUsuarioNavigation.Apellido = usuario.Apellido;
                

                
            }
            var response = _mapper.Map<IEnumerable<Asesor>,IEnumerable<AsesorResponse>>(query);       
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AsesorCreateRequest asesor){
            
            var entity = _mapper.Map<AsesorCreateRequest, Asesor>(asesor);
            var id = await _repository.Create(entity);
            if(id <= 0){
                return Conflict("No se puede realizar el registro");
            }

            var urlresult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/administrador/{id}";
            return Created(urlresult, id);
            
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update(int id, [FromBody]AsesorUpdateRequest asesor){

            if(id <= 0 || !_repository.Exist(i => i.IdAsesor == id))
                return NotFound("El registro no fué encontrado, veifica tu información...");

            var entity = _mapper.Map<AsesorUpdateRequest, Asesor>(asesor);
            var update = await _repository.Update(id, entity);

            if(!update)
                return Conflict("Ocurrió un fallo al intentar realizar la modificación...");

            return Ok("Se han actualizado los datos correctamente...");

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id){

            if(id <= 0 || !_repository.Exist(i => i.IdAsesor == id))
                return NotFound("El registro no fué encontrado, veifica tu información...");

            var delete = await _repository.Delete(id);

            if(!delete)
                return Conflict("Ocurrió un fallo al intentar eliminar el registro...");

            return Ok("Se ha eliminado el registro correctamente...");

        }
    }

}