using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        
        /// <summary>
        /// Constructor por defecto, asigna valor cero a el atributo numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// constructor con sobrecarga de constructor
        /// </summary>
        /// <param name="numero">double</param>
        public Numero(double numero) : this(numero.ToString())
        {

        }

        /// <summary>
        /// Constructor, setea el valor a el parametro que resive con un metodo set
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// metodo setNumero, setea el valor resivido con el metodo ValidarNumero
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }

        /// <summary>
        /// metodo que de ser posible convierte un string en double
        /// </summary>
        /// <param name="strNumero">string</param>
        /// <returns>return double o 0</returns>
        private double ValidarNumero(string strNumero)
        {
            if(double.TryParse(strNumero, out double resut))
            {
                return double.Parse(strNumero);
            }
            return 0;
        }

        /// <summary>
        /// Metodo que resive un string y lo invierte
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public string InvertirString(string str)
        {
            StringBuilder retorno = new StringBuilder();

            for (int i = str.Length; i > 0; i--)
            {
                retorno.Append(str[i - 1]);
            }
            return retorno.ToString();
        }


        /// <summary>
        /// Metodo que convierte numeros binarios en decimales y lo devuelve como string
        /// </summary>
        /// <param name="binario">string</param>
        /// <returns>string</returns>
        public string BinarioDecimal(string binario)
        {
            binario = this.InvertirString(binario);
            int acumulador = 0;
            int bit = 0;
            for (int i = 0; i < binario.Length; i++)
            {
                if (int.TryParse(binario.Substring(i,1), out bit))
                {
                    
                    acumulador += (int)(bit * Math.Pow(2,i));
                }
                else
                {
                    return "Valor inválido";
                }
            }


            return acumulador.ToString();
        }


        /// <summary>
        /// Metodo que convierte un numero decimal enun binario, llama a una sobrecarga del metodo
        /// </summary>
        /// <param name="numero">double</param>
        /// <returns>string</returns>
        public string DecimalBinario(double numero)
        {
           return this.DecimalBinario(numero.ToString());
        }


        /// <summary>
        /// Metodo que convierte un numero decimal en binario y lo devuelve como string
        /// </summary>
        /// <param name="numero">string</param>
        /// <returns>string</returns>
        public string DecimalBinario(string numero)
        {
            int numDecimal;
            StringBuilder binario = new StringBuilder();
            int resto = 0;
            if (int.TryParse(numero, out numDecimal))
            {
                numDecimal = int.Parse(numero);
                numDecimal = Math.Abs(numDecimal);
                // Agrego los valores al binario

                while (numDecimal >= 2)
                {
                    resto = numDecimal % 2;
                    binario.Append(resto.ToString());
                    numDecimal /= 2;      
                }
                if (numDecimal == 0)
                {
                    binario.Append("0");
                }
                else {
                    binario.Append("1");
                }

                // guardo en otro string los datos al reves 
                StringBuilder retorno = new StringBuilder();

                for (int i = binario.Length; i > 0; i--)
                {
                    retorno.Append(binario[i - 1]);
                }


                return retorno.ToString();
            }
            else
            {
                return "No Valido";
            }
        }


        /// <summary>
        /// Metodo que sobrecarga el operador  "Sustracción"
        /// </summary>
        /// <param name="n1">tipo Numero</param>
        /// <param name="n2">Tipo Numero</param>
        /// <returns>double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Metodo que sobrecarga el operador  "Adición"
        /// </summary>
        /// <param name="n1">tipo Numero</param>
        /// <param name="n2">Tipo Numero</param>
        /// <returns>double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Metodo que sobrecarga el operador  "Multiplicación"
        /// </summary>
        /// <param name="n1">tipo Numero</param>
        /// <param name="n2">tipo Numero</param>
        /// <returns>double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }


        /// <summary>
        /// Metodo que sobrecarga el operador  "División"
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Metrodo explicito para igualar una clase Numero con un double
        /// </summary>
        /// <param name="num">tipo Numero</param>
        public static explicit operator double(Numero num)
        {
            return num.numero;
        }

        /// <summary>
        /// Metodo explicito para igualar una clase Numero con un ENTERO
        /// </summary>
        /// <param name="num"></param>
        public static explicit operator int(Numero num)
        {
            return (int)num.numero;
        }





    }//
}//
