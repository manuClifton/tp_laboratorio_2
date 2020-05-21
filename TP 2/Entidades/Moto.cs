using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {

        int numero = 1;
        /// <summary>
        /// Constructor, llama a base
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Moto(EMarca marca, string chasis, ConsoleColor color):base(chasis,marca,color)
        {
            this.Tamanio = ETamanio.Chico;
        }



        /// <summary>
        /// Publica todos los datos de la MOTO.
        /// </summary>
        /// <returns></returns>
        /// 
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MOTO");
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }

        //public override string Mostrar()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine("MOTO");
        //    sb.Append($"{base.Mostrar()}");
        //    sb.AppendLine("---------------------");
        //    sb.AppendLine($"TAMAÑO: {this.Tamanio}");
        //    sb.AppendLine("---------------------");

        //    return sb.ToString();
        //}
    }
}
