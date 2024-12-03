using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorio;
using ComiteLogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaAplicacion.CasoUso.CasoUsoAtleta
{
    public class EditarAtleta : IEditar<AtletaAltaDto>
    {
        IRepositorioAtleta _repositorio;

        public EditarAtleta(IRepositorioAtleta repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(AtletaAltaDto obj)
        {
            _repositorio.Edit(AtletaMapper.FromDto(obj));
        }
    }
}
