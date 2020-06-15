using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) :this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

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

        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.alumnos.Contains(a);
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
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
