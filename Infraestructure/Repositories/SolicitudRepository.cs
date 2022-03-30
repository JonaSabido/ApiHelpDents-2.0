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
    public class SolicitudRepository : ISolicitudRepository
    {

        private readonly HelpDents_Db_FinalContext _context;

        public SolicitudRepository(HelpDents_Db_FinalContext context)
        {
            this._context = context;

        }

        public async Task<Solicitud> GetById(int id){

            var entity = await _context.Solicituds.FirstOrDefaultAsync(x => x.IdSolicitud == id);
            return entity;
        }
        public async Task<IQueryable<Solicitud>> GetAll()
        {
            
            var query = await _context.Solicituds.AsQueryable<Solicitud>().ToListAsync();
            return query.AsQueryable();
        }

        public async Task<int> Create(Solicitud solicitud){

            solicitud.Estado = "Pendiente";
            var entity = solicitud;
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows<=0){
                throw new Exception("No pudo realizarse el registro");
            }

            return entity.IdSolicitud;
        }

        public async Task<bool> Update(int id, string estado){

            if(id<=0){
                throw new ArgumentException("Falta información para continuar con el proceso de modificación...");
            }

            var entity = await GetById(id);

            entity.Estado = estado;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id){

            if(id<=0){
                throw new ArgumentException("Proceso Fallado");
            }

            var entity = await _context.Solicituds.FirstOrDefaultAsync(x => x.IdSolicitud == id);

            _context.Remove(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public bool Exist(Expression<Func<Solicitud, bool>> expression)
        {
            return _context.Solicituds.Any(expression);
        }
    }
}