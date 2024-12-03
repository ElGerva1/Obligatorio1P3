using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.CasoUso.Usuarios
{
    public class ObtenerUsuario : IObtener<UsuarioAltaDto>
    {
        IRepositorioUsuario _repositorio;

        public ObtenerUsuario(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }
        public UsuarioAltaDto Ejecutar(int id)
        {
            return UsuarioMapper.ToDto(_repositorio.GetById(id));
        }
        public UsuarioAltaDto Ejecutar(string email)
        {
            return UsuarioMapper.ToDto(_repositorio.GetByEmail(email));
        }
    }
}
