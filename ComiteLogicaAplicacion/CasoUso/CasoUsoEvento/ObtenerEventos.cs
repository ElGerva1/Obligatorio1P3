using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.Eventos;
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

namespace ComiteLogicaAplicacion.CasoUso.CasoUsoEvento
{
    public class ObtenerEventos : IObtenerTodos<EventoListadoDto>
    {
        IRepositorioEvento _repositorio;

        public ObtenerEventos(IRepositorioEvento repositorio)
        {
            _repositorio = repositorio;
        }
        public IEnumerable<EventoListadoDto> Ejecutar()
        {
            return EventoMapper.ToListaDto(_repositorio.GetAll());
        }
    }
}
