using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InsertarEnDBExeption : Exception
    {
        public InsertarEnDBExeption(string mensaje) 
            : base(mensaje)
        {

        }
        public InsertarEnDBExeption(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }

    }//
}//
