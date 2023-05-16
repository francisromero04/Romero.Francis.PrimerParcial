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

        public Pasajero(int dni, string nombre, string apellido, bool genero, bool tipoPasajero, string segundoNombre, string segundoApellido, decimal pesoEquipaje) : this()
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.segundoNombre = segundoNombre;
            this.segundoApellido = segundoApellido;
            this.Genero = genero; //true = masculino | false = femenino 
            this.pesoEquipaje = pesoEquipaje;
            this.tipoPasajero = tipoPasajero;
        }   

        #region GENERADORES

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

        public override bool Equals(object obj)
        {
            // Si el objeto es null, entonces no son iguales
            if (obj == null)
                return false;

            // Si el objeto no es de tipo Pasajero, entonces no son iguales
            if (!(obj is Pasajero))
                return false;

            // Compara el dni para determinar si son iguales
            Pasajero pasajero = (Pasajero)obj;
            return dni == pasajero.dni;
        }

        public override int GetHashCode()
        {
            return dni.GetHashCode();
        }

        #endregion
    }
}



















 /*    public Pasajero GenerarPasajeroAleatorio(Random random)
        {
            int dni = random.Next(9000000, 50000000); // Generar DNI aleatorio en el rango especificado            
            bool genero = random.Next(2) == 0 ? true : false; // Generar el género aleatoriamente
            string nombre = ObtenerNombreAleatorio(random, genero); // Obtener un nombre aleatorio
            string apellido = ObtenerApellidoAleatorio(random);// Obtener un apellido aleatorio
            estado = 0; // ESTADO INICIAL (no realizo ningun viaje anteriormente ni esta en un viaje en curso)
            decimal pesoEquipaje = (decimal)(random.Next(500, 2300)) / 100.0M;
            System.Threading.Thread.Sleep(1);
            //MODIFICAR PARA QUE HAYA MENOS PROBABILIDAD DE PREMIUM
        //    bool tipoPasajero = random.Next(2) == 0 ? true : false; // Generar el tipo de pasajero con una probabilidad del 50% 

            bool tipoPasajero = random.Next(10) == 0 ? false : true; // Generar el tipo de pasajero con una probabilidad del 10%

            // Determinar si el pasajero tendrá segundo nombre o no (50% de probabilidades)
            string segundoNombre = ""; 
            if (random.Next(2) == 0) 
            {
                segundoNombre = ObtenerNombreAleatorio(random, genero);
            }

            // Determinar si el pasajero tendrá segundo apellido o no (50% de probabilidades)
            string segundoApellido = "";
            if (random.Next(2) == 0)
            {
                segundoApellido = ObtenerApellidoAleatorio(random);
            }

            // Si el pasajero tiene segundo nombre, asegurarse de que sea del mismo género que el primer nombre
            if (segundoNombre != "" && !EsMismoGenero(nombre, segundoNombre, genero))
            {
                segundoNombre = ObtenerNombreAleatorio(random, genero);
            }

            return new Pasajero(dni, nombre, apellido, genero, tipoPasajero, segundoNombre, segundoApellido, pesoEquipaje); // Crear un nuevo objeto Pasajero con los datos aleatorios
        }*/


       /* private string ObtenerNombreAleatorio(Random random, bool genero)
        {
            if (genero)
            {
                // Generar un nombre de hombre aleatorio
                return ((NombresDeHombre)random.Next(Enum.GetNames(typeof(NombresDeHombre)).Length)).ToString();
            }
            else
            {
                // Generar un nombre de mujer aleatorio
                return ((NombresDeMujer)random.Next(Enum.GetNames(typeof(NombresDeMujer)).Length)).ToString();
            }
        }

        private string ObtenerApellidoAleatorio(Random random)
        {
            return ((Apellidos)random.Next(Enum.GetNames(typeof(Apellidos)).Length)).ToString();
        }

        private bool EsMismoGenero(string primerNombre, string segundoNombre, bool genero)
        {
            if (genero)
            {
                return Enum.IsDefined(typeof(NombresDeHombre), segundoNombre);
            }
            else
            {
                return Enum.IsDefined(typeof(NombresDeMujer), segundoNombre);
            }
        }*/
