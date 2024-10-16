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
            /*
             De los eventos se conoce la disciplina, el nombre de la prueba (por ejemplo: salto largo, 100 metros mariposa,
            gimnasia rítmica), las fechas en que inicia y finaliza (si la duración es de un día ambas fechas serán iguales) y
            los atletas participantes. Cada atleta obtiene un puntaje en el evento (por el momento, un número decimal).
            Debe controlarse que en un evento solamente participen atletas que se hayan registrado para competir en la
            disciplina del evento.
            Se debe validar que no exista otro evento con el mismo nombre de prueba previamente
            ingresado.
            o Un evento deberá tener al menos tres atletas registrados.
            o Los atletas registrados deberán estar registrados para participar en la disciplina del evento.
             */
            _repositorio.Add(EventoMapper.FromDto(obj));
        }
    }
}
