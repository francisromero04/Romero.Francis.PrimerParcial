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
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string segundoNombre { get; set; }
        public string segundoApellido { get; set; }
        public int estado { get; set; }
        public bool tipoPasajero { get; set; }
        public bool Genero { get; set; }
        public decimal pesoEquipaje { get; set; }

        public Pasajero()
        {

        }

        public Pasajero(int dni, string nombre, string apellido, string segundoNombre = null, string segundoApellido = null, bool tipoDePasajero = true, bool genero = true, decimal pesoEquipaje = 0)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.segundoNombre = segundoNombre;
            this.segundoApellido = segundoApellido;
            this.tipoPasajero = tipoDePasajero;
            this.Genero = genero; //true = masculino | false = femenino 
            this.pesoEquipaje = pesoEquipaje;
        }

        public Pasajero GenerarPasajeroAleatorio(Random random)
        {
            int dni = random.Next(9000000, 50000000); // Generar DNI aleatorio en el rango especificado

            // Generar el género aleatoriamente
            bool genero = random.Next(2) == 0 ? true : false;

            // Obtener un nombre aleatorio
            string nombre = "";

            if (genero == true)
            {
                // Generar un nombre de hombre aleatorio
                nombre = ((NombresDeHombre)random.Next(Enum.GetNames(typeof(NombresDeHombre)).Length)).ToString();
            }
            else
            {
                // Generar un nombre de mujer aleatorio
                nombre = ((NombresDeMujer)random.Next(Enum.GetNames(typeof(NombresDeMujer)).Length)).ToString();
            }

            // Determinar si el pasajero tendrá segundo nombre o no (50% de probabilidades)
            string segundoNombre = "";
            if (random.Next(2) == 0)
            {
                if (genero == true)
                {
                    // Generar un segundo nombre de hombre aleatorio
                    segundoNombre = ((NombresDeHombre)random.Next(Enum.GetNames(typeof(NombresDeHombre)).Length)).ToString();
                }
                else
                {
                    // Generar un segundo nombre de mujer aleatorio
                    segundoNombre = ((NombresDeMujer)random.Next(Enum.GetNames(typeof(NombresDeMujer)).Length)).ToString();
                }
            }

            // Obtener un apellido aleatorio
            string apellido = ((Apellidos)random.Next(Enum.GetNames(typeof(Apellidos)).Length)).ToString();

            // Determinar si el pasajero tendrá segundo apellido o no (50% de probabilidades)
            string segundoApellido = "";
            if (random.Next(2) == 0)
            {
                // Generar un segundo apellido aleatorio
                segundoApellido = ((Apellidos)random.Next(Enum.GetNames(typeof(Apellidos)).Length)).ToString();
            }

            // Si el pasajero tiene segundo nombre, asegurarse de que sea del mismo género que el primero
            if (segundoNombre != "" && (genero == true && !Enum.IsDefined(typeof(NombresDeHombre), segundoNombre)
                || genero == false && !Enum.IsDefined(typeof(NombresDeMujer), segundoNombre)))
            {
                if (genero == true)
                {
                    // Generar un segundo nombre de hombre aleatorio
                    segundoNombre = ((NombresDeHombre)random.Next(Enum.GetNames(typeof(NombresDeHombre)).Length)).ToString();
                }
                else
                {
                    // Generar un segundo nombre de mujer aleatorio
                    segundoNombre = ((NombresDeMujer)random.Next(Enum.GetNames(typeof(NombresDeMujer)).Length)).ToString();
                }
            }

            bool tipoPasajero = (random.Next(2) == 0); // Generar el tipo de pasajero con una probabilidad del 50%
            estado = 0; // ESTADO INICIAL (no realizo ningun viaje anteriormente ni esta en un viaje en curso)
            decimal pesoEquipaje = (decimal)(random.Next(500, 2300)) / 100.0M;

            return new Pasajero(dni, nombre, apellido, segundoNombre, segundoApellido, tipoPasajero, genero, pesoEquipaje); // Crear un nuevo objeto Pasajero con los datos aleatorios
        }

        public string nombreCompletoyDni
        {
            get
            {
                string nombreCompleto = nombre;

                if (!string.IsNullOrEmpty(segundoNombre))
                {
                    nombreCompleto += " " + segundoNombre;
                }
                nombreCompleto += " " + apellido;
                if (!string.IsNullOrEmpty(segundoApellido))
                {
                    nombreCompleto += " " + segundoApellido;
                }
                nombreCompleto += " " + dni;

                if (tipoPasajero == true)
                {
                    nombreCompleto += " (turista)";
                }
                else
                {
                    nombreCompleto += " (premium)";
                }

                if(Genero == true)
                {
                    nombreCompleto += " (masculino)";
                }
                else
                {
                    nombreCompleto += " (femenino)";
                }

                return nombreCompleto;
            }
        }
    }
}
