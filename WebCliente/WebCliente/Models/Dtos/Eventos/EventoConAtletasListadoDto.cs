using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCliente.Models.Dtos.Eventos
{
    public record EventoConAtletaListadoDto(
        int id,
        string NombreDisciplina,
        string Nombre,
        DateTime Inicio,
        DateTime Fin, 
        List<EventoAtletaDto> puntajes
    )
    {
    }
}
