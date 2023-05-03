using System;
using System.Collections.Generic;
using System.Linq;
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

        public Pasajero() 
        {
            
        }

        public Pasajero(int dni, string nombres, string apellidos)
        {
            this.dni = dni;
            this.nombres = nombres;
            this.apellidos = apellidos;
        }

        public Pasajero GenerarPasajeroAleatorio()
        {
            Random random = new Random();
            int dni = random.Next(9000000, 50000000); // Generar DNI aleatorio en el rango especificado
            string nombre = ((Nombres[])Enum.GetValues(typeof(Nombres))).GetValue(random.Next(Enum.GetValues(typeof(Nombres)).Length)).ToString(); // Obtener un nombre aleatorio del enumerado Nombres
            string apellido = ((Apellidos[])Enum.GetValues(typeof(Apellidos))).GetValue(random.Next(Enum.GetValues(typeof(Apellidos)).Length)).ToString(); // Obtener un apellido aleatorio del enumerado Apellidos
            return new Pasajero(dni, nombre, apellido); // Crear un nuevo objeto Pasajero con los datos aleatorios
        }

        public string nombreCompletoyDni
        {
            get { return nombres + " " + apellidos + " " + dni; }
        }
    }
}
