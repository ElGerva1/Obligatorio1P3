using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.MappersDisciplina;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorio;
using ComiteLogicaNegocio.InterfacesRepositorios;

namespace ComiteLogicaAplicacion.CasoUso.Disciplinas
{
    public class EliminarDisciplina : IEliminarLogs<DisciplinasAltaDto>
    {
        IRepositorioDisciplina _repositorio;
        IRepositorioLog _repositorioLog;


        public EliminarDisciplina(IRepositorioDisciplina repositorio, IRepositorioLog repositorioLog)
        {
            _repositorio = repositorio;
            _repositorioLog = repositorioLog;
        }

        public int Ejecutar(DisciplinasAltaDto obj, string emailUser)
        {
            try
            {
                _repositorio.Delete(DisciplinaMapper.FromDto(obj));
                _repositorioLog.Add(new Log(emailUser, obj.ToString(), "ELIMINAR", "Disciplina"));

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el disciplina");
            }

        }
    }
}
