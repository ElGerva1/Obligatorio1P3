using WebCliente.Models.Dtos.Atletas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCliente.Models.Dtos.Eventos
{
    public record EventoAtletaDto(AtletaAltaDto atleta, decimal puntaje)
    {
    }
}
