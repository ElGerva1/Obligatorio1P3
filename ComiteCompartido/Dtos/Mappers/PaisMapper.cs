using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.Paises;
using ComiteLogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteCompartido.Dtos.Mappers
{
    public class PaisMapper
    {
        public static Pais FromDto(PaisAltaDto item)
        {
            return new Pais(item.id, item.NombrePais, item.CantidadHabitantes,
                item.NombreContacto,
                item.TelefonoContacto);
        }

        public static PaisAltaDto ToDto(Pais? item)
        {
            return new PaisAltaDto(
                item.ID,
                item.NombrePais,
                item.CantidadHabitantes,
                item.NombreContacto,
                item.TelefonoContacto
            );
        }

        public static IEnumerable<PaisListadoDto> ToListaDto(IEnumerable<Pais> items)
        {

            List<PaisListadoDto> dtos = new List<PaisListadoDto>();

            foreach (Pais item in items)
            {
                dtos.Add(new PaisListadoDto(
                        item.ID,
                        item.NombrePais,
                        item.CantidadHabitantes,
                        item.NombreContacto,
                        item.TelefonoContacto
                    ));
            }

            return dtos;
        }
    }
}
