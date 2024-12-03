using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Mappers;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaAplicacion.CasoUso.CasoUsoAtleta
{
    public class ObtenerAtleta : IObtener<AtletaAltaDto>
    {
        IRepositorioAtleta _repositorio;

        public ObtenerAtleta(IRepositorioAtleta repositorio)
        {
            _repositorio = repositorio;
        }
        public AtletaAltaDto Ejecutar(int id)
        {
            return AtletaMapper.ToDto(_repositorio.GetById(id));
        }

        public AtletaAltaDto Ejecutar(string s)
        {
            throw new NotImplementedException();
        }
    }
}
