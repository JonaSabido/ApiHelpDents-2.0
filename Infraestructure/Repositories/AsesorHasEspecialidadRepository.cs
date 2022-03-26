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
    public class AsesorHasEspecialidadRepository : IAsesorHasEspecialidadRepository
    {

        private readonly HelpDents_Db_FinalContext _context;

        public AsesorHasEspecialidadRepository(HelpDents_Db_FinalContext context)
        {
            this._context = context;

        }

        public async Task<AsesorHasEspecialidad> GetById(int id){

            var entity = await _context.AsesorHasEspecialidads.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }
        public async Task<IQueryable<AsesorHasEspecialidad>> GetByEspecialidadId(int? id)
        {
            var query = await _context.AsesorHasEspecialidads.AsQueryable<AsesorHasEspecialidad>().Where(x => x.EspecialidadIdEspecialidad == id).ToListAsync();
            return query.AsQueryable();
        }

        public async Task<IQueryable<AsesorHasEspecialidad>> GetAll()
        {
            
            var query = await _context.AsesorHasEspecialidads.AsQueryable<AsesorHasEspecialidad>().OrderBy(x => x.AsesorIdAsesor).ToListAsync();
            return query.AsQueryable();
        }

        public async Task<int> Create(AsesorHasEspecialidad ahe){
            
            var validator = await _context.AsesorHasEspecialidads.FirstOrDefaultAsync(x => x.AsesorIdAsesor == ahe.AsesorIdAsesor && x.EspecialidadIdEspecialidad == ahe.EspecialidadIdEspecialidad);
            if(validator == null){
                var entity = ahe;
                await _context.AddAsync(entity);
                var rows = await _context.SaveChangesAsync();

                if(rows<=0){
                    throw new Exception("No pudo realizarse el registro");
                }

                return entity.Id;
            }
            else{
                return 0;
            }
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

        public bool Exist(Expression<Func<AsesorHasEspecialidad, bool>> expression)
        {
            return _context.AsesorHasEspecialidads.Any(expression);
        }
    }
}