using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.Entidades
{
    public class Disciplina
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Year { get; set; }

        public List<Atleta> Atletas { get; set; }

        public Disciplina() { }

        public Disciplina(int id, string nombre, int year)
        {
            ID = id;
            Nombre = nombre;
            Year = year;
        }
    }
}
