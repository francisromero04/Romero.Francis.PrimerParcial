using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    public class BaseDeDatos
    {
        public Administrador administrador { get; set; }
        public Supervisor supervisor { get; set; }
        public List<Vendedor> vendedores { get; set; }

        public BaseDeDatos()
        {
            this.administrador = new Administrador("Administrador", "admin@mail.com", "1234");
            this.supervisor = new Supervisor("Supervisor", "supervisor@mail.com", "5678");
            vendedores = new List<Vendedor>(3);
            vendedores.Add(new Vendedor("Vendedor 1", "vendedor1@mail.com", "abcd"));
            vendedores.Add(new Vendedor("Vendedor 2", "vendedor2@mail.com", "efgh"));
            vendedores.Add(new Vendedor("Vendedor 3", "vendedor3@mail.com", "zzzz"));
        }

        public Persona buscarUsuario(string correo, string contraseña)
        {
            foreach (Vendedor vendedor in vendedores)
            {
                if (vendedor.correo == correo && vendedor.contraseña == contraseña)
                {
                    return vendedor;
                }
            }

            if (administrador.correo == correo && administrador.contraseña == contraseña)
            {
                return administrador;
            }

            if (supervisor.correo == correo && supervisor.contraseña == contraseña)
            {
                return supervisor;
            }

            return null;
        }
    }
}
