using ComiteAccesoADatos.Excepciones;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
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
                throw new DisciplinaException("No se recibio una disciplina valida");
            }
            if (DisciplinaExist(obj.Nombre)) {
                throw new DisciplinaException("La disciplina ya existe");
            }
            if (obj.Nombre.Length < 10)
            {
                throw new DisciplinaException("El nombre de disiplina debe tener 10 caracteres o mas");
            }
            if (obj.Nombre.Length > 50)
            {
                throw new DisciplinaException("El nombre de disiplina debe tener menos de 50 caracteres");
            }
            if (obj.Year > 2024)
            {
                throw new DisciplinaException("El año no puede ser mayor al actual");
            }
            try
            {
                _context.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new DisciplinaException("No se pudo agregar la disciplina");
            }

        }

        public void Delete(Disciplina obj)
        {
            try
            {
                Disciplina d = GetById(obj.ID);
                _context.disciplinas.Remove(d);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new DisciplinaException("Error al eliminar disciplina");
            }

        }

        public IEnumerable<Disciplina> GetAll()
        {
            return _context.disciplinas
               .Include(d => d.Atletas)
               .OrderBy(d => d.Nombre)
               .ToList();
        }

        public Disciplina GetById(int id)
        {
            Disciplina? d = null;
            d =
                _context.disciplinas
                .FirstOrDefault(disciplina => disciplina.ID == id);
            if (d == null)
            {
                throw new DisciplinaException($"No se encontro la disciplina con id {id}");
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
                throw new Exception($"No se encontro la discipina con nombre {nombre}");
            }
            return d;
        }
        public bool DisciplinaExist(string nombre) {
            Disciplina? d = null;
            d =
                _context.disciplinas
                .AsEnumerable()
                .FirstOrDefault(d => d.Nombre == nombre);
            return d != null;
        }
        public bool DisciplinaExiste(string nombre)
        {

            Disciplina? d = null;
            d =
                _context.disciplinas
                .AsEnumerable()
                .FirstOrDefault(disciplina => disciplina.Nombre == nombre);
            return d != null;
        }

        public void Edit(Disciplina obj)
        {
            Disciplina d = GetById(obj.ID);
            if (d == null)
            {
                throw new DisciplinaException("No se recibio disciplina valida");
            }
            if (DisciplinaExiste(obj.Nombre))
            {
                throw new DisciplinaException("Ya existe una disciplina con ese nombre");
            }
            try
            {
                d.Nombre = obj.Nombre;
                d.Year = obj.Year;
                _context.disciplinas.Update(d);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new DisciplinaException("Error al editar disciplina");
            }

        }
    }
}
