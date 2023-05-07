using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaAerolineasCompleto
{
    public class Pasajero
    {
        public int dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string segundoNombre { get; set; }
        public string segundoApellido { get; set; }
        public int estado { get; set; }

        public Pasajero()
        {

        }

        public Pasajero(int dni, string nombres, string apellidos, string segundoNombre = null, string segundoApellido = null)
        {
            this.dni = dni;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.segundoNombre = segundoNombre;
            this.segundoApellido = segundoApellido;
        }

        public Pasajero GenerarPasajeroAleatorio()
        {
            Random random = new Random(DateTime.Now.Millisecond); //lee los milisegundos de la pc y en base a eso genera el random
            int dni = random.Next(9000000, 50000000); // Generar DNI aleatorio en el rango especificado
            Console.WriteLine(dni);
            string nombre = ((Nombres[])Enum.GetValues(typeof(Nombres))).GetValue(random.Next(Enum.GetValues(typeof(Nombres)).Length)).ToString(); // Obtener un nombre aleatorio del enumerado Nombres
            string apellido = ((Apellidos[])Enum.GetValues(typeof(Apellidos))).GetValue(random.Next(Enum.GetValues(typeof(Apellidos)).Length)).ToString(); // Obtener un apellido aleatorio del enumerado Apellidos
            string segundoNombre = null;
            string segundoApellido = null;

            // Generar un segundo nombre con una probabilidad del 50%
            if (random.Next(2) == 0)
            {
                segundoNombre = ((Nombres[])Enum.GetValues(typeof(Nombres))).GetValue(random.Next(Enum.GetValues(typeof(Nombres)).Length)).ToString();
            }

            // Generar un segundo apellido con una probabilidad del 50%
            if (random.Next(2) == 0)
            {
                segundoApellido = ((Apellidos[])Enum.GetValues(typeof(Apellidos))).GetValue(random.Next(Enum.GetValues(typeof(Apellidos)).Length)).ToString();
            }

            estado = 0; // ESTADO INICIAL (no realizo ningun viaje anteriormente ni esta en un viaje en curso)
            return new Pasajero(dni, nombre, apellido, segundoNombre, segundoApellido); // Crear un nuevo objeto Pasajero con los datos aleatorios
        }

        public string nombreCompletoyDni
        {
            get
            {
                string nombreCompleto = nombres;

                if (!string.IsNullOrEmpty(segundoNombre))
                {
                    nombreCompleto += " " + segundoNombre;
                }
                nombreCompleto += " " + apellidos;
                if (!string.IsNullOrEmpty(segundoApellido))
                {
                    nombreCompleto += " " + segundoApellido;
                }
                nombreCompleto += " " + dni;
                return nombreCompleto;
            }
        }
    }
}
