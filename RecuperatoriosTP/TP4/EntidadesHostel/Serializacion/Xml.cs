using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EntidadesHostel
{
    public class Xml<T> : ISerializable<T>
    {
        /// <summary>
        /// metodo que serializa a xml y lo guarda en un archivo
        /// </summary>
        /// <param name="ruta">ruta de donde se guardara el archivo</param>
        /// <param name="objeto">objeto a serializar</param>
        /// <exception cref="FileNotFoundException">Se lanzara si no se encuentra el archivo</exception>
        /// <exception cref="DirectoryNotFoundException">Se lanzara si no se encuentra el directorio</exception>
        public void Serializar(string ruta, T objeto)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, objeto);
                }

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
        /// metodo que deserializa un objeto de xml y retorna
        /// </summary>
        /// <param name="ruta">ruta de donde se obtendra el archivoa deserializar </param>
        /// <returns>objeto deserializado</returns>
        /// <exception cref="FileNotFoundException">Se lanzara si no se encuentra el archivo</exception>
        /// <exception cref="DirectoryNotFoundException">Se lanzara si no se encuentra el directorio</exception>
        public T Deserializar(string ruta)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    return (T)xmlSerializer.Deserialize(streamReader);
                }
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
