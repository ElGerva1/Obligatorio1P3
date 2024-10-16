using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorio;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> GetAll()
        {
            throw new NotImplementedException();
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
