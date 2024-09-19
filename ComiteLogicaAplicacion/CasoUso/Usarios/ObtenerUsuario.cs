using ComiteAccesoADatos.EF;
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.CasoUso.Usuarios
{
    public class ObtenerUsuario:IObtener<UsuarioObtenerDto>
    {
        RepositorioUsuario _repositorio;
        public Usuario Ejecutar(UsuarioObtenerDto obj)
        {
            Usuario u= _repositorio.GetByEmailPass(obj.Email, obj.Password);
            return _repositorio.GetByEmailPass(obj.Email, obj.Password);
        }

        UsuarioObtenerDto IObtener<UsuarioObtenerDto>.Ejecutar(UsuarioObtenerDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
