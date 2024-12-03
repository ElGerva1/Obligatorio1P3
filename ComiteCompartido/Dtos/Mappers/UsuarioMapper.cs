
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteLogicaNegocio.Vo.Generic;

namespace ComiteCompartido.Dtos.Mappers
{
    public class UsuarioMapper
    {
        public static Digitador FromDto(UsuarioAltaDto usuario)
        {
            return new Digitador(usuario.Id, usuario.Email, usuario.Password);
        }
        public static Admin FromDtoToAdmin(UsuarioAltaDto usuario)
        {
            return new Admin(usuario.Id, usuario.Email, usuario.Password);
        }
        public static UsuarioAltaDto ToDto(Usuario? usuario)
        {
            bool admin = false;
            if (usuario.Discriminator == "Admin")
            {
                admin = true;

                return new UsuarioAltaDto(
                        usuario.ID,
                        usuario.Email.Value,
                        usuario.Password.Value,
                        usuario.Discriminator
                );
            }
            else
            {
                // Si es digitador preciso el id del admin que lo creo
                return new UsuarioAltaDto(
                    usuario.ID,
                    usuario.Email.Value,
                    usuario.Password.Value,
                    usuario.Discriminator
                );
            }


        }

        public static IEnumerable<UsuarioListadoDto> ToListaDto(IEnumerable<Usuario> usuarios)
        {            

            List<UsuarioListadoDto> dtos = new List<UsuarioListadoDto>();

            foreach (Usuario item in usuarios)
            {
                dtos.Add(new UsuarioListadoDto(
                    item.ID,
                    item.Email.Value,
                    item.Password.Value,
                    item.Discriminator
                    ));
            }

            return dtos;
        }


    }
}
