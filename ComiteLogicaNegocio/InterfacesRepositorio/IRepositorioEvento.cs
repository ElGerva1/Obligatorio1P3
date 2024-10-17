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
        public void AgregarAtletaAlEvento(Atleta atleta);
    }
}
