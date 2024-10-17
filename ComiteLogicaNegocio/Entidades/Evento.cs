using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.Entidades
{
    public class Evento
    {
        public int ID { get; set; }
        public Disciplina Disciplina { get; set; }

        public int DisciplinaId { get; set; }
        public string Nombre { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

        public List<Atleta> atletas { get; set; }

        protected Evento() { }

        public Evento(int iD, int disciplina, string nombre, DateTime inicio, DateTime fin)
        {
            ID = iD;
            DisciplinaId = disciplina;
            Nombre = nombre;
            Inicio = inicio;
            Fin = fin;
            atletas = new List<Atleta>();
        }
    }
}
