using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{

    public class Correo : IMostrar<Paquete>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;


        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }


        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item != null && item.IsAlive)
                {
                    item.Abort();
                }
            }
        }


        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string rta = "";
            Correo c = (Correo)elemento;
            foreach (Paquete item in c.Paquetes)
            {
                rta += String.Format("{0} para {1} ({2})\n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
            }
            return rta;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException($"El tracking id {p.TrackingID} ya figura en la lista de envios");
                }
            }
            c.paquetes.Add(p);
            Thread t = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(t);
            t.Start();

            return c;
        }


    }//
}//
