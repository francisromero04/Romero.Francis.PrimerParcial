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

        public Persona(string cargo, string correo, string contraseña)
        {
            this.cargo = cargo;
            this.correo = correo;
            this.contraseña = contraseña;
        }
    }
}
