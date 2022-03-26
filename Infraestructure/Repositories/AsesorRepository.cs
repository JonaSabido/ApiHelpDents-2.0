using System.Diagnostics.Tracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiHelpDents.Domain.Entities;
using ApiHelpDents.Domain.Interfaces;
using ApiHelpDents.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace ApiHelpDents.Infraestructure.Repositories
{
    public class AsesorRepository : IAsesorRepository
    {

        private readonly HelpDents_Db_FinalContext _context;
        private readonly IAsesorHasEspecialidadRepository _repositoryEsp;
        private readonly IAsesorHasTurnoRepository _repositoryTurno;
        private readonly IUsuarioRepository _repositoryUser;

        public AsesorRepository(HelpDents_Db_FinalContext context, IAsesorHasEspecialidadRepository repositoryEsp, IAsesorHasTurnoRepository repositoryTurno, IUsuarioRepository repositoryUser)
        {
            this._context = context;
            _repositoryEsp = repositoryEsp;
            _repositoryTurno = repositoryTurno;
            _repositoryUser = repositoryUser;
        }

        public async Task<Asesor> GetById(int id){

            var entity = await _context.Asesors.FirstOrDefaultAsync(x => x.IdAsesor == id);
            return entity;
        }
        public async Task<IQueryable<Asesor>> GetAll()
        {
            
            var query = await _context.Asesors.ToListAsync();
            return query.AsQueryable();
        }

        public async Task<IQueryable<Asesor>> GetByName(string name){

            if(name == null){
                return new List<Asesor>().AsQueryable();
            }

            var query = _context.Asesors.AsQueryable();
            
            query = query.Where(x => x.UsuarioIdUsuarioNavigation.Nombre.Contains(name));
            

            var result = await query.ToListAsync();

            return result.AsQueryable();
        }

        
        public async Task<IQueryable<Asesor>> GetByFilter(FilterAsesor filter)
        {
            
            var queryAsesores = _context.Asesors.AsQueryable().ToList();
            List<Asesor> lista = new List<Asesor>();
            var queryAHE = await _repositoryEsp.GetByEspecialidadId(filter.idEspecialidad);
            var queryAHT = await _repositoryTurno.GetByTurnoId(filter.idTurno);
            

            if(filter.idEspecialidad != null && filter.idTurno != null && filter.Costo != null){
                foreach(var Esp in queryAHE){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == Esp.AsesorIdAsesor){
                            foreach(var tur in queryAHT){
                                if(Asesor.IdAsesor == tur.AsesorIdAsesor){
                                    if(Asesor.Costo <= filter.Costo){
                                        lista.Add(new Asesor(){
                                            IdAsesor = Asesor.IdAsesor,
                                            UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                            Costo = Asesor.Costo,
                                            Telefono = Asesor.Telefono,
                                            Descripcion = Asesor.Descripcion,
                                            Facebook = Asesor.Facebook,
                                            Instagram = Asesor.Instagram,
                                            Linkendin = Asesor.Linkendin,
                                            YouTube = Asesor.YouTube        
                                        });
                                    }
                                }
                            }
                        }
                    }
                    
                }
                         
            }


            if(filter.idEspecialidad != null && filter.idTurno != null && filter.Costo == null){
                foreach(var Esp in queryAHE){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == Esp.AsesorIdAsesor){
                            foreach(var tur in queryAHT){
                                if(Asesor.IdAsesor == tur.AsesorIdAsesor){
                                    lista.Add(new Asesor(){
                                            IdAsesor = Asesor.IdAsesor,
                                            UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                            Costo = Asesor.Costo,
                                            Telefono = Asesor.Telefono,
                                            Descripcion = Asesor.Descripcion,
                                            Facebook = Asesor.Facebook,
                                            Instagram = Asesor.Instagram,
                                            Linkendin = Asesor.Linkendin,
                                            YouTube = Asesor.YouTube        
                                    });
                                }
                            }
                        }
                    }
                    
                }
            }

            if(filter.idEspecialidad != null && filter.idTurno == null && filter.Costo != null){
                foreach(var Esp in queryAHE){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == Esp.AsesorIdAsesor){
                            if(Asesor.Costo <= filter.Costo){
                                lista.Add(new Asesor(){
                                    IdAsesor = Asesor.IdAsesor,
                                    UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                    Costo = Asesor.Costo,
                                    Telefono = Asesor.Telefono,
                                    Descripcion = Asesor.Descripcion,
                                    Facebook = Asesor.Facebook,
                                    Instagram = Asesor.Instagram,
                                    Linkendin = Asesor.Linkendin,
                                    YouTube = Asesor.YouTube        
                                });
                            }
                        }
                    }
                    
                }
            }

            if(filter.idEspecialidad != null && filter.idTurno == null && filter.Costo == null){
                foreach(var Esp in queryAHE){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == Esp.AsesorIdAsesor){
                                lista.Add(new Asesor(){
                                    IdAsesor = Asesor.IdAsesor,
                                    UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                    Costo = Asesor.Costo,
                                    Telefono = Asesor.Telefono,
                                    Descripcion = Asesor.Descripcion,
                                    Facebook = Asesor.Facebook,
                                    Instagram = Asesor.Instagram,
                                    Linkendin = Asesor.Linkendin,
                                    YouTube = Asesor.YouTube        
                                });
                        }
                    }
                    
                }
            }


            if(filter.idEspecialidad == null && filter.idTurno != null && filter.Costo != null){
                foreach(var tur in queryAHT){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == tur.AsesorIdAsesor){
                            if(Asesor.Costo <= filter.Costo){
                                lista.Add(new Asesor(){
                                            IdAsesor = Asesor.IdAsesor,
                                            UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                            Costo = Asesor.Costo,
                                            Telefono = Asesor.Telefono,
                                            Descripcion = Asesor.Descripcion,
                                            Facebook = Asesor.Facebook,
                                            Instagram = Asesor.Instagram,
                                            Linkendin = Asesor.Linkendin,
                                            YouTube = Asesor.YouTube        
                                });
                            }
                        }
                    }
                    
                }
                         
            }

            if(filter.idEspecialidad == null && filter.idTurno != null && filter.Costo == null){
                foreach(var tur in queryAHT){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == tur.AsesorIdAsesor){
                                lista.Add(new Asesor(){
                                            IdAsesor = Asesor.IdAsesor,
                                            UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                            Costo = Asesor.Costo,
                                            Telefono = Asesor.Telefono,
                                            Descripcion = Asesor.Descripcion,
                                            Facebook = Asesor.Facebook,
                                            Instagram = Asesor.Instagram,
                                            Linkendin = Asesor.Linkendin,
                                            YouTube = Asesor.YouTube        
                                });
                        }
                    }
                    
                }
                         
            }

            if(filter.idEspecialidad == null && filter.idTurno == null && filter.Costo != null){
                foreach(var Asesor in queryAsesores){
                    if(Asesor.Costo <= filter.Costo){
                            lista.Add(new Asesor(){
                                        IdAsesor = Asesor.IdAsesor,
                                        UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                        Costo = Asesor.Costo,
                                        Telefono = Asesor.Telefono,
                                        Descripcion = Asesor.Descripcion,
                                        Facebook = Asesor.Facebook,
                                        Instagram = Asesor.Instagram,
                                        Linkendin = Asesor.Linkendin,
                                        YouTube = Asesor.YouTube        
                            });
                        }
                    }
                           
            }
            
            if(filter.idEspecialidad == null && filter.idTurno == null && filter.Costo == null){
                foreach(var Asesor in queryAsesores){
                    
                            lista.Add(new Asesor(){
                                        IdAsesor = Asesor.IdAsesor,
                                        UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                        Costo = Asesor.Costo,
                                        Telefono = Asesor.Telefono,
                                        Descripcion = Asesor.Descripcion,
                                        Facebook = Asesor.Facebook,
                                        Instagram = Asesor.Instagram,
                                        Linkendin = Asesor.Linkendin,
                                        YouTube = Asesor.YouTube        
                            });

                    }
                           
            }

            if(lista.Count() == 0){
                if(filter.idEspecialidad != 0 && filter.idTurno != 0 && filter.Costo != null){
                foreach(var Esp in queryAHE){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == Esp.AsesorIdAsesor){
                            foreach(var tur in queryAHT){
                                if(Asesor.IdAsesor == tur.AsesorIdAsesor){
                                    if(Asesor.Costo <= filter.Costo){
                                        lista.Add(new Asesor(){
                                            IdAsesor = Asesor.IdAsesor,
                                            UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                            Costo = Asesor.Costo,
                                            Telefono = Asesor.Telefono,
                                            Descripcion = Asesor.Descripcion,
                                            Facebook = Asesor.Facebook,
                                            Instagram = Asesor.Instagram,
                                            Linkendin = Asesor.Linkendin,
                                            YouTube = Asesor.YouTube        
                                        });
                                    }
                                }
                            }
                        }
                    }
                    
                }
                         
            }


            if(filter.idEspecialidad != 0 && filter.idTurno != 0 && filter.Costo == null){
                foreach(var Esp in queryAHE){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == Esp.AsesorIdAsesor){
                            foreach(var tur in queryAHT){
                                if(Asesor.IdAsesor == tur.AsesorIdAsesor){
                                    lista.Add(new Asesor(){
                                            IdAsesor = Asesor.IdAsesor,
                                            UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                            Costo = Asesor.Costo,
                                            Telefono = Asesor.Telefono,
                                            Descripcion = Asesor.Descripcion,
                                            Facebook = Asesor.Facebook,
                                            Instagram = Asesor.Instagram,
                                            Linkendin = Asesor.Linkendin,
                                            YouTube = Asesor.YouTube        
                                    });
                                }
                            }
                        }
                    }
                    
                }
            }

            if(filter.idEspecialidad != 0 && filter.idTurno == 0 && filter.Costo != null){
                foreach(var Esp in queryAHE){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == Esp.AsesorIdAsesor){
                            if(Asesor.Costo <= filter.Costo){
                                lista.Add(new Asesor(){
                                    IdAsesor = Asesor.IdAsesor,
                                    UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                    Costo = Asesor.Costo,
                                    Telefono = Asesor.Telefono,
                                    Descripcion = Asesor.Descripcion,
                                    Facebook = Asesor.Facebook,
                                    Instagram = Asesor.Instagram,
                                    Linkendin = Asesor.Linkendin,
                                    YouTube = Asesor.YouTube        
                                });
                            }
                        }
                    }
                    
                }
            }

            if(filter.idEspecialidad != 0 && filter.idTurno == 0 && filter.Costo == null){
                foreach(var Esp in queryAHE){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == Esp.AsesorIdAsesor){
                                lista.Add(new Asesor(){
                                    IdAsesor = Asesor.IdAsesor,
                                    UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                    Costo = Asesor.Costo,
                                    Telefono = Asesor.Telefono,
                                    Descripcion = Asesor.Descripcion,
                                    Facebook = Asesor.Facebook,
                                    Instagram = Asesor.Instagram,
                                    Linkendin = Asesor.Linkendin,
                                    YouTube = Asesor.YouTube        
                                });
                        }
                    }
                    
                }
            }


            if(filter.idEspecialidad == 0 && filter.idTurno != 0 && filter.Costo != null){
                foreach(var tur in queryAHT){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == tur.AsesorIdAsesor){
                            if(Asesor.Costo <= filter.Costo){
                                lista.Add(new Asesor(){
                                            IdAsesor = Asesor.IdAsesor,
                                            UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                            Costo = Asesor.Costo,
                                            Telefono = Asesor.Telefono,
                                            Descripcion = Asesor.Descripcion,
                                            Facebook = Asesor.Facebook,
                                            Instagram = Asesor.Instagram,
                                            Linkendin = Asesor.Linkendin,
                                            YouTube = Asesor.YouTube        
                                });
                            }
                        }
                    }
                    
                }
                         
            }

            if(filter.idEspecialidad == 0 && filter.idTurno != 0 && filter.Costo == null){
                foreach(var tur in queryAHT){
                    foreach(var Asesor in queryAsesores){
                        if(Asesor.IdAsesor == tur.AsesorIdAsesor){
                                lista.Add(new Asesor(){
                                            IdAsesor = Asesor.IdAsesor,
                                            UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                            Costo = Asesor.Costo,
                                            Telefono = Asesor.Telefono,
                                            Descripcion = Asesor.Descripcion,
                                            Facebook = Asesor.Facebook,
                                            Instagram = Asesor.Instagram,
                                            Linkendin = Asesor.Linkendin,
                                            YouTube = Asesor.YouTube        
                                });
                        }
                    }
                    
                }
                         
            }

            if(filter.idEspecialidad == 0 && filter.idTurno == 0 && filter.Costo != null){
                foreach(var Asesor in queryAsesores){
                    if(Asesor.Costo <= filter.Costo){
                            lista.Add(new Asesor(){
                                        IdAsesor = Asesor.IdAsesor,
                                        UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                        Costo = Asesor.Costo,
                                        Telefono = Asesor.Telefono,
                                        Descripcion = Asesor.Descripcion,
                                        Facebook = Asesor.Facebook,
                                        Instagram = Asesor.Instagram,
                                        Linkendin = Asesor.Linkendin,
                                        YouTube = Asesor.YouTube        
                            });
                        }
                    }
                           
            }
            
            if(filter.idEspecialidad == 0 && filter.idTurno == 0 && filter.Costo == null){
                foreach(var Asesor in queryAsesores){
                    
                            lista.Add(new Asesor(){
                                        IdAsesor = Asesor.IdAsesor,
                                        UsuarioIdUsuario = Asesor.UsuarioIdUsuario,
                                        Costo = Asesor.Costo,
                                        Telefono = Asesor.Telefono,
                                        Descripcion = Asesor.Descripcion,
                                        Facebook = Asesor.Facebook,
                                        Instagram = Asesor.Instagram,
                                        Linkendin = Asesor.Linkendin,
                                        YouTube = Asesor.YouTube        
                            });

                    }
                           
            }
            }














            

            return lista.AsQueryable();
            
        }
        
        public async Task<int> Create(Asesor asesor){

            var validator = await _context.Asesors.FirstOrDefaultAsync(x => x.UsuarioIdUsuario == asesor.UsuarioIdUsuario);
            if(validator == null){
                var entity = asesor;
                await _context.AddAsync(entity);
                var rows = await _context.SaveChangesAsync();

                if(rows<=0){
                    throw new Exception("No pudo realizarse el registro");
                }

                return entity.IdAsesor;
            }
            else{
                return 0;
            }
            
        }

        public async Task<bool> Update(int id, Asesor asesor){

            if(id<=0 || asesor == null){
                throw new ArgumentException("Falta información para continuar con el proceso de modificación...");
            }

            var entity = await GetById(id);

            entity.Costo = asesor.Costo;
            entity.Telefono = asesor.Telefono;
            entity.Facebook = asesor.Facebook;
            entity.Instagram = asesor.Instagram;
            entity.YouTube = asesor.YouTube;
            entity.Linkendin = asesor.Linkendin;
            entity.Descripcion = asesor.Descripcion;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id){

            if(id<=0){
                throw new ArgumentException("Proceso Fallado");
            }

            var entity = await GetById(id);

            _context.Remove(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public bool Exist(Expression<Func<Asesor, bool>> expression)
        {
            return _context.Asesors.Any(expression);
        }
    }
}