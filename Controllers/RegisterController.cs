using System.Net.Http.Headers;
using System.Xml;
using System.Reflection.Metadata;
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

    public class RegisterController : ControllerBase{

        private readonly IHttpContextAccessor _httpContext;
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public RegisterController(IHttpContextAccessor httpContext, IUsuarioRepository repository, IMapper mapper){
            
            this._httpContext = httpContext;
            this._mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Register ([FromBody] UsuarioCreateRequest usuario){

            var entity = _mapper.Map<UsuarioCreateRequest, Usuario>(usuario);
            entity.RolIdRol = 3;
            var id = await _repository.Create(entity);
            if(id <= 0){
                return Conflict("No se puede realizar el registro");
            }

            return Ok();
        }
    }
}