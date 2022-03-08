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
    public class TurnoRepository : ITurnoRepository
    {

        private readonly HelpDents_Db_FinalContext _context;

        public TurnoRepository (HelpDents_Db_FinalContext context)
        {
            this._context = context;

        }

        public async Task<IQueryable<Turno>> GetAll()
        {
            
            var query = await _context.Turnos.AsQueryable<Turno>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }
        public async Task<Turno> GetById(int id){

            var entity = await _context.Turnos.FirstOrDefaultAsync(x => x.IdTurno== id);
            return entity;
        }

        public async Task<int> Create(Turno turno){

            var entity = turno;
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows<=0){
                throw new Exception("No pudo realizarse el registro");
            }

            return entity.IdTurno;
        }

        public async Task<bool> Delete(int id){

            if(id<=0){
                throw new ArgumentException("Proceso Fallado");
            }

            var entity = await _context.Turnos.FirstOrDefaultAsync(x => x.IdTurno == id);

            _context.Remove(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public bool Exist(Expression<Func<Turno, bool>> expression)
        {
            return _context.Turnos.Any(expression);
        }
    }
}