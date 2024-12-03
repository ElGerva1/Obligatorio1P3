using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.Entidades
{
    public class Pais
    {
        public int ID { get; set; } 
        public string NombrePais { get; set; }

        public int CantidadHabitantes { get; set; }

        public string NombreContacto { get; set; }
        public string TelefonoContacto { get; set; }

        public Pais() { }
        public  Pais(int iD, string nombrePais, int cantidadHabitantes, string nombreContacto, string telefonoContacto)
        {
            ID = iD;
            NombrePais = nombrePais;
            CantidadHabitantes = cantidadHabitantes;
            NombreContacto = nombreContacto;
            TelefonoContacto = telefonoContacto;
        }
    }
}
