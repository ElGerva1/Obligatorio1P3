
using ComiteLogicaNegocio.InterfacesRepositorio;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteLogicaNegocio.Entidades;
using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Mappers;
using Microsoft.EntityFrameworkCore;

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

        public void Ejecutar(AtletaAltaDto atleta, int disciplinaId)
        {
            atleta.DisciplinasIds.Add(disciplinaId);
            Atleta a = _repositorio.GetById(atleta.id);
            var disciplina = _disiplinas.GetById(disciplinaId);
            if (disciplina != null && !a.Disciplinas.Contains(disciplina))
            {
                a.Disciplinas.Add(disciplina);
            }
        }

    }
}
