using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Clase estática que proporciona métodos de validación para diferentes tipos de datos.
    /// </summary>
    public static class Validador
    {
        /// <summary>
        /// Valida si una matrícula cumple con el formato requerido.
        /// </summary>
        /// <param name="matricula">La matrícula a validar.</param>
        /// <returns>True si la matrícula es válida; de lo contrario, False.</returns>
        public static bool ValidarMatricula(string matricula)
        {
            if (matricula.Length != 8) return false;
            for (int i = 0; i < 4; i++)
            {
                if (!char.IsUpper(matricula[i])) return false;
            }
            for (int i = 4; i < 8; i++)
            {
                if (!char.IsDigit(matricula[i])) return false;
            }
            return true;
        }

        /// <summary>
        /// Valida si un número entero es positivo o cero.
        /// </summary>
        /// <param name="numero">El número entero a validar.</param>
        /// <returns>True si el número es positivo o cero; de lo contrario, False.</returns>
        public static bool ValidarNumeroPositivo(int numero)
        {
            return numero >= 0;
        }

        /// <summary>
        /// Valida si un número de DNI (Documento Nacional de Identidad) está dentro del rango permitido.
        /// </summary>
        /// <param name="dni">El número de DNI a validar.</param>
        /// <returns>True si el número de DNI está dentro del rango permitido; de lo contrario, False.</returns>
        public static bool ValidarDNI(int dni)
        {
            if (dni < 9000000 || dni > 50000000)
            {
                // El DNI está fuera del rango permitido
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida si una cadena de texto contiene solo caracteres alfabéticos y especiales.
        /// </summary>
        /// <param name="cadena">La cadena de texto a validar.</param>
        /// <returns>True si la cadena de texto contiene solo caracteres alfabéticos y especiales; de lo contrario, False.</returns>
        public static bool ValidarCadena(string cadena)
        {
            Regex regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ]+$");
            return regex.IsMatch(cadena);
        }

        /// <summary>
        /// Valida si una cadena de texto contiene solo caracteres alfabéticos y, opcionalmente, espacios.
        /// </summary>
        /// <param name="cadena">La cadena de texto a validar.</param>
        /// <param name="permitirEspacios">Indica si se permiten espacios en la cadena de texto.</param>
        /// <returns>True si la cadena de texto contiene solo caracteres alfabéticos y, opcionalmente, espacios; de lo contrario, False.</returns>
        public static bool ValidarCadena(string cadena, bool permitirEspacios)
        {
            Regex regex;
            if (permitirEspacios)
            {
                regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\\s]+$");
            }
            else
            {
                regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ]+$");
            }
            return regex.IsMatch(cadena);
        }
    }
}
