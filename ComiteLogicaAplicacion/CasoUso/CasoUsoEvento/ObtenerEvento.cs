using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.Eventos;
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.MappersDisciplina;
using ComiteLogicaNegocio.Entidades;
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
    public class ObtenerEvento : IObtener<EventoAltaDto>
    {
        IRepositorioEvento _repositorio;

        public ObtenerEvento(IRepositorioEvento repositorio)
        {
            _repositorio = repositorio;
        }
        public EventoAltaDto Ejecutar(int id)
        {
            Evento e = _repositorio.GetById(id);
            EventoAltaDto edto = EventoMapper.ToDto(e);
            return edto; 
        }
        public EventoAltaDto Ejecutar(string nombre)
        {
            return EventoMapper.ToDto(_repositorio.GetByName(nombre));
        }
    }
}
