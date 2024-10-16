using ComiteLogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteCompartido.Dtos.Eventos
{
    public record EventoListadoDto(
        int id,
        string NombreDisciplina,
        string Nombre,
        DateTime Inicio,
        DateTime Fin
    )
    {
    }
}
