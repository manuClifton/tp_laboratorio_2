using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;

namespace Test_Unitarios
{
    [TestClass]
    public class TestException
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ExcepcionPersonaConDniInvalido()
        {
            Alumno a1 = new Alumno(10, "Manuel", "Clifton", "abcd123", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ExcepcionNacionalidadInvalida()
        {
            Alumno a1 = new Alumno(10, "Manuel", "Clifton", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void ExcepcionSinProfesor()
        {
            Universidad universidad = new Universidad();
            universidad += Universidad.EClases.Laboratorio;
        }




    }//
}//
