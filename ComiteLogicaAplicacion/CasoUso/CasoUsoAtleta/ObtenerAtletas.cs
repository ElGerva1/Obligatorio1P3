using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.MappersDisciplina;
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
    public class ObtenerAtletas : IObtenerTodos<AtletaListadoDto>
    {
        IRepositorioAtleta _repositorio;

        public ObtenerAtletas(IRepositorioAtleta repositorio)
        {
            _repositorio = repositorio;
        }
        public IEnumerable<AtletaListadoDto> Ejecutar()
        {
            return AtletaMapper.ToListaDto(_repositorio.GetAll());
        }
    }

}
