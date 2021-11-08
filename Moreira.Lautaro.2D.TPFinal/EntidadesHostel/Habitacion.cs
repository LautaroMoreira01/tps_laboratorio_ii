using System;
using System.Collections.Generic;
using System.Text;


namespace EntidadesHostel
{
    public class Habitacion
    {
        private int cantidadDeCamas;
        private string numeroDeHabitacion;
        private Personas<Cliente> clientesEnLaHabitacion;

        /// <summary>
        /// Constructor publico de la  clase habitacion
        /// </summary>
        public Habitacion()
        {

        }

        /// <summary>
        /// Constructor con parametros que recibe la cantidad de camas y el numero de la habitacion
        /// </summary>
        /// <param name="cantidadCamas">Cantidad de camas en la habitacoin</param>
        /// <param name="numeroDeHabitacion">Numero de la habitacion</param>
        public Habitacion(int cantidadCamas, string numeroDeHabitacion)
        {
            this.cantidadDeCamas = cantidadCamas;
            this.numeroDeHabitacion = numeroDeHabitacion;
            clientesEnLaHabitacion = new Personas<Cliente>(cantidadCamas);
        }

        /// <summary>
        /// Muestra la informacion de la habitacion
        /// </summary>
        /// <returns>string con la informacoin de la habitacion</returns>
        public string MostrarInformacionDeHabitacion()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Numero de habitacion: {numeroDeHabitacion}");
            sb.AppendLine($"Cantidad de camas: {CantidadDeCamas.ToString()}");
            sb.AppendLine($"Cantidad de cama ocupadas: {clientesEnLaHabitacion.Count}");

            if(clientesEnLaHabitacion.Count > 0)
            {
                sb.AppendLine("CLIENTES");

                sb.AppendLine(clientesEnLaHabitacion.Mostrar());
            }
            return sb.ToString();

        }

        /// <summary>
        /// Propiedad que retorna o ingresa el numero de la habitacion
        /// </summary>
        public string NumeroDeHabitacion
        {
            get { return numeroDeHabitacion; }
            set { numeroDeHabitacion = value;}
        }

        /// <summary>
        /// Propiedad que retorna o ingresa la cantidad de camas en la habitacion
        /// </summary>
        public int CantidadDeCamas
        {
            get { return cantidadDeCamas; }    
            set { cantidadDeCamas = value; }  
        }

        /// <summary>
        /// Propiedad que ingresa o retorna los clientes en la habitacion
        /// </summary>
        public Personas<Cliente> ClientesEnLaHabitacion
        {
            get { return clientesEnLaHabitacion;}
            set { clientesEnLaHabitacion = value; }
        }

        /// <summary>
        /// sobrecarga del operador == que compara dos habitaciones por el numero de habitacion
        /// </summary>
        /// <param name="habitacion">habitacion uno a comparar</param>
        /// <param name="habitacion2">habitacion dos a comparar</param>
        /// <returns>true si las habitaciones son la mismas, false si son distintas</returns>
        public static bool operator ==(Habitacion habitacion, Habitacion habitacion2)
        {
            return habitacion.NumeroDeHabitacion == habitacion2.NumeroDeHabitacion;
        }

        /// <summary>
        /// sobrecarga del operador != que compara dos habitaciones por el numero de habitacion
        /// </summary>
        /// <param name="habitacion">habitacion uno a comparar</param>
        /// <param name="habitacion2">habitacion dos a comparar</param>
        /// <returns>false si las habitaciones son la mismas, true si son distintas</returns>
        public static bool operator !=(Habitacion habitacion, Habitacion habitacion2)
        {
            return !(habitacion == habitacion2);
        }

        /// <summary>
        /// sobrecarga del operador + que agrega un cliente a una habitacion
        /// </summary>
        /// <param name="habitacion">habitacion donde se quiere agregar el cliente</param>
        /// <param name="cliente">cliente a agregar</param>
        /// <returns>true si se pudo agregar false si no se pudo</returns>
        public static bool operator +(Habitacion habitacion , Cliente cliente)
        {
            bool rta = false;

            if (habitacion.CantidadDeCamas > habitacion.clientesEnLaHabitacion.Count && habitacion.clientesEnLaHabitacion != cliente)
            {
                rta = habitacion.clientesEnLaHabitacion + cliente;
                
            }

            return rta;
        }

        /// <summary>
        /// sobrecarga del operador - que elimina un cliente de una habitacion
        /// </summary>
        /// <param name="habitacion">habitacion donde se quiere eliminar el cliente</param>
        /// <param name="cliente">cliente a eliminar</param>
        /// <returns>true si se pudo eliminar false si no se pudo</returns>
        public static bool operator -(Habitacion habitacion, Cliente cliente)
        {
            bool rta = false;

            if (habitacion.clientesEnLaHabitacion == cliente )
            {
                rta = habitacion.clientesEnLaHabitacion - cliente;
            }

            return rta;
        }

        /// <summary>
        /// Metodo que calcula el promedio de edad de los clientes en la habitacion
        /// </summary>
        /// <returns>float con el promedio de edades en la habitacion</returns>
        public float PromedioEdadesEnHabitaciones()
        {
            if(clientesEnLaHabitacion.Count > 0)
            {
                return clientesEnLaHabitacion.CalcularPromedioEdadesTotal();
            }
            else
            {
                return 0;
            }
        }
    }
}
