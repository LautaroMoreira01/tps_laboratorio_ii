using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
namespace EntidadesHostel
{

    public delegate void DelegadoEncuestarCliente(Cliente cliente);

    public class Cliente : Persona
    {
        public event DelegadoEncuestarCliente notificarClienteEncuestado;

        private int puntuacionDelServicio;
        private bool volverianAVenir;
        
        /// <summary>
        /// Constructor por defecto de la clase cliente
        /// </summary>
        public Cliente()
        {

        }

        /// <summary>
        /// Constructor de la clase cliente
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="apellido">Apellido del cliente</param>
        /// <param name="dni">Dni del cliente</param>
        /// <param name=fechaDeNacimiento">Fecha de nacimiento del cliente</param>
        /// <param name="sexo">Sexo del cliente</param>
        public Cliente(string nombre, string apellido, long dni, DateTime fechaDeNacimiento, ESexo sexo) : base(nombre, apellido, dni, fechaDeNacimiento, sexo)
        {
        }

        /// <summary>
        /// Metodo que muestra los resultados de la encuesta.
        /// </summary>
        /// <returns>string con los resultados</returns>
        public string MostrarResultadosEncuesta()
        {
            return $"Puntuacion del servicio: {puntuacionDelServicio:00.00}\n Volveria a venir? {VolveriaAVenir}";
        }

        public void EncuestarCliente()
        {
            Random random = new Random();
            PuntuacionDelServicio = random.Next(0, 6);
            int volverianAVenir = random.Next(0, 2);

            if (volverianAVenir == 1)
            {
                VolveriaAVenir = true;
            }
            else
            {
                VolveriaAVenir = false;
            }

            if(!(notificarClienteEncuestado is null))//PREGUNTAR ESTO SI ESTA BIEN
            {
                notificarClienteEncuestado.Invoke(this);
            }
        }


        /// <summary>
        /// Propiedad que asigna y retorna los datos de la puntuacion del servicio
        /// </summary>
        public int PuntuacionDelServicio { get => puntuacionDelServicio; set => puntuacionDelServicio = value;}


        /// <summary>
        /// Propiedad que asigna y retorna si un cliente volveria a venir al hostel
        /// </summary>
        public bool VolveriaAVenir 
        { 
            get => volverianAVenir; 
        
            set
            { 
                volverianAVenir = value; 

            } 
        }


    }
}
