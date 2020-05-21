using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {


        List<Vehiculo> vehiculos;
        int espacioDisponible;


        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #region "Constructores"
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Estacionamiento(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tenemos {c.vehiculos.Count} lugares ocupados de un total de {c.espacioDisponible} disponibles" );
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if (v is Camioneta )
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    case ETipo.Moto:
                        if(v is Moto)
                        {
                            sb.AppendLine(v.Mostrar());
                        }   
                        break;

                    case ETipo.Automovil:
                        if (v is Automovil)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="estacionamiento">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento estacionamiento, Vehiculo vehiculo)//// arreglar que no sume si son iguales
        {
            int contador = 0;
            for (int i = 0; i < estacionamiento.vehiculos.Count; i++)
            {
                if (estacionamiento.vehiculos[i] == vehiculo)
                {
                    contador++;
                }
            }
            if (contador == 0 && estacionamiento.vehiculos.Count < estacionamiento.espacioDisponible)
            {
                estacionamiento.vehiculos.Add(vehiculo);
            }

            return estacionamiento;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="estacionamiento">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento estacionamiento, Vehiculo vehiculo)// REVISAR QUE RESTE
        {

            for (int i = 0; i < estacionamiento.vehiculos.Count; i++)
            {
                if (estacionamiento.vehiculos[i] == vehiculo)
                {
                    estacionamiento.vehiculos.Remove(estacionamiento.vehiculos[i]);
                    break;
                }
            }


            return estacionamiento;
        }
        #endregion
    }
}
