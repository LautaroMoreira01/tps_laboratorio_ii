using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EntidadesHostel
{
    [Serializable]
    [XmlInclude(typeof(Empleado))]
    [XmlInclude(typeof(Cliente))]

    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private long dni;
        private int edad;
        private DateTime fechaNacimiento;
        private ESexo sexo;

        /// <summary>
        /// Construcitor de la clase persona
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="edad">Edad de la persona</param>
        /// <param name="sexo">Sexo de la persona</param>
        public Persona(string nombre, string apellido, long dni, DateTime fechaNacimiento, ESexo sexo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
            this.sexo = sexo;
        }

        /// <summary>
        ///  Metodo que te retorna la informacion de la persona
        /// </summary>
        /// <returns>string con los datos de la persona</returns>
        public virtual string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {nombre}"); 
            sb.AppendLine($"Apellido: {apellido}"); 
            sb.AppendLine($"Fecha de nacimiento: {fechaNacimiento:DD:MM:yyy}"); 
            sb.AppendLine($"Edad: {Edad}"); 
            sb.AppendLine($"DNI: {dni}"); 
            sb.AppendLine($"Sexo: {sexo}"); 

            return sb.ToString();  
        }

        /// <summary>
        /// Sobrescritura del metodo toString() que devuelve la informacion de la persona
        /// </summary>
        /// <returns>string con la informacion de la persona</returns>
        public override string ToString()
        {
            return $"{Nombre}, {Apellido}, {Dni} ";
        }


        /// <summary>
        /// Sobrecarga del operador == que compara dos personas por sus dni
        /// </summary>
        /// <param name="p1">Persona uno a comparar</param>
        /// <param name="p2">Persona dos a comparar</param>
        /// <returns>True si son la misma persona, false si un perona es null o sus dni son distintos</returns>
        public static bool operator ==(Persona p1 , Persona p2)
        {
            if (p1 is null || p2 is null)
            {
                return false;
            }
            
            return p1.dni == p2.dni;
        }

        /// <summary>
        /// Sobrecarga del operador != que compara dos personas por sus dni
        /// </summary>
        /// <param name="p1">Persona uno a comparar</param>
        /// <param name="p2">Persona dos a comparar</param>
        /// <returns>False si son la misma persona, true si un perona es null o sus dni son distintos</returns>
        public static bool operator !=(Persona p1 , Persona p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Propiedad publica que retorna o ingresa el nombre de la persona
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Propiedad publica que retorna o ingresa el apellido de la persona
        /// </summary>
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        /// <summary>
        /// Propiedad publica que retorna o ingresa la edad de la persona
        /// </summary>
        public int Edad
        {
            get { return DateTimeEx.CalcularEdadActual(fechaNacimiento); }

        }

        /// <summary>
        /// Propiedad publica que retorna o ingresa el dni de la persona
        /// </summary>
        public long Dni
        {
            get { return dni; }

            set
            {
                if (value.ToString().Length >= 7)
                {
                    dni = value;
                }
                else
                {
                    dni = 0;
                }
            }
        }

        /// <summary>
        /// Propiedad publica que retorna o ingresa el sexo de la persona
        /// </summary>
        public ESexo Sexo
        {
            get { return sexo; }

            set
            {
                sexo = value;
            }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }

            set
            {
                fechaNacimiento = value;
            }
        }
    }
}
