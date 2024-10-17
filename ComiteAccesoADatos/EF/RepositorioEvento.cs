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
            return _context.eventos.Include(a => a.Disciplina).ToList();
        }

        public Evento GetById(int id)
        {
            Evento? e = null;
            e =
                _context.eventos.Include(e=>e.atletas)
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

        public void AgregarAtletaAlEvento(Atleta atleta)
        {
            throw new NotImplementedException();
        }
    }
}
