using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    /// <summary>
    /// Clase Jornada, contiene lista de alumnos, enumerado de tipo de clase y un profesor.
    /// </summary>
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Constructor sin paremetros inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Inicializa la clase Jornada con los valores recibidos como parametro.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) :this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }

        /// <summary>
        /// Retorna y sobreescribe la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Retorna y sobreescribe la clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        /// <summary>
        /// Retorna y sobreescribe la lista de profesores.
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        /// <summary>
        /// Guarda la informacion de la jornada (en jornada.txt) recibida en formato texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto t = new Texto();
                string file_name = AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt";
                return t.Guardar(file_name, jornada.ToString());
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Archivos Exception", ex);
            }
        }
        /// <summary>
        /// Lee los datos de guardados de la jornada (en jornada.txt) y los retorna en una cadena.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            try
            {
                Texto t = new Archivos.Texto();
                string texto;
                string file_name = AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt";
                t.Leer(file_name, out texto);
                return texto;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Archivos Exception", ex);
            }
        }
        /// <summary>
        ///  Retorna una cadena con loas datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Clase == Universidad.EClases.Laboratorio)
            {
                sb.AppendLine("JORNADA:");
            }
            sb.AppendLine($"CLASE DE {this.Clase} POR NOMBRE COMPLETO: {this.Instructor}");
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine($"NOMBRE COMPLETO: {item.ToString()}");
            }
            sb.AppendLine("<---------------------------------------------->\n");
            return sb.ToString();
        }
        /// <summary>
        /// Una jornada sera igual a un alumno, si este se encuentra en su lista de alumnos.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.alumnos.Contains(a);
        }
        /// <summary>
        /// Una jornada sera diferente a un alumno, si este no se encuentra en su lista de alumnos.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Al sumar un alumno a una jornada, si este no se encuentra en la lista de alumnos, sera agregado a la misma.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if ( j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }




    }//
}//
