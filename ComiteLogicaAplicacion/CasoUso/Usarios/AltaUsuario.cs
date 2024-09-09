
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;

namespace ComiteLogicaAplicacion.CasoUso.Usuarios
{
    public class AltaUsuario : IAlta<Usuario>
    {
        IRepositorioUsuario _repositorio;

        public AltaUsuario(IRepositorioUsuario repositorio) 
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(Usuario obj)
        {
            _repositorio.Add(obj);
        }
    }
}
