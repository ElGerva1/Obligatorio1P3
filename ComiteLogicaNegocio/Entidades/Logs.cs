using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.Entidades
{
    public class Log
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Operation { get; set; }
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }

        public Log() { }

        public Log(string email, string message, string operation, string tableName)
        {
            Email = email;
            Message = message;
            Operation = operation;
            TableName = tableName;
            DateTime = DateTime.Now;
        }
    }
}
