
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteCompartido.Dtos.MappersDisciplina;

namespace ComiteLogicaAplicacion.CasoUso.Disciplinas
{
    public class AltaDisciplina : IAlta<DisciplinasAltaDto>
    {
        IRepositorioDisciplina _repositorio;

        public AltaDisciplina(IRepositorioDisciplina repositorio) 
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(DisciplinasAltaDto obj)
        {
            _repositorio.Add(DisciplinaMapper.FromDto(obj));
        }
    }
}
