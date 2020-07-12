using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class InsertarEnDBExcepcion : Exception
    {
        public InsertarEnDBExcepcion(string mensaje) 
            : base(mensaje) 
        {
        }
        public InsertarEnDBExcepcion(string mensaje, Exception inner)
            : base(mensaje, inner)
        {
        }
    }//
}//
