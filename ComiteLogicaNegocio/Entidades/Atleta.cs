using ComiteLogicaNegocio.Vo.Generic;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComiteLogicaNegocio.Entidades
{
    public class Atleta
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        
        public Pais Pais { get; set; }

        public int PaisId { get; set; }

        public List<Disciplina> Disciplinas { get; set; }
        public List<int> DisciplinasIds { get; set; }


        public Atleta() { }

        public Atleta(int iD, string nombre, string sexo, int paisId, List<int> disciplinasIds)
        {
            ID = iD;
            Nombre = nombre;
            Sexo = sexo;
            PaisId = paisId;
            DisciplinasIds = disciplinasIds;
            Disciplinas = new List<Disciplina>();
        }
    }
}
