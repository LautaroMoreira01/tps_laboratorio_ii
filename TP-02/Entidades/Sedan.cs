using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        /// <summary>
        /// Enumerado de Sedan que contiene los tipos.
        /// </summary>
        public enum ETipo { CuatroPuertas, CincoPuertas }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }

        /// <summary>
        /// Constructor de Sedam.
        /// </summary>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Propiedad de sedan que devuelve el tamanio que es mediano.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        /// <summary>
        /// Sobrescritura del metodo Mostrar que devuelve los datos del objeto.
        /// </summary>
        /// <returns>Devuelve los datos del sedan en tipo string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.Append((string)this);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
