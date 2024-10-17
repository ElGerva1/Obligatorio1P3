using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.Entidades
{
    public class EventoAtleta
    {
        public int ID { get; set; }
        public Evento Evento { get; set; }
        public int EventoId { get; set; }
        public Atleta Atleta { get; set; }
        public int AtletaId { get; set; }
        public decimal Puntaje { get; set; }

        protected EventoAtleta() { }

        public EventoAtleta(int iD, int evento, int atleta, decimal puntaje)
        {
            ID = iD;
            EventoId = evento;
            AtletaId = atleta;
            Puntaje = puntaje;
        }
    }
}
