using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiHelpDents.Domain.Entities;


namespace ApiHelpDents.Domain.Interfaces
{
    public interface ITurnoRepository
    {
        Task<IQueryable<Turno>> GetAll();
        Task<Turno> GetById (int id);
        Task<int> Create(Turno turno);
        Task<bool> Delete(int id);
        bool Exist(Expression<Func<Turno, bool>> expression);
    }
}