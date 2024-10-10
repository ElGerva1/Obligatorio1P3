using ComiteCompartido.Dtos.Paises;
using ComiteCompartido.Dtos.MappersDisciplina;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComiteLogicaNegocio.InterfacesRepositorio;
using ComiteCompartido.Dtos.Mappers;

namespace ComiteLogicaAplicacion.CasoUso.Pais
{
    public class ObtenerPaises : IObtenerTodos<PaisListadoDto>
    {
        IRepositorioPais _repositorio;

        public ObtenerPaises(IRepositorioPais repositorio)
        {
            _repositorio = repositorio;
        }
        public IEnumerable<PaisListadoDto> Ejecutar()
        {
            return PaisMapper.ToListaDto(_repositorio.GetAll());
        }
    }
}
