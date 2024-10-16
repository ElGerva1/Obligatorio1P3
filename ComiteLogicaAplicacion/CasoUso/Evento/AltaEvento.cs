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

namespace ComiteLogicaAplicacion.CasoUso.Evento
{
    public class AltaEvento : IAlta<EventoAltaDto>
    {
        IRepositorioEvento _repositorio;

        public AltaEvento(IRepositorioEvento repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(EventoAltaDto obj)
        {
            _repositorio.Add(EventoMapper.FromDto(obj));
        }
    }
}
