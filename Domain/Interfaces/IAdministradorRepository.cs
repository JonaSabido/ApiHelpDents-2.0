using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiHelpDents.Domain.Entities;


namespace ApiHelpDents.Domain.Interfaces
{
    public interface IAdministradorRepository
    {
        Task<Administrador> GetById (int id);
        Task<IQueryable<Administrador>> GetAll();
        Task<int> Create(Administrador administrador);
        Task<bool> Update(int id, Administrador administrador);
        Task<bool> Delete(int id);
        bool Exist(Expression<Func<Administrador, bool>> expression);
    }
}