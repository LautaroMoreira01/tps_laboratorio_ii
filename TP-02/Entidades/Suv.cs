using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        /// <summary>
        /// Constructor de la clase SUV
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(Vehiculo.EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// Propiedad de la clase SUV que devielve el tamaño del auto por defecto son GRANDE.
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Grande;
            }
        }
        /// <summary>
        /// Sobrescritura del metodo Mostrar que devuelve los datos.
        /// </summary>
        /// <returns>Retorna los datos en tipo string.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine((string)this);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
