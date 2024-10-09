using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ComiteAccesoADatos.EF
{
    public class RepositorioDisciplina : IRepositorioDisciplina
    {
        private ComiteContext _context;

        public RepositorioDisciplina(ComiteContext context)
        {
            _context = context;
        }

        public void Add(Disciplina obj)
        {
            if (obj == null) 
            {
                throw new ArgumentNullException("No se recibio el usuario vàlido");
            }
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(Disciplina obj)
        {
            Disciplina d = GetById(obj.ID);
            _context.disciplinas.Remove(d);
            _context.SaveChanges();
        }

        public IEnumerable<Disciplina> GetAll()
        {
            return _context.disciplinas;
        }

        public Disciplina GetById(int id)
        {
            Disciplina? d = null;
            d =
                _context.disciplinas
                .FirstOrDefault(disciplina => disciplina.ID == id);
            if (d == null)
            {
                throw new Exception($"No se encontro la el usuario con id {id}");
            }
            return d;
        }
        public Disciplina GetByName(string nombre)
        {
            Disciplina? d = null;
            d =
                _context.disciplinas
                .AsEnumerable()
                .FirstOrDefault(d => d.Nombre == nombre);
            if (d == null)
            {
                throw new Exception($"No se encontro la discipina con email {nombre}");
            }
            return d;
        }
    }
}
