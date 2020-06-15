using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    /// <summary>
    /// Clase sellada de Profesor derivada Universitario.
    /// </summary>
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Inicializa la clase Profesor con los valores default. 
        /// </summary>
        public Profesor() : base()
        {

        }
        /// <summary>
        /// Inicializa el atributo estatico random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Inicializa la clase Profesor con los valores recibidos como parametro.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases(); 
        }
        /// <summary>
        /// Retorna una cadena con el nombre completo de la persona, su nacionalidad, legajo y clases del dia del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Retorna una cadena con el nombre completo de la persona, su nacionalidad, legajo y clases del dia del Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// Retorna una cadena con las clases del dia del Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
              sb.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Agrega a la cola de clases del dia del profesor, 2 clases aleatorias.
        /// </summary>
        private void _randomClases()
        {
            int catidad = Enum.GetNames(typeof(Universidad.EClases)).Length;

            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)(random.Next(catidad)));
            }
        }
        /// <summary>
        /// Un profesor sera igual a una clase, si la misma se encuentra en la cola de clases del dia.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }
        /// <summary>
        /// Un profesor sera diferente a una clase, si la misma no se encuentra en la cola de clases del dia.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }


    }//
}//
