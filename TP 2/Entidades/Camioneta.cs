using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {

        /// <summary>
        /// Constructor, llama a base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color): base(chasis,marca,color)
        {
            this.Tamanio = ETamanio.Grande;
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        /// 
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CAMIONETA");
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        //public new string Mostrar()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine("CAMIONETA");
        //    sb.AppendLine($"{base.Mostrar()}");
        //    sb.AppendLine("---------------------");
        //    sb.AppendLine($"TAMAÑO: {this.Tamanio}");
        //    sb.AppendLine("---------------------");

        //    return sb.ToString();
        //}
    }
}
