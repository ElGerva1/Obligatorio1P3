using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioAtleta : IRepositorio<Atleta>
    {
        void Edit(Atleta obj);
        IEnumerable<Atleta> GetByDiscipline(int id);
    }
}
