using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ComiteAccesoADatos.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ComiteContext _context;

        public RepositorioUsuario(ComiteContext context)
        {
            _context = context;
        }

        public void Add(Usuario obj)
        {
            if (obj == null) 
            {
                throw new ArgumentNullException("No se recibio el usuario vàlido");
            }
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.usuarios;
        }

        public Usuario GetById(int id)
        {
            Usuario? unUsuario = null;
            unUsuario =
                _context.usuarios
                .FirstOrDefault(usuario => usuario.ID == id);
            if (unUsuario == null)
            {
                throw new Exception($"No se encontro la el usuario con id {id}");
            }
            return unUsuario;
        }

        public Usuario GetByEmail(string email)
        {
            Usuario? unUsuario = null;
            unUsuario =
                _context.usuarios
                .AsEnumerable()
                .FirstOrDefault(usuario => usuario.Email.Value == email);
            if (unUsuario == null)
            {
                throw new Exception($"No se encontro la el usuario con email {email}");
            }
            return unUsuario;
        }

        public void Delete(Usuario obj)
        {
            Usuario u = GetByEmail(obj.Email.Value);
            _context.usuarios.Remove(u);
            _context.SaveChanges();
        }

        public void Edit(Usuario obj)
        {
            Usuario u = GetByEmail(obj.Email.Value);
            _context.usuarios.Update(u);
            _context.SaveChanges();
        }
    }
}
