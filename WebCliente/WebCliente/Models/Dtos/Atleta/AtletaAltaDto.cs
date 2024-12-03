using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCliente.Models.Dtos.Atletas
{
    public record AtletaAltaDto(
        int id,
        string Nombre,
        string Sexo,
        int paisId,
        List<int> DisciplinasIds
        )
    {
    }
}
