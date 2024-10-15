
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;

namespace ComiteLogicaAplicacion.CasoUso.Usuarios
{
    public class EditarUsuario : IEditar<UsuarioAltaDto>
    {
        IRepositorioUsuario _repositorio;

        public EditarUsuario(IRepositorioUsuario repositorio) 
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(UsuarioAltaDto obj)
        {
            _repositorio.Edit(UsuarioMapper.FromDto(obj));
        }
    }
}
