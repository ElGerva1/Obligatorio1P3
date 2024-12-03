
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteCompartido.Dtos.MappersDisciplina;
using ComiteLogicaNegocio.InterfacesRepositorio;

namespace ComiteLogicaAplicacion.CasoUso.Disciplinas
{
    public class EditarDisciplina : IEditarLogs<DisciplinasAltaDto>
    {
        IRepositorioDisciplina _repositorio;
        IRepositorioLog _repositorioLog;

        public EditarDisciplina(IRepositorioDisciplina repositorio, IRepositorioLog repositorioLog)
        {
            _repositorio = repositorio;
            _repositorioLog = repositorioLog;
        }

        public int Ejecutar(DisciplinasAltaDto obj, string emailUser)
        {
            try
            {
                _repositorioLog.Add(new Log(emailUser, obj.ToString(), "EDITAR", "Disciplina"));
                _repositorio.Edit(DisciplinaMapper.FromDto(obj));
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la disciplina");
            }

        }
    }
}
