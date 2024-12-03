using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.Excepciones.Usuario;
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
                throw new UsuarioException("No se recibio el usuario vàlido");
            }
            if (UsuarioExiste(obj.Email.Value))
            {
                throw new UsuarioException("El usuario ya existe");
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
                throw new UsuarioException($"No se encontro la el usuario con id {id}");
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
                throw new UsuarioException($"No se encontro la el usuario con email {email}");
            }
            return unUsuario;
        }
        public bool UsuarioExiste(string email)
        {

            Usuario? unUsuario = null;
            unUsuario =
                _context.usuarios
                .AsEnumerable()
                .FirstOrDefault(usuario => usuario.Email.Value == email);
            return unUsuario != null;
        }
        public void Delete(Usuario obj)
        {
            try
            {
                Usuario u = GetByEmail(obj.Email.Value);
                if (u == null)
                {
                    throw new UsuarioException("No se recibio el usuario vàlido");
                }
                _context.usuarios.Remove(u);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new UsuarioException("Error al eliminar usuario");
            }

        }

        public void Edit(Usuario obj)
        {
            Usuario u = GetById(obj.ID);
            if (u == null)
            {
                throw new UsuarioException("No se recibio el usuario vàlido");
            }
            if (UsuarioExiste(obj.Email.Value)) {
                throw new UsuarioException("El usuario ya existe");
            }
            try
            {
                u.Email = obj.Email;
                u.Password = obj.Password;
                _context.usuarios.Update(u);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new UsuarioException("Error al editar usuario");
            }

        }
    }
}
