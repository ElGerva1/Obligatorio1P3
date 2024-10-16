using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Evento> GetAll()
        {
            return _context.eventos.Include(a => a.Disciplina).ToList();
        }

        public Evento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Evento GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
