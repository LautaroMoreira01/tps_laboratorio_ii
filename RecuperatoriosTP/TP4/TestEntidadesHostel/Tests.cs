using EntidadesHostel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestEntidadesHostel
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(PersonaException))]
        public void AgregarPersonaAListaLlena_DeberiaRetornarUnaPersonaException()
        {
            //arrange
            Personas<Empleado> empleados = new Personas<Empleado>( 1 );

            Empleado empleado1 = new Empleado( "Lautaro", "Moreira" , 23145789 , new DateTime(2000, 06 , 06), ESexo.Masculino , EPuesto.Administrador , 20100 );
            Empleado empleado2 = new Empleado( "Juan" , "carlos" , 12134596 , new DateTime(1996, 01,15), ESexo.Masculino , EPuesto.Limpiador, 15000);
            if(empleados + empleado1){}

            //Act 

            if (empleados + empleado2){}

        }

        [TestMethod]
        public void JsonSerializar_DeberiaSerializarYDeserializarCorrectamenteUnString()
        {
            //arrange
            Json<string> json = new Json<string>();
            string expected = "Hola mundo";
            //act 
            json.Serializar( "TestJson.json" , "Hola mundo");

            string actual = json.Deserializar("TestJson.json");
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XmlSerializar_DeberiaSerializarYDeserializarCorrectamenteUnCliente()
        {
            //arrange

            Xml<Cliente>xml = new Xml<Cliente>();
           
            Cliente expected = new Cliente("Lautaro", "Moreira", 23145789, new DateTime(2000, 06, 06), ESexo.Masculino);
            
            xml.Serializar( "TestXml.xml" , expected );

            Cliente actual = xml.Deserializar("TestXml.xml");

            Assert.AreEqual(expected.MostrarInformacion() , actual.MostrarInformacion());
        }
    }
}
