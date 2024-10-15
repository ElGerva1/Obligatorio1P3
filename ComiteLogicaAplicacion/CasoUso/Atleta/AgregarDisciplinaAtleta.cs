
using ComiteLogicaNegocio.InterfacesRepositorio;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteLogicaNegocio.Entidades;
using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Mappers;

namespace ComiteLogicaAplicacion.CasoUso.AtletaAgregarDisciplina
{
    public class AgregarDisciplinaAtleta
    {
        IRepositorioAtleta _repositorio;
        IRepositorioDisciplina _disiplinas;

        public AgregarDisciplinaAtleta(IRepositorioAtleta repositorio, IRepositorioDisciplina disciplinas)
        {
            _repositorio = repositorio;
            _disiplinas = disciplinas;
        }

        public void Ejecutar(AtletaAltaDto obj, int DisciplinaId)
        {
            obj.DisciplinasIds.Add(DisciplinaId);
        }
    }
}
