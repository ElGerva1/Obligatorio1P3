using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteLogicaNegocio.Vo.Generic;

namespace ComiteCompartido.Dtos.MappersDisciplina
{
    public class DisciplinaMapper
    {
        public static Disciplina FromDto(DisciplinasAltaDto item)
        {
            return new Disciplina(item.Id, item.Nombre, item.Year);
        }
        public static DisciplinasAltaDto ToDto(Disciplina? item)
        {
            return new DisciplinasAltaDto(
                    item.ID,
                    item.Nombre,
                    item.Year
            );
        }
        public static IEnumerable<DisciplinasListadoDto> ToListaDto(IEnumerable<Disciplina> items)
        {            

            List<DisciplinasListadoDto> dtos = new List<DisciplinasListadoDto>();

            foreach (Disciplina item in items)
            {
                dtos.Add(new DisciplinasListadoDto(
                    item.ID,
                    item.Nombre,
                    item.Year
                    ));
            }

            return dtos;
        }


    }

}
