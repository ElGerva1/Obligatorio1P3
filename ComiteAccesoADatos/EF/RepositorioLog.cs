using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteAccesoADatos.EF
{
    public class RepositorioLog : IRepositorioLog
    {
        private ComiteContext _context;

        public RepositorioLog(ComiteContext context)
        {
            _context = context;
        }

        public void Add(Log obj)
        {

            Type objectType = obj.GetType();
            // Mostrar el nombre de la clase
            Console.WriteLine($"El objeto es de la clase: {objectType.Name}");
            _context.Logs.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Log> GetAll()
        {
            throw new NotImplementedException();
        }

        public Log GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
