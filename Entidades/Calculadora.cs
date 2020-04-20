using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        /// <summary>
        /// Metodo realiza una opertacion con los parametros que recibe
        /// </summary>
        /// <param name="num1">tipo Numero</param>
        /// <param name="num2">tipo Numero</param>
        /// <param name="operador">string</param>
        /// <returns>double como respuesta a la operacion</returns>
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


        /// <summary>
        /// Metodo estatico, valida que el parametro sea un tipo de operador aritmético 
        /// </summary>
        /// <param name="operador">string</param>
        /// <returns>string con el operador aritmetico</returns>
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
