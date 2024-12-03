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
    public class AltaEvento : IAlta<EventoAltaDto>
    {
        IRepositorioEvento _repositorio;
        IRepositorioAtleta _atletas;
        IRepositorioDisciplina _disciplinas;

        public AltaEvento(IRepositorioEvento repositorio, IRepositorioAtleta atletas, IRepositorioDisciplina disciplinas)
        {
            _repositorio = repositorio;
            _atletas = atletas;
            _disciplinas = disciplinas;
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
            Evento e = EventoMapper.FromDto(obj);
            Disciplina d = _disciplinas.GetById(obj.DisciplinaId);
            e.Disciplina = d;
            int cantidadAtletas = 0;
            /* foreach (int atletaId in obj.AtletasIds)
           {
               Atleta a = _atletas.GetById(atletaId);
               if (a != null) {
                   if (!a.DisciplinasIds.Contains(obj.DisciplinaId))
                   {
                       throw new Exception("El atleta debe pertenecer a la disciplina del evento");
                   }
                   cantidadAtletas++;
                   e.atletas.Add(a);
               }
           }
        */

            if (cantidadAtletas >= 3)
            {
                _repositorio.Add(e);
            }
            else {
                throw new Exception("El evento debe tener al menos 3 atletas");
            }
        }
    }
}
