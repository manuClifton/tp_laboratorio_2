using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestResul
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaPaquetesDeCorreoInstanciada()
        {

            Correo c = new Correo();

            Assert.IsNotNull(c.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PrevenirCargaDePaquetesIguales()
        {

            Correo c = new Correo();
            Paquete p1 = new Paquete("Zaraza 1102", "123-456-1789");
            Paquete p2 = new Paquete("ChipaChipa 2992", "123-456-1789");

            c += p1;
            c += p2;

        }

    }
}
