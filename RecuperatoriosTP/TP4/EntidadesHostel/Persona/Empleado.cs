using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EntidadesHostel
{

    public class Empleado : Persona
    {
        private float salario;
        private EPuesto puesto;

        /// <summary>
        /// Constructor sin parametros de la clase empleados
        /// </summary>
        public Empleado()
        {

        }

        /// <summary>
        /// constructor de la clase Empleado con parametros
        /// </summary>
        /// <param name="nombre">Nombre el empleado</param>
        /// <param name="apellido">Apellido el empleado</param>
        /// <param name="dni">Dni el empleado</param>
        /// <param name="fechaDeNacimiento">Fecha de nacimiento del empleado</param>
        /// <param name="sexo">Sexo del empleado</param>
        /// <param name="puesto">Puesto del empleado</param>
        /// <param name="salario">Salario del empleado</param>
        public Empleado(string nombre, string apellido, long dni, DateTime fechaDeNacimiento, ESexo sexo ,EPuesto puesto , float salario)
            : base(nombre, apellido, dni, fechaDeNacimiento, sexo)
        {
            this.salario = salario;
            this.puesto = puesto;
        }

        /// <summary>
        /// Muestra la informacion del empleado
        /// </summary>
        /// <returns></returns>
        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(base.MostrarInformacion());
            sb.AppendLine($"Puesto: {puesto}");
            sb.AppendLine($"Salario: {salario}");

            return sb.ToString();
        }

        /// <summary>
        /// Propiead que devuelve o ingresa el salario del empleado
        /// </summary>
        public float Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        /// <summary>
        /// Propiedad que devuelve o ingresa el puesto del empleado
        /// </summary>
        public EPuesto Puesto 
        {
            get { return puesto ; }
            set { puesto = value; }
        }
    }
}
