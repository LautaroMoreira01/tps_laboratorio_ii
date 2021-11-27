using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesHostel
{
    public class Hostel
    {
        private int cantidadMaximaEmpleados = 4;
        private int cantidadMaximaClientes = 50;
        private Personas<Empleado> empleados;
        private Personas<Cliente> clientes;
        private Personas<Cliente> historialClientes;
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
            historialClientes = new Personas<Cliente>( );
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
            Empleado empleadoMasChico = empleados.PersonaMasChica();
            Empleado empleadoMasGrande = empleados.PersonaMasGrande();
            Empleado empleadoSalarioMasAlto = BuscarEmpleadoConElSalarioMasAlto();
            Empleado empleadoSalarioMasBajo = BuscarEmpleadoConElSalarioMasBajo();
            float promedioSalarial = CalcularPromedioSalarioParaEmpleados();

            sb.AppendLine();
            sb.AppendLine($"---------------------------{nombre} HOSTEL--------------------------");
            sb.AppendLine();

            sb.AppendLine($"------------Habitaciones------------");
            sb.AppendLine();

            sb.AppendLine($"Cantidad de habitaciones: {habitaciones.Count}");
            sb.AppendLine($"Cantidad total de camas: {CantidadDeCamas}");
            sb.AppendLine($"Promedio de camas por habitacion: {CalcularPromedioDeCamasPorHabitacion()}");
            sb.AppendLine();

            sb.AppendLine($"------------Clientes------------");
            sb.AppendLine();
            
            sb.AppendLine($"Capacidad maxima de clientes: {clientes.CapacidadMaxima}");
            sb.AppendLine($"Cantidad de clientes: {clientes.Count} de {cantidadMaximaClientes}");
            sb.AppendLine($"Cantidad de clientes hombres: {clientes.CantidadDeHombres} de {clientes.Count} ({CalcularPorcentaje(clientes.Count, clientes.CantidadDeHombres):0.00}%)");
            sb.AppendLine($"Cantidad de clientes mujeres: {clientes.CantidadDeMujeres} de {cantidadMaximaClientes}  ({CalcularPorcentaje(clientes.Count, clientes.CantidadDeMujeres):0.00}%)");
            sb.AppendLine($"El/La cliente mas grande es {clienteMasGrande.Nombre} con {clienteMasGrande.Edad} años.");
            sb.AppendLine($"El/La cliente mas chico es {clienteMasChico.Nombre} con {clienteMasChico.Edad} años.");
            sb.AppendLine($"Promedio edad de todos los clientes hombres: {clientes.CalcularPromedioEdadesHombres()}");
            sb.AppendLine($"Promedio edad de todos las clientas mujeres: {clientes.CalcularPromedioEdadesMujeres()}");
            sb.AppendLine($"Promedio edad de todos los clientes: {clientes.CalcularPromedioEdadesTotal()}");
            sb.AppendLine();

            sb.AppendLine();
            sb.AppendLine($"------------Empleados------------");
            sb.AppendLine();

            sb.AppendLine($"Capacidad maxima de empleados: {empleados.CapacidadMaxima}");
            sb.AppendLine($"Cantidad de empleados: {empleados.Count} de {cantidadMaximaEmpleados}");
            sb.AppendLine($"Cantidad de empleados hombres: {empleados.CantidadDeHombres} de {empleados.Count} ({CalcularPorcentaje(empleados.Count, empleados.CantidadDeHombres):0.00}%)");
            sb.AppendLine($"Cantidad de empleados mujeres: {empleados.CantidadDeMujeres} de {empleados.Count} ({CalcularPorcentaje(empleados.Count, empleados.CantidadDeMujeres):0.00}");
            sb.AppendLine($"El/La empleado mas grande es {empleadoMasGrande.Nombre} con {empleadoMasGrande.Edad} años.");
            sb.AppendLine($"El/La empleado mas chico es {empleadoMasChico.Nombre} con {empleadoMasChico.Edad} años.");
            sb.AppendLine($"Promedio edad de todos los empleados hombres: {empleados.CalcularPromedioEdadesHombres()}");
            sb.AppendLine($"Promedio edad de todos las empleadas mujeres: {empleados.CalcularPromedioEdadesMujeres()}");
            sb.AppendLine($"Promedio edad de todos los empleados: {empleados.CalcularPromedioEdadesTotal()}");
            sb.AppendLine($"Promedio salarial de los empleados: {promedioSalarial:0.00}");
            sb.AppendLine($"Empleados que superan el promedio salarial: {CantidadDeEmpleadosQueSuperanElPromedioSalarial()}");
            sb.AppendLine($"Empleado con el salario mas alto es: {empleadoSalarioMasAlto.Nombre} con {empleadoSalarioMasAlto.Salario}");
            sb.AppendLine($"Empleado con el salario mas bajo es: {empleadoSalarioMasBajo.Nombre} con {empleadoSalarioMasBajo.Salario}");


            if(historialClientes.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine($"------------Historial de clientes------------");
                sb.AppendLine();

                sb.AppendLine($"Cantidad de clientes que pasaron por el hostel: {historialClientes.Count}");
                sb.AppendLine($"Cantidad de clientes hombres que pasaron por el hostel: {historialClientes.CantidadDeHombres} de {historialClientes.Count} ({CalcularPorcentaje(historialClientes.Count, historialClientes.CantidadDeHombres):0.00}%)");
                sb.AppendLine($"Cantidad de clientes mujeres que pasaron por el hostel: {historialClientes.CantidadDeMujeres} de {historialClientes.Count}  ({CalcularPorcentaje(historialClientes.Count, historialClientes.CantidadDeMujeres):0.00}%)");
                sb.AppendLine($"El/La cliente mas grande que paso por el hostel es {historialClientes.PersonaMasGrande()} con {historialClientes.PersonaMasGrande().Edad} años.");
                sb.AppendLine($"El/La cliente mas chico que paso por el hostel es {historialClientes.PersonaMasChica()} con {historialClientes.PersonaMasChica().Edad} años.");
                sb.AppendLine($"Promedio edad de todos los clientes hombres: {historialClientes.CalcularPromedioEdadesHombres()}");
                sb.AppendLine($"Promedio edad de todos las clientas mujeres: {historialClientes.CalcularPromedioEdadesMujeres()}");
                sb.AppendLine($"Promedio edad de todos los clientes: {historialClientes.CalcularPromedioEdadesTotal()}");
                sb.AppendLine($"Promedio Puntuacion del hostel: {PromedioPuntuacionDelHostel():0.00}");
                sb.AppendLine($"Cantidad de personas que volverian a venir al hostel: {CantidadDeClientesQueVolverianAlHostel()} ({CalcularPorcentaje(historialClientes.Count,CantidadDeClientesQueVolverianAlHostel()  ):0.00}%)");
           
            }

            return sb.ToString();
        }

        /// <summary>
        /// Busca al empleado con el salario mas alto
        /// </summary>
        /// <returns>El empleado con el salario mas alto</returns>
        private Empleado BuscarEmpleadoConElSalarioMasAlto()
        {
            Empleado empleadoConSalarioMasAlto = null ;

            foreach (Empleado empleado in empleados.Lista)
            {
                if(empleadoConSalarioMasAlto is null || empleado.Salario > empleadoConSalarioMasAlto.Salario)
                {
                    empleadoConSalarioMasAlto = empleado;
                }
            }

            return empleadoConSalarioMasAlto;

        }
        
        /// <summary>
        /// Busca al empleado con el salario mas bajo
        /// </summary>
        /// <returns>El empleado con el salario mas bajo</returns>
        private Empleado BuscarEmpleadoConElSalarioMasBajo()
        {
            Empleado empleadoConSalarioMasBajo = null ;

            foreach (Empleado empleado in empleados.Lista)
            {
                if(empleadoConSalarioMasBajo is null || empleado.Salario < empleadoConSalarioMasBajo.Salario)
                {
                    empleadoConSalarioMasBajo = empleado;
                }
            }

            return empleadoConSalarioMasBajo;

        }

        /// <summary>
        /// Busca la cantidad de empleados que supera el promedio salarial.
        /// </summary>
        /// <returns>Int con la cantidad de empleados que superan el promedio salarial</returns>
        private int CantidadDeEmpleadosQueSuperanElPromedioSalarial()
        {
            int cant = 0;
            float promedioSalarial = CalcularPromedioSalarioParaEmpleados();

            foreach (Empleado empleado in empleados.Lista)
            {
                if(empleado.Salario > promedioSalarial)
                {
                    cant++;
                }
            }
            return cant;
        }


        /// <summary>
        /// Metodo para calcular el porcentaje de cualquier numero
        /// </summary>
        /// <param name="cantidadTotal">cantidad total de donde se quiere sacar el porcentaje </param>
        /// <param name="cantidad">numero de porcentaje a sacar</param>
        /// <returns></returns>
        private float CalcularPorcentaje(float cantidadTotal, float cantidad)
        {

            return (cantidad * 100)/cantidadTotal;

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
        /// Metodo que retorna la cantidad de personas que volverian al hostel
        /// </summary>
        /// <returns></returns>
        private int CantidadDeClientesQueVolverianAlHostel()
        {
            int cant = 0;
            foreach (Cliente cliente in historialClientes.Lista)
            {
                if (cliente.VolveriaAVenir)
                {
                    cant++;
                }
            }

            return cant ;
        }
        
        /// <summary>
        /// Calcula el promedio de los clientes que volverian al hostel
        /// </summary>
        /// <returns>float con el promedio</returns>
        private float PromedioDePersonasQueVolverianAlHostel()
        {
            return (float)CantidadDeClientesQueVolverianAlHostel() / historialClientes.Count;
        }

        /// <summary>
        /// Calcula el promedio de la puntuacion del servicio del hostel
        /// </summary>
        /// <returns>promedio de la puntuacion del hostel</returns>
        private float PromedioPuntuacionDelHostel()
        {
            int suma = 0;
            foreach (Cliente cliente in historialClientes.Lista)
            {
               suma += cliente.PuntuacionDelServicio;
            }

            return (float)suma / historialClientes.Count;

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
        /// propiedad que retorna o ingresa el historial de clientes
        /// </summary>
        public Personas<Cliente> HistorialClientes
        {
            get { return historialClientes; }
            set { historialClientes = value; }
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
