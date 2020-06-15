using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase abstracta Universitario derivada de Persona
    /// </summary>
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Inicializa la clase Universitario con los valores default. 
        /// </summary>
        public Universitario() :base()
        {

        }
        /// <summary>
        /// Inicializa la clase Universitario con los valores recibidos como parametro.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.Legajo = legajo;
        }
        /// <summary>
        /// Get / Set del legajo
        /// </summary>
        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }
        /// <summary>
        /// El objeto sera equivalente, si es del tipo Universitario y si el Dni o Legajo son iguales.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj.GetType() == typeof(Universitario) && this == (Universitario)obj);
        }
        /// <summary>
        /// Retorna una cadena con el nombre completo de la persona, su nacionalidad y legajo.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append($"LEGAJO NúMERO: {this.legajo}");
            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Seran iguales si son del mismo tipo y el Dni o Legajo son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
            

        }
        /// <summary>
        /// Seran diferentes no son del mismo tipo o si el Dni o Legajo son diferentes.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }



    }//
}//
