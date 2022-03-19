using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiHelpDents.Domain.Entities;


namespace ApiHelpDents.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetById (int id);
        Task<Usuario> GetByCorreo(string Correo);
        Task<IQueryable<Usuario>> GetAll();
        Task<int> Create(Usuario usuario);
        Task<bool> Update(int id, Usuario usuario);
        Task<bool> Delete(int id);
        bool Exist(Expression<Func<Usuario, bool>> expression);
        public bool ExistCorreo(string Correo);
    }
}