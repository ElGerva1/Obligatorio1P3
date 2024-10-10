
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
                item.paisId);
        }

        public static AtletaAltaDto ToDto(Atleta? item)
        {
            return new AtletaAltaDto(
                item.ID,
                item.Nombre,
                item.Sexo,
                item.PaisId
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
                        item.Pais.NombrePais
                    ));
            }

            return dtos;
        }
    }
}
