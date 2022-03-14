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
    public class AsesorHasComentarioRepository : IAsesorHasComentarioRepository
    {

        private readonly HelpDents_Db_FinalContext _context;

        public AsesorHasComentarioRepository(HelpDents_Db_FinalContext context)
        {
            this._context = context;

        }

        public async Task<AsesorHasComentario> GetById(int id){

            var entity = await _context.AsesorHasComentarios.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }
        public async Task<IQueryable<AsesorHasComentario>> GetByIdAsesor(int id){
            var query = await _context.AsesorHasComentarios.AsQueryable<AsesorHasComentario>().Where(x => x.AsesorIdAsesor == id).ToListAsync();
            return query.AsQueryable();
        }
        public async Task<IQueryable<AsesorHasComentario>> GetAll()
        {
            
            var query = await _context.AsesorHasComentarios.AsQueryable<AsesorHasComentario>().OrderBy(x => x.AsesorIdAsesor).ToListAsync();
            return query.AsQueryable();
        }

        public async Task<int> Create(AsesorHasComentario ahe){

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

        public bool Exist(Expression<Func<AsesorHasComentario, bool>> expression)
        {
            return _context.AsesorHasComentarios.Any(expression);
        }
    }
}