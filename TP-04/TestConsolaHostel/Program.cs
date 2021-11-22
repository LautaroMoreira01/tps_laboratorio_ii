using System;
using System.Collections.Generic;
using System.IO;
using EntidadesHostel;

namespace TestConsolaHostel
{
    class Program
    {
        static void Main(string[] args)
        {

            Hostel hostel = new Hostel("La roca");

            Personas<Empleado> empleados = new Personas<Empleado>(hostel.CapacidadMaximaEmpleados);
            Personas<Cliente> clientes = new Personas<Cliente>(hostel.CapacidadMaximaClientes);
            List<Habitacion> habitaciones = new List<Habitacion>();

            Habitacion h1 = new Habitacion(4, "A01");
            Habitacion h2 = new Habitacion(3, "A02");
            Habitacion h3 = new Habitacion(2, "A03");
            Habitacion h4 = new Habitacion(1, "A04");
            Habitacion h5 = new Habitacion(4, "B01");
            Habitacion h6 = new Habitacion(3, "B02");
            Habitacion h7 = new Habitacion(2, "B03");
            Habitacion h8 = new Habitacion(1, "B04");
            Habitacion h9 = new Habitacion(4, "C01");
            Habitacion h10 = new Habitacion(3, "C02");
            Habitacion h11 = new Habitacion(2, "C03");
            Habitacion h12 = new Habitacion(1, "C04");
            Habitacion h13 = new Habitacion(4, "D01");
            Habitacion h14 = new Habitacion(3, "D02");
            Habitacion h15 = new Habitacion(2, "D03");
            Habitacion h16 = new Habitacion(1, "D04");

            habitaciones.Add(h1);
            habitaciones.Add(h2);
            habitaciones.Add(h3);
            habitaciones.Add(h4);
            habitaciones.Add(h5);
            habitaciones.Add(h6);
            habitaciones.Add(h7);
            habitaciones.Add(h8);
            habitaciones.Add(h9);
            habitaciones.Add(h10);
            habitaciones.Add(h11);
            habitaciones.Add(h12);
            habitaciones.Add(h13);
            habitaciones.Add(h14);
            habitaciones.Add(h15);
            habitaciones.Add(h16);


            Empleado e1 = new Empleado("Daniel", "Carpio", 40215478, new DateTime(1975 , 05 , 20) , ESexo.Masculino, EPuesto.Duenio, 300000);
            Empleado e2 = new Empleado("Dario", "Mendez", 41657852, new DateTime(1987, 04, 15), ESexo.Masculino, EPuesto.Limpiador, 60000);
            Empleado e3 = new Empleado("Juan", "Carpio", 43054784, new DateTime(1996, 02, 12), ESexo.Masculino, EPuesto.Gerente, 100000);
            Empleado e4 = new Empleado("Martina", "Carpio", 43657852, new DateTime(1998, 05, 25), ESexo.Femenino, EPuesto.Administrador, 100000);
            Empleado e5 = new Empleado("Damian", "Gutierrez", 21487952, new DateTime(2001, 05, 24), ESexo.Masculino, EPuesto.Administrador, 70000);
            Empleado e6 = new Empleado("Lucas", "Pastor", 42085485, new DateTime(1988, 04, 29), ESexo.Masculino, EPuesto.Limpiador, 60000);

            string pathlogs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs/");

            try
            {


                try
                {
                    if (empleados + e1)
                    {
                        Console.WriteLine($"e1 agregado");
                    }
                }
                catch (PersonaException ex)
                {

                    Log.Guardar(ex);
                    Console.WriteLine(ex.Message);
                }


                Console.WriteLine("------------------------------");


                try
                {
                    if (empleados + e2)
                    {
                        Console.WriteLine($"e2 agregado");
                    }
                }
                catch (PersonaException ex)
                {

                    Log.Guardar(ex);
                    Console.WriteLine(ex.Message);
                }


                Console.WriteLine("------------------------------");
                try
                {
                    if (empleados + e3)
                    {
                        Console.WriteLine($"e3 agregado");
                    }

                }
                catch (PersonaException ex)
                {

                    Log.Guardar(ex);
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("------------------------------");
                try
                {
                    if (empleados + e4)
                    {
                        Console.WriteLine($"e4 agregado");
                    }

                }
                catch (PersonaException ex)
                {

                    Log.Guardar(ex);
                    Console.WriteLine(ex.Message);
                }


                Console.WriteLine("------------------------------");
                try
                {
                    if (!(empleados + e5))
                    {
                        Console.WriteLine($"e5 no se pudo agregar");
                    }
                }
                catch (PersonaException ex)
                {

                    Log.Guardar(ex);
                    Console.WriteLine(ex.Message);
                }



                Console.WriteLine("------------------------------");
                try
                {
                    if (!(empleados + e6))
                    {
                        Console.WriteLine($"e6 no se pudo agregar");
                    }
                }
                catch (PersonaException ex)
                {

                    Console.WriteLine(ex.Message);
                }


            }
            catch (PersonaException ex)
            {

                Log.Guardar(ex);
                Console.WriteLine(ex.Message);
                
            }
            Console.WriteLine("------------------------------");

            Cliente c1 = new Cliente("Lautaro", "Moreira", 44245787, new DateTime(2001, 05, 30), ESexo.Masculino);
            Cliente c2 = new Cliente("Sebastian", "Rodriguez", 42458976, new DateTime(1996 , 01 , 05), ESexo.Masculino);
            Cliente c3 = new Cliente("Julieta", "Perez", 42123456, new DateTime(1990, 12, 03), ESexo.Femenino);
            Cliente c4 = new Cliente("Carolina", "Rivero", 43456789, new DateTime(1995, 02, 21), ESexo.Femenino);
            Cliente c5 = new Cliente("Florencia", "Davila", 42457896, new DateTime(1994, 01, 12), ESexo.Femenino);
            Cliente c6 = new Cliente("Juan", "Pereyra", 42457488, new DateTime(2001, 11, 21) , ESexo.Masculino);
            Cliente c7 = new Cliente("Micaela", "Diaz", 45789654, new DateTime(2001, 4, 21), ESexo.Femenino);
            Cliente c8 = new Cliente("Lautaro", "Moreira", 44245787, new DateTime(2001, 06, 06), ESexo.Masculino);


            Console.WriteLine("------------------------------");

            if (clientes + c1)
            {
                Console.WriteLine($"c1 agregado.");
            }

            Console.WriteLine("------------------------------");

            try
            {
                if ((clientes + c1) == false)
                {
                    Console.WriteLine($"c1 ya se encuentra en la lista.");
                }

            }
            catch (PersonaException ex)
            {
                Log.Guardar(ex);

                Console.WriteLine(ex.Message);

            }
            Console.WriteLine("------------------------------");

            if (clientes + c2)
            {
                Console.WriteLine($"c2 agregado.");
            }

            Console.WriteLine("------------------------------");

            if (clientes + c3)
            {
                Console.WriteLine($"c3 agregado.");
            }

            Console.WriteLine("------------------------------");

            if (clientes + c4)
            {
                Console.WriteLine($"c4 agregado.");
            }

            Console.WriteLine("------------------------------");

            if (clientes + c5)
            {
                Console.WriteLine($"c5 agregado.");
            }

            Console.WriteLine("------------------------------");

            if (clientes + c6)
            {
                Console.WriteLine($"c6 agregado.");
            }

            Console.WriteLine("------------------------------");

            if (clientes + c7)
            {
                Console.WriteLine($"c7 agregado.");
            }

            Console.WriteLine("------------------------------");

            if (c1 == c8)
            {
                Console.WriteLine($"{c1.MostrarInformacion()}");
                Console.WriteLine($"Y");
                Console.WriteLine($"{c1.MostrarInformacion()}");
                Console.WriteLine($"Son la misma persona");
            }

            Console.WriteLine("------------------------------");

            if (c1 != c6)
            {
                Console.WriteLine($"{c1.MostrarInformacion()}");
                Console.WriteLine($"Y");
                Console.WriteLine($"{c6.MostrarInformacion()}");

                Console.WriteLine("Son diferentes personas");
            }

            Console.WriteLine("------------------------------");

            if (e1 != e3)
            {
                Console.WriteLine($"{e1.MostrarInformacion()}");
                Console.WriteLine($"Y");
                Console.WriteLine($"{e3.MostrarInformacion()}");
                Console.WriteLine("Son diferentes empleados");
            }

            hostel.Clientes = clientes;
            hostel.Empleados = empleados;
            hostel.Habitaciones = habitaciones;

            Console.WriteLine(hostel.MostrarInformacionHostel());

            Console.WriteLine("---------------promedio camas por habitacion---------------");
            Console.WriteLine($"promedio camas: {hostel.CalcularPromedioDeCamasPorHabitacion()}");
            Console.WriteLine($"Camas disponibles: {hostel.CantidadDeCamasDisponibles()}");


            Console.WriteLine("---------------promedio edades clientes---------------");
            Console.WriteLine($"promedio edades clientes: {clientes.CalcularPromedioEdadesTotal()}");
            Console.WriteLine($"promedio edades clientes mujeres: {clientes.CalcularPromedioEdadesMujeres()}");
            Console.WriteLine($"promedio edades clientes hombres: {clientes.CalcularPromedioEdadesHombres()}");

            Console.WriteLine("---------------promedio edades empleados---------------");
            Console.WriteLine($"promedio edades empleados: {empleados.CalcularPromedioEdadesTotal()}");
            Console.WriteLine($"promedio edades empleadas mujeres: {empleados.CalcularPromedioEdadesMujeres()}");
            Console.WriteLine($"promedio edades empleados hombres: {empleados.CalcularPromedioEdadesHombres()}");

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/");

            Console.WriteLine("---------------Lista de empleados---------------");
            
            try
            {
                string rutaArchivoXmlEmpleados = Path.Combine(path, "empleados.xml");

                Xml<Personas<Empleado>> xmlSerilizarEmpleados = new Xml<Personas<Empleado>>();

                xmlSerilizarEmpleados.Serializar(rutaArchivoXmlEmpleados, empleados);

                Personas<Empleado> empleados2 = xmlSerilizarEmpleados.Deserializar("asdasd.cml");

                Console.WriteLine(empleados2.Mostrar());

            }
            catch (FileNotFoundException ex)
            {
                Log.Guardar(ex);
                Console.WriteLine("No se encontro el archivo");

            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Guardar(ex);
                Console.WriteLine("No se encontro el directorio");

            }

            Console.WriteLine("---------------Lista de habitaciones---------------");

            if (h1 + c1)
            {

            }
            try
            {
                string rutaArchivoJsonHabitaciones = Path.Combine(path, "Habitaciones.Json");

                Json<List<Habitacion>> jsonSerializerHabitaciones = new Json<List<Habitacion>>();
            
                jsonSerializerHabitaciones.Serializar(rutaArchivoJsonHabitaciones, habitaciones);

                List<Habitacion> habitacionesDeserializadas = jsonSerializerHabitaciones.Deserializar(rutaArchivoJsonHabitaciones);
                foreach (Habitacion habitacion in habitacionesDeserializadas)
                {
                    Console.WriteLine(habitacion.MostrarInformacionDeHabitacion());

                }

            }
            catch (FileNotFoundException ex)
            {
                Log.Guardar(ex);
                Console.WriteLine("No se encontro el archivo");

            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Guardar(ex);
                Console.WriteLine("No se encontro el directorio");

            }
            Console.WriteLine("---------------Lista de clientes---------------");

            try
            {
                string rutaArchivoXmlClientes = Path.Combine(path, "clientes.xml");

                Xml<Personas<Cliente>> xmlSerilizarClientes = new Xml<Personas<Cliente>>();

                xmlSerilizarClientes.Serializar(rutaArchivoXmlClientes, clientes);

                Personas<Cliente> clientes2 = xmlSerilizarClientes.Deserializar(rutaArchivoXmlClientes);

                Console.WriteLine(clientes2.Mostrar());

            }
            catch (FileNotFoundException ex)
            {
                Log.Guardar(ex);
                Console.WriteLine("No se encontro el archivo");

            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Guardar(ex);
                Console.WriteLine("No se encontro el directorio");

            }

        }
    }
}
