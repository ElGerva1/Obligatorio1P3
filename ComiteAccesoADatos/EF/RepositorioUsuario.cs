using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorios;

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
            throw new NotImplementedException();
        }
        public Usuario GetByEmailPass(string email, string pass) {
            foreach (Usuario u in _context.usuarios) {
                if (u.Email.Value == email && u.Password.Value == pass) {
                    return u;
                }
            }
                return null;
        }
    }
}
