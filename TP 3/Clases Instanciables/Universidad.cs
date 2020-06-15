using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornadas;

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }
        public Jornada this[int i]
        {
            get { return this.jornadas[i]; }
            set { this.jornadas[i] = value; }
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

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
       
       

       

        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.Instructores.Contains(i);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
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
