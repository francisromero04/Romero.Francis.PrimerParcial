using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    public class Persona
    {
        public string cargo { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public string nombre { get; set; }

        public Persona(string nombre, string cargo, string correo, string contraseña)
        {
            this.nombre = nombre;
            this.cargo = cargo;
            this.correo = correo;
            this.contraseña = contraseña;
        }
    }
}
