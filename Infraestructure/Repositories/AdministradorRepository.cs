using System.Threading;
using System.Reflection.Metadata;
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
    public class AdministradorRepository : IAdministradorRepository
    {

        private readonly HelpDents_Db_FinalContext _context;

        public AdministradorRepository(HelpDents_Db_FinalContext context)
        {
            this._context = context;

        }

        public async Task<Administrador> GetById(int id){

            var entity = await _context.Administradors.FirstOrDefaultAsync(x => x.IdAdministrador == id);
            return entity;
        }
        public async Task<IQueryable<Administrador>> GetAll()
        {
            
            var query = await _context.Administradors.AsQueryable<Administrador>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }

        public async Task<int> Create(Administrador admin){

            var entity = admin;
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows<=0){
                throw new Exception("No pudo realizarse el registro");
            }

            return entity.IdAdministrador;
        }

        public async Task<bool> Update(int id, Administrador admin){

            if(id<=0 || admin == null){
                throw new ArgumentException("Falta información para continuar con el proceso de modificación...");
            }

            var entity = await GetById(id);

            entity.Nombre = admin.Nombre;
            entity.Apellido = admin.Apellido;
            entity.Correo = admin.Correo;
            entity.Contraseña = admin.Contraseña;
            

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

        public bool Exist(Expression<Func<Administrador, bool>> expression)
        {
            return _context.Administradors.Any(expression);
        }
    }
}