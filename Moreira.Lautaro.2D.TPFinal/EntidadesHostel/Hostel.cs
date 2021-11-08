using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesHostel
{
    public class Hostel
    {
        private int cantidadMaximaEmpleados = 4 ;
        private int cantidadMaximaClientes = 50;
        private Personas<Empleado> empleados;
        private Personas<Cliente> clientes;
        private List<Habitacion> habitaciones;
        private string nombre;

        /// <summary>
        /// constructor de la clase hostel que inicializa las listas
        /// </summary>
        private Hostel()
        {
            habitaciones = new List<Habitacion>();
            empleados = new Personas<Empleado>(cantidadMaximaEmpleados);                    
            clientes = new Personas<Cliente>(cantidadMaximaClientes);
        }

        /// <summary>
        /// Constructor que inicializa el nombre del hostel
        /// </summary>
        /// <param name="nombre">nombre del hostel</param>
        public Hostel(string nombre) :this()
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Metodo que retorna toda la informacion del hostel
        /// </summary>
        /// <returns>string con la informacion del hostel</returns>
        public string MostrarInformacionHostel()
        {
            StringBuilder sb = new StringBuilder();
            Cliente clienteMasChico = clientes.PersonaMasChica();
            Cliente clienteMasGrande = clientes.PersonaMasGrande();

            sb.AppendLine($"---------------------------{nombre} HOSTEL--------------------------");
            sb.AppendLine($"Cantidad de habitaciones: {habitaciones.Count}");
            
            
            sb.AppendLine($"------------Clientes------------");
            sb.AppendLine($"Capacidad maxima de clientes: {clientes.CapacidadMaxima}");
            sb.AppendLine($"Cantidad de clientes: {clientes.Count} de {cantidadMaximaClientes}");
            sb.AppendLine($"Cantidad de clientes hombres: {clientes.Count} de {cantidadMaximaClientes}");
            sb.AppendLine($"Cantidad de clientes mujeres: {clientes.Count} de {cantidadMaximaClientes}");
            sb.AppendLine($"El/La cliente mas grande es {clienteMasGrande.Nombre} con {clienteMasGrande.Edad} años.");
            sb.AppendLine($"El/La cliente mas chico es {clienteMasChico.Nombre} con {clienteMasChico.Edad} años.");
            sb.AppendLine($"Promedio edad de todos los clientes hombres: {clientes.CalcularPromedioEdadesHombres()}");
            sb.AppendLine($"Promedio edad de todos las clientas mujeres: {clientes.CalcularPromedioEdadesMujeres()}");
            sb.AppendLine($"Promedio edad de todos los clientes: {clientes.CalcularPromedioEdadesTotal()}");

            sb.AppendLine($"------------Empleados------------");
            sb.AppendLine($"Capacidad maxima de empleados: {empleados.CapacidadMaxima}");
            sb.AppendLine($"Cantidad de empleados: {empleados.Count} de {cantidadMaximaEmpleados}");
            sb.AppendLine($"Cantidad de empleados hombres: {empleados.CantidadDeHombres} de {cantidadMaximaEmpleados}");
            sb.AppendLine($"Cantidad de empleados mujeres: {empleados.CantidadDeHombres} de {cantidadMaximaEmpleados}");
            sb.AppendLine($"El/La cliente mas grande es {clienteMasGrande.Nombre} con {clienteMasGrande.Edad} años.");
            sb.AppendLine($"El/La cliente mas chico es {clienteMasChico.Nombre} con {clienteMasChico.Edad} años.");
            sb.AppendLine($"Promedio edad de todos los empleados hombres: {empleados.CalcularPromedioEdadesHombres()}");
            sb.AppendLine($"Promedio edad de todos las empleadas mujeres: {empleados.CalcularPromedioEdadesMujeres()}");
            sb.AppendLine($"Promedio edad de todos los empleados: {empleados.CalcularPromedioEdadesTotal()}");

            return sb.ToString();
        }

        /// <summary>
        /// metodo que calcula el promedio de camas por habiatacion
        /// </summary>
        /// <returns>float con el promedio de camas por habitacion</returns>
        public float CalcularPromedioDeCamasPorHabitacion()
        {
            int totalCamas = 0;

            foreach (Habitacion habitacion in habitaciones)
            {
                totalCamas += habitacion.CantidadDeCamas;
            }

            float promedio = (float)totalCamas / habitaciones.Count;

            return promedio;
        }

        /// <summary>
        /// metodo que calcula el promedio de salario de los empleado
        /// </summary>
        /// <returns>gloat con el promedio de salario de todos los empleados</returns>
        public float CalcularPromedioSalarioParaEmpleados()
        {
            float sumaSalarios = 0;
            
            foreach (Empleado item in empleados.Lista)
            {
                sumaSalarios += item.Salario;
            }

            return  (float)sumaSalarios / empleados.Count;

        }

        /// <summary>
        /// propiedad que retorna la cantidad  total de camas en el hostel
        /// </summary>
        public int CantidadDeCamas
        {
            get
            {
                int camas = 0;
                foreach(Habitacion habitacion in habitaciones)
                {
                    camas += habitacion.CantidadDeCamas;
                }
                return camas;
            }
        }

        /// <summary>
        /// Metodo que calcula la cantidad de camas disponibles en el hostel
        /// </summary>
        /// <returns>int cantidad de camas disponibles</returns>
        public int CantidadDeCamasDisponibles()
        {
            return CantidadDeCamas - clientes.Count;
        }

        /// <summary>
        /// Propiedad que retorna o ingresa el nombre del hostel
        /// </summary>
        public string Nombre 
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// propiedad que retorna o ingresa los empleados
        /// </summary>
        public Personas<Empleado> Empleados 
        {
            get { return empleados; }
            set { empleados = value; }
        }

        /// <summary>
        /// propiedad que retorna o ingresa los clientes
        /// </summary>
        public Personas<Cliente> Clientes
        {
            get { return clientes; }
            set { clientes = value; }
        }

        /// <summary>
        /// propiedad que retorna o ingresa la lista de habitaciones
        /// </summary>
        public List<Habitacion> Habitaciones
        {
            get { return habitaciones; }
            set { habitaciones = value; }
        }

        /// <summary>
        /// Propiedad que retorna o ingresa la capacidad maxima de empleados
        /// </summary>
        public int CapacidadMaximaEmpleados 
        {
            get { return cantidadMaximaEmpleados; }
            set { cantidadMaximaEmpleados = value; }
        }
        
        /// <summary>
        /// propiedad que retorna o ingresa la capacidad maxima de clientes
        /// </summary>
        public int CapacidadMaximaClientes 
        {
            get { return cantidadMaximaClientes; }
            set { cantidadMaximaClientes = value; }
        }

    }
}
