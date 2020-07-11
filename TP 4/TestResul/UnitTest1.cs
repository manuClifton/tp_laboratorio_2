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
            // arrange 
            Correo c;

            // act 
            c = new Correo();

            // assert es manejado en el ExpectedException 
            Assert.IsNotNull(c.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PrevenirCargaDePaquetesIguales()
        {
            // arrange 
            Correo c = new Correo();
            Paquete p1 = new Paquete("Zaraza 1102", "123-456-1789");
            Paquete p2 = new Paquete("ChipaChipa 2992", "123-456-1789");

            // act 
            c += p1;
            c += p2;

            // assert es manejado en el ExpectedException 
        }

    }
}
