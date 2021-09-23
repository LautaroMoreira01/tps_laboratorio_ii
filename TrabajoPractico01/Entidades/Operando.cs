using System;

namespace Entidades
{
    public class Operando
    {
        //Pregutar sobre el ctor de string.
        private double numero;


        #region Constructores
        /// <summary>
        /// Constructor sin parametros de entrada que inicializa en 0 el operando.
        /// </summary>
        public Operando()
        {
            numero = 0;
        }
        /// <summary>
        /// Constructor con un parametro de entrada tipo string que inicializa el operando con el valor ingresado.
        /// </summary>
        /// <param name="strNumero">Parametro tipo string.</param>
        public Operando(string strNumero)
        {
            this.numero = ValidaOperando(strNumero);
        }
        /// <summary>
        /// Constructor con un parametro de entrada que inicializa el operando con el parametro ingresado.
        /// 
        /// </summary>
        /// <param name="numero">Parametro tipo double.</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        #endregion
        
        #region propiedades
        /// <summary>
        /// Propiedad que valida el numero y lo ingresa.
        /// </summary>
        public string Numero
        {
            set
            {

                numero = ValidaOperando(value);

            }

        }
        #endregion

        #region Validaciones
        /// <summary>
        /// Valida el numero pasado por string lo parsea a double y lo retorna.
        /// </summary>
        /// <param name="strNumero">parametro tipo string.</param>
        /// <returns>el numero validado y parseado.</returns>
        private double ValidaOperando(string strNumero)
        {
            double numero;

            if(double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            return 0;

        }
        /// <summary>
        /// Valida si el el stirng pasado contiene solo 0 y 1.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>true si el numero ingresado es binario, de lo contrario retorna false</returns>
        private bool EsBinario(string binario)
        {
            bool rta = true;
            for(int i= 0; i < binario.Length; i++)
            {
                if(binario[i] != '0' && binario[i] !='1')
                {
                    rta = false;
                }
            }

            return rta; 
        }
        #endregion

        #region Conversores
        /// <summary>
        /// Convierte el numero pasado como parametro de binario a double.
        /// </summary>
        /// <param name="binario">numero binario de tipo string.</param>
        /// <returns>Retorna el numero binario en double tipo string.</returns>
        public string BinarioDecimal(string binario)
        {
            string rta = "Valor invalido.";
            if (EsBinario(binario))
            {
                int aux;
                int res = 0;

                for (int i = 0; i < binario.Length; i++)
                {
                    aux = int.Parse(binario[i].ToString());

                    res = res * 2 + aux;
                }
                rta = res.ToString();

                return rta;
            }
            return rta;
        }
        /// <summary>
        /// Convierte el numero pasado como parametro de decimal a binario.
        /// </summary>
        /// <param name="numero">numero tipo double.</param>
        /// <returns>Retorna el numero ingresado en binario.</returns>
        public string DecimalBinario(double numero)
        {
            numero = Math.Abs(numero);

            string binario = "";
            if(numero > 0)
            {
                while (numero > 0)
                {
                    binario = (numero % 2).ToString() + binario;
                    numero =  (int)numero / 2;
                }
                return binario;
            }
            return "Valor invalido.";
        }
        /// <summary>
        /// Convierte el numero pasado como parametro a binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el numero ingresado en binario.</returns>
        public string DecimalBinario(string numero)
        {
            double aux;
            
            if(double.TryParse(numero, out aux))
            {
                return DecimalBinario(aux);
            }
            return "Valor invalido.";
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador + que permite sumar dos operandos.
        /// </summary>
        /// <param name="n1">primer numero a sumar.</param>
        /// <param name="n2">segundo numero a sumar.</param>
        /// <returns>La suma de los dos numeros.</returns>
        public static double operator +(Operando n1 , Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador - que permite restar dos operandos.
        /// </summary>
        /// <param name="n1">primer numero a restar.</param>
        /// <param name="n2">segundo numero a restar.</param>
        /// <returns>La resta de los dos numeros.</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador * que permite multiplicar dos operandos.
        /// </summary>
        /// <param name="n1">primer numero a multiplicar.</param>
        /// <param name="n2">segundo numero a multiplicar.</param>
        /// <returns>Producto del resultado de los dos numeros.</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador / que permite dividir dos operandos.
        /// </summary>
        /// <param name="n1">primer numero o divisor.</param>
        /// <param name="n2">segundo numero o dividendo.</param>
        /// <returns>Cociente del resultado de los dos numeros, si el divisor es 0 retorna double.minValue</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }

            return n1.numero / n2.numero;
        }

        #endregion
    }
}
