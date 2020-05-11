using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        private ETamanio tamanio;

        /// <summary>
        /// Constructor, llama a base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color): base(chasis,marca,color)
        {
            tamanio = ETamanio.Grande;
        }
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected  ETamanio Tamanio
        {
            get
            {
                return this.tamanio;
            }
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public new string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine($"CHASIS: {this.Chasis}");
            sb.AppendLine($"MARCA: { this.Tamanio}");
            sb.AppendLine($"COLOR: {this.Color}");
            sb.AppendLine("---------------------");
            sb.AppendLine($"TAMAÑO: {this.Tamanio}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
