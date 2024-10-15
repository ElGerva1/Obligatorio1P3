using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteCompartido.Dtos.Atletas
{
    public record AtletaListadoDto(
        int id,
        string Nombre,
        string Sexo,
        int paisId, 
        string NombrePais,
        List<String> Disciplinas,
        List<int> DisciplinasIds)
    {
    }
}
