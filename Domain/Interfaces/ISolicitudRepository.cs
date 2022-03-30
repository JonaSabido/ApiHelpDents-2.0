using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiHelpDents.Domain.Entities;


namespace ApiHelpDents.Domain.Interfaces
{
    public interface ISolicitudRepository
    {
        Task<IQueryable<Solicitud>> GetAll();
        Task<Solicitud> GetById (int id);
        Task<int> Create(Solicitud solicitud);
        Task<bool> Update(int id, string estado);
        Task<bool> Delete(int id);
        bool Exist(Expression<Func<Solicitud, bool>> expression);
    }
}