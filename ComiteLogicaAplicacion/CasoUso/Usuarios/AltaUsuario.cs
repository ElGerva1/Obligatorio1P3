
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;

namespace ComiteLogicaAplicacion.CasoUso.Usuarios
{
    public class AltaUsuario : IAlta<UsuarioAltaDto>
    {
        IRepositorioUsuario _repositorio;

        public AltaUsuario(IRepositorioUsuario repositorio) 
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(UsuarioAltaDto obj)
        {
                if (obj.Discriminator == "Admin")
                {
                    _repositorio.Add(UsuarioMapper.FromDtoToAdmin(obj));
                }
                _repositorio.Add(UsuarioMapper.FromDto(obj));
        }
    }
}
