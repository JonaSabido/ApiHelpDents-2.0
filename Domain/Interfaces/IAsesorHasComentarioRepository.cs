using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiHelpDents.Domain.Entities;
using System.Collections.Generic;


namespace ApiHelpDents.Domain.Interfaces
{
    public interface IAsesorHasComentarioRepository
    {
        Task<IQueryable<AsesorHasComentario>> GetAll();
        Task<AsesorHasComentario> GetById (int id);
        Task<int> Create(AsesorHasComentario ahc);
        Task<bool> Delete(int id);
        bool Exist(Expression<Func<AsesorHasComentario, bool>> expression); 
    }
}