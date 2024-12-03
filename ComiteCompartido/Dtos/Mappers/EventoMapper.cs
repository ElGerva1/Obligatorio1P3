
using ComiteCompartido.Dtos.Eventos;
using ComiteLogicaNegocio.Entidades;


namespace ComiteCompartido.Dtos.Mappers
{
    public class EventoMapper
    {
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
                evento.Fin,
                evento.atletas.Select(a=>a.ID).ToList()
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
