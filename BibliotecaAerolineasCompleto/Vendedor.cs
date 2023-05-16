using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    public class Vendedor :Persona
    {
        public Vendedor(string nombre, string cargo, string correo, string contraseña) : base(nombre, cargo, correo, contraseña)
        {
            // Constructor vacío
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}, Cargo: {cargo}, Correo: {correo}";
        }
    }
}
