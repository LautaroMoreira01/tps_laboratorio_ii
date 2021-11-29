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
            int edad = DateTime.Today.Year - fechaNacimiento.Year;

            if (DateTime.Today.Month < fechaNacimiento.Month)
            {
                --edad;
            }
            else if (DateTime.Today.Month == fechaNacimiento.Month && DateTime.Today.Day < fechaNacimiento.Day)
            {
                --edad;
            }

            return edad;
        }
    }

}
