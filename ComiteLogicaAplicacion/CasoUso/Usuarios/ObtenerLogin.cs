
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaAplicacion.CasoUso.Usuarios
{
    public class ObtenerLogin : IObtenerLogin<UsuarioAltaDto>
    {
        IRepositorioUsuario _repositorio;

        public ObtenerLogin(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }

        public UsuarioAltaDto Ejecutar(string email, string password)
        {
            return UsuarioMapper.ToDto(_repositorio.GetByEmail(email));
        }

    }
}
