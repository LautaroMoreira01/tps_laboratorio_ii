using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntidadesHostel
{
    public class Log
    {
        private static string path  = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");

        /// <summary>
        /// Metodo que lee el log de un archivo
        /// </summary>
        /// <returns>Informacion del archvo de logs</returns>
        public static string Leer()
        {
            
            StreamReader streamReader = null; 
            try
            {
                
                using (streamReader = new StreamReader(path))
                {
                    string texto = streamReader.ReadToEnd();
                    return texto;
                }

            }
            catch (FileNotFoundException FileNotFoundEx)
            {
                throw FileNotFoundEx;
            }
            catch (DirectoryNotFoundException directoryNotFoundEx)
            {
                throw directoryNotFoundEx;
            }
            catch (Exception exep)
            {
                throw exep;

            }
            finally
            {

                if (!(streamReader is null))
                {
                    streamReader.Close();
                    streamReader.Dispose();
                }
            }
        }

        /// <summary>
        /// Guarda la excepcion pasada como parametro en un archivo de logs
        /// </summary>
        /// <param name="ex">excepcion a guardar en el log</param>
        public static void Guardar(Exception ex )
        {
            StreamWriter streamWriter = null;
            string log = Leer();
            try
            {

                using (streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine(log);
                    streamWriter.WriteLine("------------------------------");
                    streamWriter.WriteLine("Fecha y hora:");
                    streamWriter.WriteLine(DateTime.Now);
                    streamWriter.WriteLine("Tipo de exepcion:");
                    streamWriter.WriteLine(ex);
                    streamWriter.WriteLine("Error:");
                    streamWriter.WriteLine(ex);
                    streamWriter.WriteLine("stack trace:");
                    streamWriter.WriteLine(ex.StackTrace);

                }

            }
            catch (FileNotFoundException FileNotFoundEx)
            {
                throw FileNotFoundEx;
            }
            catch (DirectoryNotFoundException directoryNotFoundEx)
            {
                throw directoryNotFoundEx;
            }
            catch (Exception exep)
            {
                throw exep;

            }
            finally
            {
                if (!(streamWriter is null))
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }





    }
}
