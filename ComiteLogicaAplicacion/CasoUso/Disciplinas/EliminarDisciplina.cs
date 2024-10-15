
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteCompartido.Dtos.MappersDisciplina;

namespace ComiteLogicaAplicacion.CasoUso.Disciplinas
{
    public class EliminarDisciplina : IEliminar<DisciplinasAltaDto>
    {
        IRepositorioDisciplina _repositorio;

        public EliminarDisciplina(IRepositorioDisciplina repositorio) 
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(DisciplinasAltaDto obj)
        {
            try
            {
                _repositorio.Delete(DisciplinaMapper.FromDto(obj));
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el disciplina");
            }

        }
    }
}
