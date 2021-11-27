using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesHostel
{
    public class Personas<T> where T : Persona
    {
        private List<T> lista;
        private int capacidadMaxima;

        /// <summary>
        /// Constructor publico de la clase personas que inicializa la lista
        /// </summary>
        public Personas()
        {
            capacidadMaxima = 1000000000;
            lista = new List<T>();
        }

        /// <summary>
        /// Constructor de la clase personas que recibe la capacidad maxima de la lista
        /// </summary>
        /// <param name="capacidadMaxima">Capacidad de la lista</param>
        public Personas(int capacidadMaxima) : this()
        {
            this.capacidadMaxima = capacidadMaxima;
        }

        /// <summary>
        /// Propiedad que retorna la cantidad de elementos que tiene la lista
        /// </summary>
        public int Count
        {
            get
            {
                return lista.Count;
            }
        }


        /// <summary>
        /// Sobrescarga del operador + que agrega una persona a una lista.
        /// </summary>
        /// <param name="personas">lista a donde se va a agregar la persona</param>
        /// <param name="personita">Persona a agregar</param>
        /// <returns>true si pudo agregar a la persona</returns>
        /// <exception cref="PersonaException">Si la persona esta en la lista o la  lista esta llena</exception>
        public static bool operator +(Personas<T> personas, T personita)
        {
            bool result = false;
            if (personas != personita && personas.capacidadMaxima > personas.lista.Count)
            {
                personas.lista.Add(personita);
                result = true;
            }
            else if (personas == personita)
            {
                throw new PersonaException("No es posible agregar la persona porque la persona ya se encuentra en la lista.");
            }
            else if (personas.capacidadMaxima == personas.lista.Count)
            {
                throw new PersonaException("No es posible agregar la persona porque la lista ya se encuentra llena.");
            }
            return result;

        }

        /// <summary>
        /// Sobrescarga del operador - que elimina una persona de una lista.
        /// </summary>
        /// <param name="personas">Lista de personas</param>
        /// <param name="personita">Persona a eliminar</param>
        /// <returns>true si pudo eliminar a la persona</returns>
        /// <exception cref="PersonaException">Si la persona no se encuentra en la lista</exception>
        public static bool operator -(Personas<T> personas, T personita)
        {
            bool result = false;
            if (personas == personita)
            {
                personas.lista.Remove(personita);
                result = true;
            }
            else
            {
                throw new PersonaException("La persona a eliminar no se encuentra en la lista.");
            }

            return result;
        }

        /// <summary>
        /// Sobrescarga del operador == que verifica si una persona se encuentra en una lista.
        /// </summary>
        /// <param name="personas">Lista a comparar</param>
        /// <param name="personita">Personas a buscar</param>
        /// <returns>true si la persona se encuentra en la lista, false si la persona no se encuentra</returns>
        public static bool operator ==(Personas<T> personas, T personita)
        {
            bool rta = false;
            foreach (Persona item in personas.lista)
            {
                if (item == personita)
                {
                    rta = true;
                }
            }
            return rta;
        }

        /// <summary>
        /// Sobrescarga del operador != que verifica si una persona no se encuentra en una lista.
        /// </summary>
        /// <param name="listaPersonas">Lista a comparar</param>
        /// <param name="personita">Personas a buscar</param>
        /// <returns>false si la persona se encuentra en la lista, true si la persona no se encuentra</returns>
        public static bool operator !=(Personas<T> listaPersonas, T personita)
        {
            return !(listaPersonas == personita);
        }

        /// <summary>
        /// Muestra todos los elementos que se encuentran en la lista
        /// </summary>
        /// <returns>string con la informacion de los elementos de la lista</returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            
            foreach (T item in lista)
            {
                sb.AppendLine("----------------------------------");
                sb.AppendLine($"{item.MostrarInformacion()}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Calcula el promedio de la edad de los hombres en la lista
        /// </summary>
        /// <returns>float con la edad promedio</returns>
        public float CalcularPromedioEdadesHombres()
        {
            return CalcularPromedioEdades(ESexo.Masculino);
        }

        /// <summary>
        /// Calcula el promedio de la edad de las mujeres en la lista
        /// </summary>
        /// <returns>float con la edad promedio</returns>
        public float CalcularPromedioEdadesMujeres()
        {
            return CalcularPromedioEdades(ESexo.Femenino);
        }

        /// <summary>
        /// Calcula la edad promedoi de todas las personas de la lista
        /// </summary>
        /// <returns>float con el promedio total de las personas</returns>
        public float CalcularPromedioEdadesTotal()
        {
            float promedio = 0;
            int sumaEdades = 0;
            

            foreach (T item in lista)
            {
                sumaEdades += item.Edad;
            }

            promedio = (float)sumaEdades / lista.Count;

            return promedio;
        }

        /// <summary>
        /// Calcula el promedio de edades dependiendo el sexo
        /// </summary>
        /// <param name="sexo">sexo de las personas que se quiere tener el promedio</param>
        /// <returns>float con el promedio de las edades</returns>
        private float CalcularPromedioEdades(ESexo sexo)
        {
            float promedio = 0;
            int sumaEdades = 0;
            int cantidad = CalcularCantidadDePersonas(sexo);

            foreach (T item in lista)
            {
                if (item.Sexo == sexo)
                {
                    sumaEdades += item.Edad;
                }
            }

            promedio = (float)sumaEdades / cantidad;

            return promedio;
        }

        /// <summary>
        /// Calcula la cantidad de personas dependiendo el sexo
        /// </summary>
        /// <param name="sexo">sexo de las personas a obtener la cantidad</param>
        /// <returns>int con la cantidad de personas de ese sexo</returns>
        private int CalcularCantidadDePersonas(ESexo sexo)
        {
            int cantidad = 0;
            foreach (T item in lista)
            {
                if (item.Sexo == sexo)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }

        /// <summary>
        /// Busca la persona mas grande en la lista y la retorna
        /// </summary>
        /// <returns>T persona mas grande de la lista</returns>
        public T PersonaMasGrande()
        {
            T personaMasGrande  = null ; 
            foreach(Persona persona in lista)
            {
                if (personaMasGrande is null || persona.Edad > personaMasGrande.Edad)
                {
                    personaMasGrande = persona as T;
                }
            }
            return personaMasGrande;
        }

        /// <summary>
        /// Busca la persona mas chica en la lista y la retorna
        /// </summary>
        /// <returns>T persona mas chica de la lista</returns>
        public T PersonaMasChica()
        {
            T personaMasChica = null;
            foreach (Persona persona in lista)
            {
                if (personaMasChica is null || persona.Edad < personaMasChica.Edad)
                {
                    personaMasChica = persona as T;
                }
            }
            return personaMasChica;
        }
        
        /// <summary>
        /// retorna la cantidad de hombres en la lista
        /// </summary>
        public int CantidadDeHombres
        {
            get
            {
                return CalcularCantidadDePersonas(ESexo.Masculino);
            }
        }

        /// <summary>
        /// retorna la cantidad de mujeres en la lista
        /// </summary>
        public int CantidadDeMujeres
        {
            get
            {
                return CalcularCantidadDePersonas(ESexo.Femenino);
            }
        }

        /// <summary>
        /// Retorna o ingresa la lista de personas
        /// </summary>
        public List<T> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        /// <summary>
        /// Retorna o ingresa la cantidad maxima de personas en la lista 
        /// </summary>
        public int CapacidadMaxima
        {
            get { return capacidadMaxima; }
            set { capacidadMaxima = value; }
        }
    }
}
