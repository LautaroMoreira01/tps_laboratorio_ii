using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesHostel
{
    public class PersonaException : Exception
    {
        /// <summary>
        /// Constructor de PersonaException
        /// </summary>
        /// <param name="message">mensaje a retornar si ocurre la excepcion</param>
        /// <param name="innerException">inner exception</param>
        public PersonaException(string message , Exception innerException) : base(message , innerException) 
        {

        }

        /// <summary>
        /// Constructor de personaException
        /// </summary>
        /// <param name="message">Mensaje a retornar si ocurre la excepcion</param>
        public PersonaException(string message ) : this(message ,null) 
        {

        }

    }
}
