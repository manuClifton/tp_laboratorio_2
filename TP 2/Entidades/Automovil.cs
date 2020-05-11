using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
 
    public class Automovil : Vehiculo
    {
        public enum ETipo { Monovolumen, Sedan }

        private ETipo tipo;
        private ETamanio tamanio;

        /// <summary>
        /// Constructor llama a base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tamanio = ETamanio.Mediano;
            if (marca == EMarca.Toyota)
            {
                tipo = ETipo.Monovolumen;
            }
            if (marca == EMarca.Chevrolet)
            {
                tipo = ETipo.Sedan;
            }

        }

        /// <summary>
        ///  Setea el TIPO por el argumento resivido
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo):this(marca,chasis,color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected ETamanio Tamanio
        {
            get
            {
                return this.Tamanio;
            }
        }

        public new string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine($"CHASIS: {this.Chasis}");
            sb.AppendLine($"MARCA: { this.Tamanio}");
            sb.AppendLine($"COLOR: {this.Color}");
            sb.AppendLine("---------------------");
            sb.AppendLine($"TAMAÑO: {this.Tamanio} TIPO: {this.tipo}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
