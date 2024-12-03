using ComiteAccesoADatos.Excepciones;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;


namespace ComiteAccesoADatos.EF
{
    public class RepositorioEvento : IRepositorioEvento
    {
        private ComiteContext _context;

        public RepositorioEvento(ComiteContext context)
        {
            _context = context;
        }

        public void Add(Evento obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("No se recibio evento vàlido");
            }
            if (EventoExist(obj.Nombre))
            {
                throw new EventoException("El evento ya existe");
            }
            if (obj.Inicio > obj.Fin)
            {
                throw new EventoException("El inicio no puede ser antes que el fin");
            }
            try
            {
                _context.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new EventoException("No se pudo agregar el evento");
            }
        }

        public IEnumerable<Evento> GetAll()
        {
            return _context.eventos.Include(a => a.Disciplina).Include(e => e.EventoAtletas).ThenInclude(ea => ea.Atleta).ToList();
        }

        public Evento GetById(int id)
        {
            Evento? e = null;
            e =
                _context.eventos
            .AsEnumerable()
                .FirstOrDefault(e => e.ID == id);
            if (e == null)
            {
                throw new Exception($"No se encontro el evento con id {id}");
            }
            return e;
        }

        public Evento GetByName(string nombre)
        {
            Evento? e = null;
            e =
                _context.eventos
            .AsEnumerable()
                .FirstOrDefault(e => e.Nombre == nombre);
            if (e == null)
            {
                throw new Exception($"No se encontro la discipina con nombre {nombre}");
            }
            return e;
        }

        public bool EventoExist(string nombre)
        {
            Evento? e = null;
            e =
                _context.eventos
                .AsEnumerable()
                .FirstOrDefault(e => e.Nombre == nombre);
            return e != null;
        }

        public IEnumerable<Evento> GetAllFiltered(int? disciplinaId, DateTime? fechaInicio, DateTime? fechaFin, string nombreEvento, int? puntajeMinimo, int? puntajeMaximo)
        {
            var eventos = GetAll();

            // Aplicar filtros

            // Filtro por Disciplina
            if (disciplinaId.HasValue)
            {
                eventos = eventos.Where(e => e.DisciplinaId == disciplinaId.Value);
            }

            // Filtro por Rango de Fechas (inicio y fin)
            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                if (fechaFin > fechaInicio)
                {
                    throw new EventoException("La fecha de inicio no puede ser menor a la de fin");
                }
                eventos = eventos.Where(e => e.Inicio <= fechaInicio.Value && e.Fin >= fechaFin.Value);
            }
            else if (fechaInicio.HasValue)
            {
                eventos = eventos.Where(e => e.Inicio >= fechaInicio.Value);
            }
            else if (fechaFin.HasValue)
            {
                eventos = eventos.Where(e => e.Fin <= fechaFin.Value);
            }

            // Filtro por Nombre del Evento (búsqueda parcial)
            if (!string.IsNullOrEmpty(nombreEvento))
            {
                eventos = eventos.Where(e => e.Nombre.Contains(nombreEvento, StringComparison.OrdinalIgnoreCase));
            }

            // Filtro por Rango de Puntajes (mínimo y máximo)
            if (puntajeMinimo.HasValue || puntajeMaximo.HasValue)
            {
                eventos = eventos.Where(e => e.EventoAtletas.Any(a =>
                    (puntajeMinimo.HasValue && a.Puntaje >= puntajeMinimo.Value) &&
                    (puntajeMaximo.HasValue && a.Puntaje <= puntajeMaximo.Value)
                ));
            }

            // Ejecutar la consulta y retornar los resultados
            return eventos;
        }
    }
}
