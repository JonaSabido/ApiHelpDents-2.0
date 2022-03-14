using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiHelpDents.Domain.Entities;


namespace ApiHelpDents.Domain.Interfaces
{
    public interface IAsesorHasTurnoRepository
    {
        Task<IQueryable<AsesorHasTurno>> GetAll();
        Task<AsesorHasTurno> GetById (int id);
        Task<IQueryable<AsesorHasTurno>> GetByTurnoId(int? id);
        Task<int> Create(AsesorHasTurno aht);
        Task<bool> Delete(int id);
        bool Exist(Expression<Func<AsesorHasTurno, bool>> expression); 
    }
}