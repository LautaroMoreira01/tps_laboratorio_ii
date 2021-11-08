using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesHostel
{
    public interface ISerializable<T>
    {
        /// <summary>
        /// Metodo que serializara el elemento que se quiera
        /// </summary>
        /// <param name="ruta"> ruta donde se guardara el archivo</param>
        /// <param name="objeto">objeto a serializar</param>
        public void Serializar(string ruta, T objeto);

        /// <summary>
        /// Metodo que deserializara un archivo
        /// </summary>
        /// <param name="ruta">ruta de donde se obtiene el archivo a deserializar</param>
        /// <returns>String con el objeto deserializado</returns>
        public T Deserializar(string ruta);


    }
}
