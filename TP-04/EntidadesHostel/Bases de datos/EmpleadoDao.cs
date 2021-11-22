using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EntidadesHostel
{
    public class EmpleadoDao
    {
        private static string cadenaConexion;
        private static SqlCommand sqlCommand;
        private static SqlConnection sqlConnection;

        static EmpleadoDao()
        {
            cadenaConexion = @"Server = .; Database = PERSONAS_DB; Trusted_Connection = True;";
            sqlCommand = new SqlCommand();
            sqlConnection = new SqlConnection(cadenaConexion);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.Text;

        }

        /// <summary>
        /// Metodo que lee de una base de datos y te trae todos los elementos en una lista de personas
        /// </summary>
        /// <returns>Elementos de la base de datos en forma de lista de personas</returns>
        public static Personas<Empleado> Leer()
        {
            Personas<Empleado> empleados = new Personas<Empleado>(4);
            
            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "select * from EMPLEADOS";
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {

                    string nombre = dataReader["nombre"].ToString();
                    string apellido = dataReader["apellido"].ToString();
                    long dni = Convert.ToInt64(dataReader["dni"]);
                    float salario = (float)Convert.ToDouble(dataReader["salario"]);
                    ESexo sexo = (ESexo)Convert.ToInt32(dataReader["sexo"]);
                    EPuesto puesto = (EPuesto)Convert.ToInt32(dataReader["puesto"]);
                    DateTime fechaNacimiento = (DateTime)dataReader["fechaNacimiento"];


                    if (empleados + (new Empleado(nombre, apellido, dni, fechaNacimiento, sexo, puesto, salario))) { }; 

                }
                dataReader.Close();
                return empleados;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        /// <summary>
        /// guarda los datos de un nuevo empleado en la base de datos
        /// </summary>
        /// <param name="empleado">empleado a guardar</param>
        public static void Guardar(Empleado empleado)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();
                
                sqlCommand.CommandText = $"INSERT INTO EMPLEADOS (nombre , apellido , fechaNacimiento , sexo , dni , salario, puesto) VALUES ( @nombre, @apellido, @fechaDeNacimiento, @sexo, @dni, @salario, @puesto)";

                sqlCommand.Parameters.AddWithValue("@nombre", empleado.Nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", empleado.Apellido);
                sqlCommand.Parameters.AddWithValue("@fechaDeNacimiento", empleado.FechaNacimiento);
                sqlCommand.Parameters.AddWithValue("@sexo", (int)empleado.Sexo);
                sqlCommand.Parameters.AddWithValue("@dni", empleado.Dni);
                sqlCommand.Parameters.AddWithValue("@salario", empleado.Salario);
                sqlCommand.Parameters.AddWithValue("@puesto", (int)empleado.Puesto);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Actualiza los datos de un empleado en una base de datos
        /// </summary>
        /// <param name="empleado">empleado a actualizar</param>
        public static void ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();

                sqlCommand.CommandText = $"UPDATE EMPLEADOS SET nombre=@nombre , apellido=@apellido , fechaNacimiento=@fechaDeNacimiento, sexo=@sexo , salario=@salario, puesto=@puesto WHERE dni = @dni;";

                sqlCommand.Parameters.AddWithValue("@nombre", empleado.Nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", empleado.Apellido);
                sqlCommand.Parameters.AddWithValue("@fechaDeNacimiento", empleado.FechaNacimiento);
                sqlCommand.Parameters.AddWithValue("@sexo", (int)empleado.Sexo);
                sqlCommand.Parameters.AddWithValue("@dni", empleado.Dni);
                sqlCommand.Parameters.AddWithValue("@salario", empleado.Salario);
                sqlCommand.Parameters.AddWithValue("@puesto", (int)empleado.Puesto);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }


        }

        /// <summary>
        /// Elimina fisicamente un empleado de una base de datos
        /// </summary>
        /// <param name="empleado"></param>
        public static void EliminarEmpleado(Empleado empleado)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();

                sqlCommand.CommandText = $"DELETE FROM EMPLEADOS WHERE dni=@dni;";

                sqlCommand.Parameters.AddWithValue("@dni", empleado.Dni);
         
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }


        }

    }


}
