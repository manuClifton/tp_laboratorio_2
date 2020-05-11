using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        private ETamanio tamanio;
        /// <summary>
        /// Constructor, llama a base
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Moto(EMarca marca, string chasis, ConsoleColor color):base(chasis,marca,color)
        {
        }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected ETamanio Tamanio
        {
            get
            {
                return this.Tamanio;
            }
        }

        /// <summary>
        /// Publica todos los datos de la MOTO.
        /// </summary>
        /// <returns></returns>
        public new string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
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
