using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesHostel
{
    public class CampoInvalidoException : Exception
    {
        /// <summary>
        /// Constructor de CampoInvalidoException que recibe como argumentos el mensaje que devolvera la excepcion y la inner excepcion.
        /// </summary>
        /// <param name="message">Mensaje de error de la excepcion</param>
        /// <param name="inner">innner excepcion</param>
        public CampoInvalidoException(string message , Exception inner) : base(message, inner)
        {

        }
        /// <summary>
        /// Constructor de CampoInvalidoException que recive el mensaje de error
        /// </summary>
        /// <param name="message">Mensaje de error que devuelve la excepcion</param>
        public CampoInvalidoException(string message) : this(message, null)
        {

        }
    }
}
