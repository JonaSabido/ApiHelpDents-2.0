using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiHelpDents.Data;
using ApiHelpDents.Domain.Interfaces;
using AutoMapper;
using ApiHelpDents.Domain.Dtos.Requests;
using ApiHelpDents.Domain.Entities;

namespace ApiHelpDents.Controller{

    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase{

        private readonly IHttpContextAccessor _httpContext;
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public LoginController (IHttpContextAccessor httpContext, IUsuarioRepository repository, IMapper mapper){
            
            this._httpContext = httpContext;
            this._mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] RequestLogin login){

            TokenClass tokenClass = new TokenClass();

            var entity = await _repository.GetByCorreo(login.Correo);
            if(entity == null){
                return StatusCode(401);
            }
            bool credentials = entity.Contraseña.Equals(login.Contraseña);
            if(!credentials){
                return StatusCode(401);
            }
            tokenClass.TokenOrMessage = TokenManager.GenerateToken(login.Correo);
            string token = tokenClass.TokenOrMessage;
            entity.Token = token;
            await _repository.Update(entity.IdUsuario, entity);
            var respuesta = _mapper.Map<Usuario,LoginResponse>(entity);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ValidateToken/{token}")]
        public async Task<IActionResult> Validate(string token){
            
            var usuario = TokenManager.ValidateToken(token);

            if(usuario != null){
                var entity = await _repository.GetByCorreo(usuario);
                var response = _mapper.Map<Usuario,LoginResponse>(entity);
                return Ok(response);
            }
            else{
                return StatusCode(401);
            }
        }

    }
}