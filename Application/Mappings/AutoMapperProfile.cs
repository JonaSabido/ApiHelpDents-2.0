using System.Reflection.Metadata.Ecma335;
using System;
using AutoMapper;
using ApiHelpDents.Domain.Dtos.Responses;
using ApiHelpDents.Domain.Dtos.Requests;
using ApiHelpDents.Domain.Entities;

namespace ApiHelpDents.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){

            //Responses
            CreateMap<Administrador, AdminResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdAdministrador))
            .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Apellido))
            .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
            .ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña));

            
            CreateMap<Asesor, AsesorResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdAsesor))
            .ForMember(dest => dest.UsuarioIdUsuario, opt => opt.MapFrom(src => src.UsuarioIdUsuario))
            .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.UsuarioIdUsuarioNavigation.Nombre))
            .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.UsuarioIdUsuarioNavigation.Apellido))
            .ForMember(dest => dest.Costo, opt => opt.MapFrom(src => src.Costo))
            .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono))
            .ForMember(dest => dest.Facebook, opt => opt.MapFrom(src => src.Facebook))
            .ForMember(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram))
            .ForMember(dest => dest.Youtube, opt => opt.MapFrom(src => src.YouTube))
            .ForMember(dest => dest.Linkendin, opt => opt.MapFrom(src => src.Linkendin))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion));

            CreateMap<Comentario, ComentarioResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdComentario))
            .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.UsuarioIdUsuarioNavigation.Nombre))
            .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.UsuarioIdUsuarioNavigation.Apellido))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion));

            CreateMap<Comentario, ComentarioResponse2>()
            .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.UsuarioIdUsuarioNavigation.Nombre))
            .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.UsuarioIdUsuarioNavigation.Apellido))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion));

            CreateMap<Especialidad, EspecialidadResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdEspecialidad))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre));

            CreateMap<Turno, TurnoResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdTurno))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre));

            CreateMap<Usuario, UsuarioResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdUsuario))
            .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Apellido))
            .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
            .ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña));

            CreateMap<AsesorHasEspecialidad, AsesorEspResponse>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Asesor_idAsesor, opt => opt.MapFrom(src => src.AsesorIdAsesor))
            .ForMember(dest => dest.Especialidad_idEspecialidad, opt => opt.MapFrom(src => src.EspecialidadIdEspecialidad));

            CreateMap<AsesorHasComentario, AsesorComResponse>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Asesor_idAsesor, opt => opt.MapFrom(src => src.AsesorIdAsesor))
            .ForMember(dest => dest.Comentario_idComentario, opt => opt.MapFrom(src => src.ComentarioIdComentario));

            CreateMap<AsesorHasTurno, AsesorTurnoResponse>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Asesor_idAsesor, opt => opt.MapFrom(src => src.AsesorIdAsesor))
            .ForMember(dest => dest.Turno_idTurno, opt => opt.MapFrom(src => src.TurnoIdTurno));


            //Creates
            CreateMap<AdminCreateRequest, Administrador>()
            .ForPath(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombres))
            .ForPath(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellidos))
            .ForPath(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
            .ForPath(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña));

            CreateMap<AsesorCreateRequest, Asesor>()
            .ForPath(dest => dest.UsuarioIdUsuario, opt => opt.MapFrom(src => src.UsuarioIdUsuario))
            .ForPath(dest => dest.Costo, opt => opt.MapFrom(src => src.Costo))
            .ForPath(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono))
            .ForPath(dest => dest.Facebook, opt => opt.MapFrom(src => src.Facebook))
            .ForPath(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram))
            .ForPath(dest => dest.YouTube, opt => opt.MapFrom(src => src.Youtube))
            .ForPath(dest => dest.Linkendin, opt => opt.MapFrom(src => src.Linkendin))
            .ForPath(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion));

            
            CreateMap<AsesorFilterRequest, FilterAsesor>()
            .ForPath(dest => dest.idEspecialidad, opt => opt.MapFrom(src => src.idEspecialidad))
            .ForPath(dest => dest.idTurno, opt => opt.MapFrom(src => src.idTurno))
            .ForPath(dest => dest.Costo, opt => opt.MapFrom(src => src.Costo));

            CreateMap<ComentarioCreateRequest, Comentario>()
            .ForPath(dest => dest.UsuarioIdUsuario, opt => opt.MapFrom(src => src.ClaveUsuario))
            .ForPath(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion));
            
            CreateMap<EspecialidadCreateRequest, Especialidad>()
            .ForPath(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre));

            CreateMap<TurnoCreateRequest, Turno>()
            .ForPath(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreTurno));
            
            CreateMap<UsuarioCreateRequest, Usuario>()
            .ForPath(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombres))
            .ForPath(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellidos))
            .ForPath(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
            .ForPath(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña));

            CreateMap<AsesorEspCreateRequest, AsesorHasEspecialidad>()
            .ForPath(dest => dest.AsesorIdAsesor, opt => opt.MapFrom(src => src.Asesor_idAsesor))
            .ForPath(dest => dest.EspecialidadIdEspecialidad, opt => opt.MapFrom(src => src.Especialidad_idEspecialidad));

            CreateMap<AsesorComCreateRequest, AsesorHasComentario>()
            .ForPath(dest => dest.AsesorIdAsesor, opt => opt.MapFrom(src => src.Asesor_idAsesor))
            .ForPath(dest => dest.ComentarioIdComentario, opt => opt.MapFrom(src => src.Comentario_idComentario));

            CreateMap<AsesorTurnoCreateRequest, AsesorHasTurno>()
            .ForPath(dest => dest.AsesorIdAsesor, opt => opt.MapFrom(src => src.Asesor_idAsesor))
            .ForPath(dest => dest.TurnoIdTurno, opt => opt.MapFrom(src => src.Turno_idTurno));

            //Updates
            CreateMap<AdminUpdateRequest, Administrador>()
            .ForPath(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombres))
            .ForPath(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellidos))
            .ForPath(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
            .ForPath(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña));

            CreateMap<AsesorUpdateRequest, Asesor>()
            
            .ForPath(dest => dest.Costo, opt => opt.MapFrom(src => src.Costo))
            .ForPath(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono))
            .ForPath(dest => dest.Facebook, opt => opt.MapFrom(src => src.Facebook))
            .ForPath(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram))
            .ForPath(dest => dest.YouTube, opt => opt.MapFrom(src => src.Youtube))
            .ForPath(dest => dest.Linkendin, opt => opt.MapFrom(src => src.Linkendin))
            .ForPath(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion));

            CreateMap<UsuarioUpdateRequest, Usuario>()
            .ForPath(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombres))
            .ForPath(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellidos))
            .ForPath(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
            .ForPath(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña));
            

            
        }
    }
}