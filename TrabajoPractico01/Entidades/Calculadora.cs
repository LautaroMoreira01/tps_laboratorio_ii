using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Operacion
        /// <summary>
        /// Realiza la operacion ingresada por parametro con los operandos.
        /// </summary>
        /// <param name="num1">Primer operando.</param>
        /// <param name="num2">Segundo operando.</param>
        /// <param name="operador">Operacion a realizar.</param>
        /// <returns>El resultado de la operacion realizada.</returns>
        public static double Operar(Operando num1 , Operando num2 , char operador)
        {
            double rta = 0;

            switch (ValidarOperador(operador))
            {
                case '+':
                    rta = num1 + num2;
                    break;
                case '-':
                    rta = num1 - num2;
                    break;
                case '*':
                    rta = num1 * num2;
                    break;
                case '/':
                    rta = num1 / num2;
                    break;
            }
            return rta;
        }

        #endregion

        #region Validacion
        /// <summary>
        /// Valida si el operador ingresado es valido.
        /// </summary>
        /// <param name="operador">Tipo de operacion a validar.</param>
        /// <returns>Retorna + si el operador ingresado es invalido y si es valido retorna el mismo.</returns>
        private static char ValidarOperador(char operador)
        {
            if(operador != '+'&& operador != '*' && operador != '/' && operador != '-')
            {
                return '+';
            }
            return operador;
        }

        #endregion
    }
}
