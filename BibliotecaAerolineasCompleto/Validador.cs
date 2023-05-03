using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    public static class Validador
    {
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

        public static bool ValidarNumeroPositivo(int numero)
        {
            return numero >= 0;
        }

        public static bool ValidarDNI(int dni)
        {
            if (dni < 9000000 || dni > 50000000)
            {
                // El DNI está fuera del rango permitido
                return false;
            }

            return true;
        }

        public static bool ValidarCadena(string cadena)
        {
            Regex regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ]+$");
            return regex.IsMatch(cadena);
        }
    }
}
