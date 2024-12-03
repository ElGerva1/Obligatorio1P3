using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.MappersDisciplina;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.CasoUso.Disciplinas
{
    public class ObtenerDisciplina : IObtener<DisciplinasAltaDto>
    {
        IRepositorioDisciplina _repositorio;

        public ObtenerDisciplina(IRepositorioDisciplina repositorio)
        {
            _repositorio = repositorio;
        }
        public DisciplinasAltaDto Ejecutar(int id)
        {
            return DisciplinaMapper.ToDto(_repositorio.GetById(id));
        }
        public DisciplinasAltaDto Ejecutar(string nombre)
        {
            return DisciplinaMapper.ToDto(_repositorio.GetByName(nombre));
        }
    }
}
