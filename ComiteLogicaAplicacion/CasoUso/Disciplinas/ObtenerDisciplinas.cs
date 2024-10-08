using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.MappersDisciplina;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;

namespace ComiteLogicaAplicacion.CasoUso.Disciplinas
{
    public class ObtenerDisciplinas : IObtenerTodos<DisciplinasListadoDto>
    {
        IRepositorioDisciplina _repositorio;

        public ObtenerDisciplinas(IRepositorioDisciplina repositorio) 
        {
            _repositorio = repositorio;
        }
        public IEnumerable<DisciplinasListadoDto> Ejecutar()
        {
            return DisciplinaMapper.ToListaDto(_repositorio.GetAll());
        }
    }
}
