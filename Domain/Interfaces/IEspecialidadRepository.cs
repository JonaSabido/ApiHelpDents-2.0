using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiHelpDents.Domain.Entities;


namespace ApiHelpDents.Domain.Interfaces
{
    public interface IEspecialidadRepository
    {
        Task<IQueryable<Especialidad>> GetAll();
        Task<Especialidad> GetById (int id);
        Task<Especialidad> GetByName(string name);
        Task<int> Create(Especialidad turno);
        Task<bool> Update(int id, Especialidad especialidad);
        Task<bool> Delete(int id);
        bool Exist(Expression<Func<Especialidad, bool>> expression);
    }
}