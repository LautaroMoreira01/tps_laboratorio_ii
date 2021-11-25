using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesHostel;
using System;

namespace TestsTp4
{
    [TestClass]
    public class TestMetodoDeExtension
    {
        [TestMethod]
        public void ExtensionDeDateTimeCalcularEdad_DeberiaRetornarLaEdadQueTendriaLaPersonaActualmente()
        {
            //Arrange
            int edadEsperada = 21;
            int edadDevuelta; 
            DateTime fechaNacmiento = new DateTime(2000, 03, 06);

            //Act
            edadDevuelta = DateTimeEx.CalcularEdadActual(fechaNacmiento);
            //assert

            Assert.AreEqual(edadEsperada,edadDevuelta);
        }
        
        [TestMethod]
        public void CalcularPromedioEdadesDeberiaRetornar_ElPromedioDeLasEdadesDeLaLista()
        {
            //Arrange
            Personas<Cliente> clientes = new Personas<Cliente>();
            bool agregar = clientes + new Cliente("Lautaro", "Moreira", 1234567, new DateTime(2001, 06, 06), ESexo.Masculino);
            agregar = clientes + new Cliente("Juan", "Perez", 13214875, new DateTime(1999, 04, 12), ESexo.Masculino);
            agregar = clientes + new Cliente("Maria", "Gomez", 65489741, new DateTime(1979, 02, 21), ESexo.Femenino);
            float expected = 28;
            float actual ;


            //Act

            actual = clientes.CalcularPromedioEdadesTotal();

            //assert

            Assert.AreEqual(actual,expected);
        }
    }
}
