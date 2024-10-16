﻿using ComiteLogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteCompartido.Dtos.Eventos
{
    public record EventoAltaDto(
    int id,
    Disciplina Disciplina,
    string Nombre,
    DateTime Inicio,
    DateTime Fin
    )
    {
    }
}
