using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;

namespace ComiteLogicaAplicacion.CasoUso.Usuarios
{
    public class ObtenerUsuarios : IObtenerTodos<UsuarioListadoDto>
    {
        IRepositorioUsuario _repositorio;

        public ObtenerUsuarios(IRepositorioUsuario repositorio) 
        {
            _repositorio = repositorio;
        }
        public IEnumerable<UsuarioListadoDto> Ejecutar()
        {
            return UsuarioMapper.ToListaDto(_repositorio.GetAll());
        }
    }
}
