
using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.Vo.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteCompartido.Dtos.Mappers
{
    public class AtletaMapper
    {
        public static Atleta FromDto(AtletaAltaDto item)
        {
            return new Atleta(item.id,
                item.Nombre,
                item.Sexo,
                item.paisId,
                item.DisciplinasIds);
        }

        public static AtletaAltaDto ToDto(Atleta item)
        {
            return new AtletaAltaDto(
                item.ID,
                item.Nombre,
                item.Sexo,
                item.PaisId,
                item.Disciplinas,
                item.Disciplinas?.Select(d => d.ID).ToList() ?? new List<int>()
            );
        }

        public static IEnumerable<AtletaListadoDto> ToListaDto(IEnumerable<Atleta> items)
        {

            List<AtletaListadoDto> dtos = new List<AtletaListadoDto>();

            foreach (Atleta item in items)
            {
                dtos.Add(new AtletaListadoDto(
                        item.ID,
                        item.Nombre,
                        item.Sexo,
                        item.PaisId,
                        item.Pais.NombrePais,
                        item.Disciplinas?.Select(d => d.Nombre).ToList() ?? new List<string>(), // Default to an empty list if null
                        item.DisciplinasIds
                    ));
            }

            return dtos;
        }
    }
}
