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
            .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioIdUsuario))
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
            .ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña))
            .ForMember(dest => dest.RolIdRol, opt => opt.MapFrom(src => src.RolIdRol));

            CreateMap<Usuario, LoginResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdUsuario))
            .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
            .ForMember(dest => dest.RolIdRol, opt => opt.MapFrom(src => src.RolIdRol))
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token));

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

            CreateMap<Solicitud, SolicitudResponse>()
            .ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
            .ForMember(dest => dest.UsuarioIdUsuario, opt => opt.MapFrom(src => src.UsuarioIdUsuario))
            .ForMember(dest => dest.Especialidad1, opt => opt.MapFrom(src => src.Especialidad1))
            .ForMember(dest => dest.Especialidad2, opt => opt.MapFrom(src => src.Especialidad2))
            .ForMember(dest => dest.Especialidad3, opt => opt.MapFrom(src => src.Especialidad3))
            .ForMember(dest => dest.Turno1, opt => opt.MapFrom(src => src.Turno1))
            .ForMember(dest => dest.Turno2, opt => opt.MapFrom(src => src.Turno2))
            .ForMember(dest => dest.Turno3, opt => opt.MapFrom(src => src.Turno3))
            .ForMember(dest => dest.Costo, opt => opt.MapFrom(src => src.Costo))
            .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            .ForMember(dest => dest.Facebook, opt => opt.MapFrom(src => src.Facebook))
            .ForMember(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram))
            .ForMember(dest => dest.Linkendin, opt => opt.MapFrom(src => src.Linkendin))
            .ForMember(dest => dest.YouTube, opt => opt.MapFrom(src => src.YouTube))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado));

            //Creates
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
            .ForPath(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña))
            .ForPath(dest => dest.RolIdRol, opt => opt.MapFrom(src => src.RolIdRol));

            CreateMap<AsesorEspCreateRequest, AsesorHasEspecialidad>()
            .ForPath(dest => dest.AsesorIdAsesor, opt => opt.MapFrom(src => src.Asesor_idAsesor))
            .ForPath(dest => dest.EspecialidadIdEspecialidad, opt => opt.MapFrom(src => src.Especialidad_idEspecialidad));

            CreateMap<AsesorComCreateRequest, AsesorHasComentario>()
            .ForPath(dest => dest.AsesorIdAsesor, opt => opt.MapFrom(src => src.Asesor_idAsesor))
            .ForPath(dest => dest.ComentarioIdComentario, opt => opt.MapFrom(src => src.Comentario_idComentario));

            CreateMap<AsesorTurnoCreateRequest, AsesorHasTurno>()
            .ForPath(dest => dest.AsesorIdAsesor, opt => opt.MapFrom(src => src.Asesor_idAsesor))
            .ForPath(dest => dest.TurnoIdTurno, opt => opt.MapFrom(src => src.Turno_idTurno));

            CreateMap<SolicitudCreateRequest, Solicitud>()
            .ForPath(dest => dest.UsuarioIdUsuario, opt => opt.MapFrom(src => src.UsuarioIdUsuario))
            .ForPath(dest => dest.Especialidad1, opt => opt.MapFrom(src => src.Especialidad1))
            .ForPath(dest => dest.Especialidad2, opt => opt.MapFrom(src => src.Especialidad2))
            .ForPath(dest => dest.Especialidad3, opt => opt.MapFrom(src => src.Especialidad3))
            .ForPath(dest => dest.Turno1, opt => opt.MapFrom(src => src.Turno1))
            .ForPath(dest => dest.Turno2, opt => opt.MapFrom(src => src.Turno2))
            .ForPath(dest => dest.Turno3, opt => opt.MapFrom(src => src.Turno3))
            .ForPath(dest => dest.Costo, opt => opt.MapFrom(src => src.Costo))
            .ForPath(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono))
            .ForPath(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            .ForPath(dest => dest.Facebook, opt => opt.MapFrom(src => src.Facebook))
            .ForPath(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram))
            .ForPath(dest => dest.Linkendin, opt => opt.MapFrom(src => src.Linkendin))
            .ForPath(dest => dest.YouTube, opt => opt.MapFrom(src => src.YouTube))
            .ForPath(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo));
            


            //Updates
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
            .ForPath(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña))
            .ForPath(dest => dest.RolIdRol, opt => opt.MapFrom(src => src.RolIdRol));
            

            
        }
    }
}