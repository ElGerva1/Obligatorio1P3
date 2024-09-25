
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
            if (usuario.isAdmin)
                return new Admin(usuario.Id, usuario.Email, usuario.Password);
            return new Digitador(usuario.Id, usuario.Email, usuario.Password);
        }

        public static UsuarioAltaDto ToDto(Usuario? usuario)
        {
            bool admin = false;
            if (usuario.Discriminator == "Admin")
            {
                admin = true;
            }
            else
            {
                // Si es digitador preciso el id del admin que lo creo
            }

            return new UsuarioAltaDto(
                    usuario.ID,
                    usuario.Email.Value,
                    usuario.Password.Value,
                    admin
                );
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
