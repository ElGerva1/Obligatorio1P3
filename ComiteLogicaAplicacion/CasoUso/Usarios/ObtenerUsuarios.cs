using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;

namespace ComiteLogicaAplicacion.CasoUso.Usuarios
{
    public class ObtenerUsuarios : IObtenerTodos<Usuario>
    {
        IRepositorioUsuario _repositorio;

        public ObtenerUsuarios(IRepositorioUsuario repositorio) 
        {
            _repositorio = repositorio;
        }
        public IEnumerable<Usuario> Ejecutar()
        {
            return _repositorio.GetAll();
        }
    }
}
