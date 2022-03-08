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
    public class AsesorHasTurnoRepository : IAsesorHasTurnoRepository
    {

        private readonly HelpDents_Db_FinalContext _context;

        public AsesorHasTurnoRepository(HelpDents_Db_FinalContext context)
        {
            this._context = context;

        }

        public async Task<AsesorHasTurno> GetById(int id){

            var entity = await _context.AsesorHasTurnos.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }
        public async Task<IQueryable<AsesorHasTurno>> GetAll()
        {
            
            var query = await _context.AsesorHasTurnos.AsQueryable<AsesorHasTurno>().ToListAsync();
            return query.AsQueryable();
        }

        public async Task<int> Create(AsesorHasTurno ahe){

            var entity = ahe;
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows<=0){
                throw new Exception("No pudo realizarse el registro");
            }

            return entity.Id;
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

        public bool Exist(Expression<Func<AsesorHasTurno, bool>> expression)
        {
            return _context.AsesorHasTurnos.Any(expression);
        }
    }
}