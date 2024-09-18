
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteLogicaNegocio.Vo.Generic;

namespace ComiteCompartido.Dtos.Mappers
{
    public class UsuarioMapper
    {
        public static Usuario FromDto(UsuarioAltaDto usuario)
        {
            return new Usuario(usuario.Id, new Email(usuario.Email), new Password(usuario.Password));
        }


        public static IEnumerable<UsuarioListadoDto> ToListaDto(IEnumerable<Usuario> usuarios)
        {            

            List<UsuarioListadoDto> dtos = new List<UsuarioListadoDto>();

            foreach (Usuario item in usuarios)
            {
                dtos.Add(new UsuarioListadoDto(
                    item.ID,
                    item.Email.Value,
                    item.Password.Value
                    ));
            }

            return dtos;
        }


    }
}
