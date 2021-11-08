using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
namespace EntidadesHostel
{


    public class Cliente : Persona
    {
        private int puntuacionDelServicio;
        private bool volverianAVenir;


        /// <summary>
        /// Constructor por defecto de la clase cliente
        /// </summary>
        public Cliente()
        {

        }

        /// <summary>
        /// Constructor de la clase cliente
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="apellido">Apellido del cliente</param>
        /// <param name="dni">Dni del cliente</param>
        /// <param name="edad">Edad del cliente</param>
        /// <param name="sexo">Sexo del cliente</param>
        public Cliente(string nombre, string apellido, long dni, int edad , ESexo sexo) : base(nombre, apellido, dni, edad , sexo)
        {
        }
    }
}
