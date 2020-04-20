using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            operador = ValidarOperador(operador);
   
            if(operador == "-")
            {
                return num1 - num2;
            }
            else if (operador == "*")
            {
                return num1 * num2;
            }
            else if (operador == "/")
            {
                if ((double)num2 == 0)
                {
                    return double.MinValue;
                }
                else
                {
                    return num1 / num2;
                }
            }
            else
            {
                return num1 + num2;
            }
        }

        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }








    }//
}//
