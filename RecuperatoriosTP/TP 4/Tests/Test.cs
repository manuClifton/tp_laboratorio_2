using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void PaquetesDeCorreoInstanciada()
        {

            Correo c = new Correo();

            Assert.IsNotNull(c.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void CargaDePaquetesIguales()
        {

            Correo c = new Correo();
            Paquete p1 = new Paquete("Vergara 1102", "123-456-1789");
            Paquete p2 = new Paquete("Uspallata 2992", "123-456-1789");

            c += p1;
            c += p2;

        }

    }
}
