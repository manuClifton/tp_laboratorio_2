using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        private EMarca marca;
        private string chasis;
        private ConsoleColor color;



        /// <summary>
        /// Constructor, asigna valor a los atributos con los argumentos resividos
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
            
            
        }


        /// <summary>
        /// ReadOnly: Retornará el chasis
        /// </summary>
        protected string Chasis
        {
            get { return this.chasis; }
        }
        /// <summary>
        /// ReadOnly: Retornará el color
        /// </summary>
        protected ConsoleColor Color
        {
            get { return this.color; }
        }
        /// <summary>
        /// ReadOnly: Retornará el marca
        /// </summary>
        protected EMarca Marca
        {
            get { return this.marca; }
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.marca}");
            sb.AppendLine($"{this.color}");
            sb.AppendLine($"{this.chasis}");
            return sb.ToString();
        }

        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: { p.chasis}");
            sb.AppendLine($"MARCA : {p.marca}");
            sb.AppendLine($"COLOR : {p.color}");
            sb.AppendLine("---------------------");


            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (!(v1 is null) && v1.chasis == v2.chasis)
            {

               return true;
            }
            return false;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }
    }
}
