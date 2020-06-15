using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        /// <summary>
        /// Nacionalidad de las personas
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #region Constructores

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona()
        {

        }

        /// <summary>
        /// Inicializa la clase Persona con los valores recibidos como parametro.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Setea el DNI de la clase Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Setea el DNI de la clase Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion
        /// <summary>
        /// Get y Set de Apellido. Valida que sean cadenas con caracteres válidos para apellidos 
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        /// Get y Set de Nombre. Valida que sean cadenas con caracteres válidos para nombres 
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        /// /// <summary>
        /// Get y Set de DNI. Valida que sea Dni valido
        /// </summary>
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = this.ValidarDni(this.nacionalidad, value); }
        }
        /// <summary>
        /// Set de DNI. Valida que sea Dni valido
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = this.ValidarDni(this.nacionalidad, value); }
        }
        /// <summary>
        /// Get y Set de Nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Sobrecarga de metodo ToString. Retorna una cadena con el nombre completo de la persona y su nacionalidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.apellido}, {this.nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");

            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino &&
                dato >= 1 && dato <= 89999999) ||
                (nacionalidad == ENacionalidad.Extranjero &&
                dato >=90000000 && dato <= 99999999) )
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            bool dniCorrecto = Regex.IsMatch(dato, @"^[0-9]+$");
            if (int.TryParse(dato, out int numero) && dato.Length <= 8 && dniCorrecto)
            {
                return this.ValidarDni(nacionalidad, numero);
            }
            else
            {
                throw new DniInvalidoException("El DNI debe contener solo números.");
            }
        }
        private string ValidarNombreApellido(string dato)
        {
            bool datoCorrecto = Regex.IsMatch(dato, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ ]+$");
            if (datoCorrecto)
            {
                return dato;
            }
            else
            {
                return "Error. Dato Invalido";
            }
        }




    }//
}//
