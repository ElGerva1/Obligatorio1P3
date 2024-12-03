using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCliente.Models.Dtos.Paises
{
    public record PaisListadoDto(
        int id,
        string NombrePais,
        int CantidadHabitantes,
        string NombreContacto,
        string TelefonoContacto)
    {
    }
}
