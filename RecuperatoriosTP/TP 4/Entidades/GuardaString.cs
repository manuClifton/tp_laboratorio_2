using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {

        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                using (StreamWriter sw = new StreamWriter(Path.Combine(desktop, archivo), true))
                {
                    sw.WriteLine(texto);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error al guardar el texto de las entregas.", e);
            }
        }

    }//
}//

