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


        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero) : this(numero.ToString())
        {

        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }


        public string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }

        private double ValidarNumero(string strNumero)
        {
            if(double.TryParse(strNumero, out double resut))
            {
                return double.Parse(strNumero);
            }
            return 0;
        }

        public string InvertirString(string str)
        {
            StringBuilder retorno = new StringBuilder();

            for (int i = str.Length; i > 0; i--)
            {
                retorno.Append(str[i - 1]);
            }
            return retorno.ToString();
        }

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
                    break;
                }
            }


            return acumulador.ToString();
        }

        public string DecimalBinario(double numero)
        {
           return this.DecimalBinario(numero.ToString());
        }

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
                    retorno.Append(binario[i-1]);
                }
               
                return retorno.ToString();
            }
            else
            {
                return "No Valido";
            }
        }



        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }


        public static explicit operator double(Numero num)
        {
            return num.numero;
        }


        public static explicit operator int(Numero num)
        {
            return (int)num.numero;
        }




    }//
}//
