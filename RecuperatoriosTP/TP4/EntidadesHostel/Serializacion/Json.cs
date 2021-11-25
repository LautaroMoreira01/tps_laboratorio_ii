using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace EntidadesHostel
{
    public class Json<T> : ISerializable<T>
    {
        /// <summary>
        /// metodo que serializa a json y lo guarda en un archivo
        /// </summary>
        /// <param name="ruta">ruta de donde se guardara el archivo</param>
        /// <param name="objeto">objeto a serializar</param>
        /// <exception cref="FileNotFoundException">Se lanzara si no se encuentra el archivo</exception>
        /// <exception cref="DirectoryNotFoundException">Se lanzara si no se encuentra el directorio</exception>
        public void Serializar(string ruta, T objeto)
        {
            try
            {
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
                jsonSerializerOptions.WriteIndented = true;

                string objetoJson = JsonSerializer.Serialize(objeto, jsonSerializerOptions);

                File.WriteAllText(ruta, objetoJson);

            }
            catch (FileNotFoundException ex)
            {

                throw new FileNotFoundException("El archivo no fue encontrado.", ex.InnerException);
            }
            catch (DirectoryNotFoundException ex)
            {

                throw new DirectoryNotFoundException("El directorio no fue encontrado.", ex.InnerException);
            }
        }




        /// <summary>
        /// metodo que deserializa un objeto de json y retorna
        /// </summary>
        /// <param name="ruta">ruta de donde se obtendra el archivoa deserializar </param>
        /// <returns>objeto deserializado</returns>
        /// <exception cref="FileNotFoundException">Se lanzara si no se encuentra el archivo</exception>
        /// <exception cref="DirectoryNotFoundException">Se lanzara si no se encuentra el directorio</exception>
        public T Deserializar(string ruta)
        {

            try
            {

                string objetoJson = File.ReadAllText(ruta);

                return JsonSerializer.Deserialize<T>(objetoJson);
            
            }
            catch (FileNotFoundException ex)
            {

                throw new FileNotFoundException("El archivo no fue encontrado.", ex.InnerException);
            }
            catch (DirectoryNotFoundException ex)
            {

                throw new DirectoryNotFoundException("El directorio no fue encontrado.", ex.InnerException);
            }

        }
    }
}
