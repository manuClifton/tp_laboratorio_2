using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace Test_Unitarios
{
    [TestClass]
    public class TestInstanciaColeccion
    {
        [TestMethod]
        public void TestColeccionDeAlumnos()
        {
            Universidad uni = new Universidad();
   
            Assert.IsNotNull(uni.Alumnos);
        }
        [TestMethod]
        public void TestColeccionDeProfesores()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Instructores);
        }
    }
}
