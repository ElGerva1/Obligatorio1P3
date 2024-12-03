
using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Eventos;
using ComiteLogicaNegocio.Entidades;
using System.Linq;


namespace ComiteCompartido.Dtos.Mappers
{
    public class EventoMapper
    {
        // Maps a single Evento to its DTO (Event with Atletas)
        public static EventoConAtletaListadoDto ToEventoConAtletaDto(Evento evento)
        {
            return new EventoConAtletaListadoDto(
                evento.ID,                          // Evento ID
                evento.Disciplina.Nombre,           // Nombre de la Disciplina
                evento.Nombre,                      // Nombre del Evento
                evento.Inicio,                      // Fecha de Inicio
                evento.Fin,                         // Fecha de Fin
                evento.EventoAtletas
                    .Select(ea => new EventoAtletaDto( // Mapeo de EventoAtleta a DTO
                        new AtletaAltaDto(
                            ea.Atleta.ID,      
                            ea.Atleta.Nombre,       
                            ea.Atleta.Sexo,
                            ea.Atleta.PaisId, 
                            ea.Atleta.DisciplinasIds
                        ),
                        ea.Puntaje                      // Puntaje en el EventoAtleta
                    ))
                    .ToList()                          // Lista de Atletas mapeada
            );
        }

        // Maps a list of Evento entities to a list of EventoConAtletaListadoDto
        public static IEnumerable<EventoConAtletaListadoDto> ToListaConAtletasDto(IEnumerable<Evento> eventos)
        {
            return eventos.Select(e => ToEventoConAtletaDto(e)).ToList();
        }

        public static Evento FromDto(EventoAltaDto evento) {
            return new Evento(
                evento.id,
                evento.DisciplinaId,
                evento.Nombre,
                evento.Inicio,
                evento.Fin
                );
        }
        public static EventoAltaDto ToDto(Evento evento)
        {
            return new EventoAltaDto(
                evento.ID,
                evento.DisciplinaId,
                evento.Nombre,
                evento.Inicio,
                evento.Fin
                );
        }
        public static IEnumerable<EventoListadoDto> ToListaDto(IEnumerable<Evento> items)
        {

            List<EventoListadoDto> dtos = new List<EventoListadoDto>();

            foreach (Evento item in items)
            {
                dtos.Add(new EventoListadoDto(
                        item.ID,
                        item.Disciplina.Nombre,
                        item.Nombre,
                        item.Inicio,
                        item.Fin
                    ));
            }

            return dtos;
        }
    }
}
