
using ComiteCompartido.Dtos.Mappers;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteCompartido.Dtos.MappersDisciplina;
using ComiteLogicaNegocio.InterfacesRepositorio;

namespace ComiteLogicaAplicacion.CasoUso.Disciplinas
{
    public class AltaDisciplina : IAltaLogs<DisciplinasAltaDto>
    {
        IRepositorioDisciplina _repositorio;
        IRepositorioLog _repositorioLog;

        public AltaDisciplina(IRepositorioDisciplina repositorio, IRepositorioLog repositorioLog) 
        {
            _repositorio = repositorio;
            _repositorioLog = repositorioLog;
        }

        public int Ejecutar(DisciplinasAltaDto obj, string emailUser)
        {
            _repositorio.Add(DisciplinaMapper.FromDto(obj));
            _repositorioLog.Add(new Log(emailUser, obj.ToString(), "ALTA", "Disciplina"));
            return obj.Id;
        }
    }
}
