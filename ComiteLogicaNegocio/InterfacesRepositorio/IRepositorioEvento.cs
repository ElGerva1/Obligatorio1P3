using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEvento : IRepositorio<Evento>
    {
        Evento GetByName(string nombre);
        IEnumerable<Evento> GetAllFiltered(
                int? disciplinaId,
                DateTime? fechaInicio,
                DateTime? fechaFin,
                string nombreEvento,
                int? puntajeMinimo,
                int? puntajeMaximo
        );
    }
}
