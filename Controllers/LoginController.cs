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
                tokenClass.TokenOrMessage = "Esta cuenta no existe";
                return Ok(tokenClass);
            }
            bool credentials = entity.Contraseña.Equals(login.Contraseña);
            if(!credentials){
                tokenClass.TokenOrMessage = "Contraseña incorrecta";
                return Ok(tokenClass);
            }
            tokenClass.TokenOrMessage = TokenManager.GenerateToken(login.Correo);
            return Ok(tokenClass);
        }
    }
}