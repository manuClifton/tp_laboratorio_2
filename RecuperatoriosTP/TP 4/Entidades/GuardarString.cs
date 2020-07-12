using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// recive un nombre de archivo y guarda el contenido del string en el escritorio con dicho nombre. 
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                    string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    using (StreamWriter sw = new StreamWriter(Path.Combine(escritorio, archivo), true))
                    {
                        sw.WriteLine(texto);
                    }
                    return true;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error, NO se guardo el texto de las entregas !!", e);
            }
        }

    }//
}//
