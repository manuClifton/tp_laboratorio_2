using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    /// <summary>
    /// Contiene listas de alumnos, profesores y jornadas.
    /// </summary>
    public class Universidad
    {
        /// <summary>
        /// Enumerado de posibles clases de la Universidad.
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornadas;

        /// <summary>
        /// Inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
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
        /// Retorna y sobreescribe la lista de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        /// <summary>
        /// Retorna y sobreescribe la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }
        /// <summary>
        /// Retorna y sobreescribe items de la lista de jornadas.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return this.jornadas[i]; }
            set { this.jornadas[i] = value; }
        }
        /// <summary>
        /// Retorna una cadena con los datos de la universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        /// <summary>
        /// Retorna una cadena con los datos de la universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Guarda la informacion de la universidad (en universidad.xml) recibida en formato xml.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> instanciXml = new Xml<Universidad>();
                string file_name = AppDomain.CurrentDomain.BaseDirectory + "\\Universidad.xml";
                return instanciXml.Guardar(file_name, uni);
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Archivos Exception", ex);
            }
        }

        /// <summary>
        /// Lee los datos de guardados de la universidad (en universidad.xml) y los retorna.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            try
            {
                Xml<Universidad> instanciXml = new Xml<Universidad>();
                string file_name = AppDomain.CurrentDomain.BaseDirectory + "\\Universidad.xml";
                Universidad uni;
                instanciXml.Leer(file_name, out uni);
                Console.WriteLine(uni);
                return uni;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Archivos Exception", ex);
            }
        }




        /// <summary>
        /// Una Universidad será igual a un Alumno si este está en la lista alumnos de la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Una Universidad será igual a un Profesor, si este está en la lista de profesores de la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.Instructores.Contains(i);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Retornará: El primer Profesor (de la lista de profesores), que sea igual a la clase. 
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException("No hay profesor para la clase.");
        }
        /// <summary>
        /// Retornará: El primer Profesor (de la lista de profesores), que sea diferente a la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException("No hay profesor para la clase.");
        }

        /// <summary>
        /// Agregar una clase a una universidad, creara una nueva jornada con los instructores y alumnos que esten en esa clase.
        /// Caso contrario, se lanzaran las excepciones correspondientes.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor unProfesor = (g == clase);
            Jornada nuevaJornada = new Jornada(clase, unProfesor);
           
            foreach (Alumno item in g.alumnos)
            {
                if(item == clase)
                {
                    nuevaJornada.Alumnos.Add(item);
                }
            }
            g.Jornadas.Add(nuevaJornada);

            return g;
        }

        /// <summary>
        /// Al sumar un alumno a una universida, si este no se encuentra en la lista de alumnos, sera agregado a la misma.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno Repetido.");
            }

            return u;
        }
        /// <summary>
        /// Al sumar un instructor a una universida, si este no se encuentra en la lista de instructores, sera agregado a la misma.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            else
            {
                throw new SinProfesorException("No hay profesor para la clase.");
            }

            return u;
        }





    }//
}//
