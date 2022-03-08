using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiHelpDents.Domain.Entities;


namespace ApiHelpDents.Domain.Interfaces
{
    public interface IAsesorRepository
    {
        Task<Asesor> GetById (int id);
        Task<IQueryable<Asesor>> GetAll();
        Task<IQueryable<Asesor>> GetByName(string name);
        //Task<IQueryable<Asesor>> GetByFilter(Asesor asesor);
        Task<int> Create(Asesor usuario);
        Task<bool> Update(int id, Asesor asesor);
        Task<bool> Delete(int id);
        bool Exist(Expression<Func<Asesor, bool>> expression);
    }
}