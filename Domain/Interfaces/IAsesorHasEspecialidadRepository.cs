using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiHelpDents.Domain.Entities;


namespace ApiHelpDents.Domain.Interfaces
{
    public interface IAsesorHasEspecialidadRepository
    {
        Task<IQueryable<AsesorHasEspecialidad>> GetAll();
        
        Task<AsesorHasEspecialidad> GetById (int id);
        Task<int> Create(AsesorHasEspecialidad ahe);
        Task<bool> Delete(int id);
        bool Exist(Expression<Func<AsesorHasEspecialidad, bool>> expression); 
    }
}