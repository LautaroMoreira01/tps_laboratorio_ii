using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesHostel
{
    public static class DateTimeEx
    {
        /// <summary>
        /// Metodo de extension de la clase DateTime que calcula la edad a partir de la fecha pasada por parametro
        /// </summary>
        /// <param name="fechaNacimiento">Fecha de nacimiento</param>
        /// <returns>int edad</returns>
        public static int CalcularEdadActual(this DateTime fechaNacimiento)
        {
            return DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;
        }
    }

}
