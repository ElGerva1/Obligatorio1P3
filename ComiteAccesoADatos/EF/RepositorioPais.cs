using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteAccesoADatos.EF
{
    public class RepositorioPais : IRepositorioPais
    {
        private ComiteContext _context;

        public RepositorioPais(ComiteContext context)
        {
            _context = context;
        }
        public void Add(Pais obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("No se recibio pais vàlido");
            }
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Pais> GetAll()
        {
            return _context.paises;
        }

        public Pais GetById(int id)
        {
            Pais? p = null;
            p =
                _context.paises
                .FirstOrDefault(pais => pais.ID == id);
            if (p == null)
            {
                throw new Exception($"No se encontro la el pais con id {id}");
            }
            return p;
        }
    }
}
