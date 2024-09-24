using ComiteLogicaNegocio.Vo.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.Entidades
{
    public class Admin : Usuario
    {
        protected Admin()
        {
        }

        public Admin(int id, string email, string password) : base(id, new Email(email), new Password(password))
        {
        }
    }
}
