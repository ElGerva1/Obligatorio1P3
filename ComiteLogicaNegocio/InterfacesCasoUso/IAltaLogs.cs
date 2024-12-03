using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.InterfacesCasoUso
{
    public interface IAltaLogs<T>
    {
        int Ejecutar(T obj, string emailUser);
    }
}
