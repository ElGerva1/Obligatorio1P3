
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;

namespace ComiteLogicaAplicacion.CasoUso.Usuarios
{
    public class EliminarUsuario : IEliminar<UsuarioAltaDto>
    {
        IRepositorioUsuario _repositorio;

        public EliminarUsuario(IRepositorioUsuario repositorio) 
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(UsuarioAltaDto obj)
        {

            _repositorio.Delete(UsuarioMapper.FromDto(obj));
        }
    }
}
