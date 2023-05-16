using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Globalization;

namespace BibliotecaAerolineasCompleto
{
    public class BaseDeDatos
    {
        public Administrador administrador { get; set; }
        public Supervisor supervisor { get; set; }
        public List<Vendedor> vendedores { get; set; }

        public BaseDeDatos()
        {
            vendedores = new List<Vendedor>(3);
            ExtraerDeArchivoJSON();
        }

        public Persona BuscarUsuario(string correo, string contraseña)
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

        public void ExtraerDeArchivoJSON()
        {
            // Leemos el archivo JSON y lo almacenamos en una cadena de texto
            string json = File.ReadAllText("baseDatosUsuarios.json");

            // Deserializamos el JSON en un objeto anónimo con la misma estructura que utilizamos para serializar
            var datos = JsonConvert.DeserializeAnonymousType(json, new
            {
                administrador = new {Nombre = "", Cargo = "", Correo = "", Contraseña = "" },
                supervisor = new { Nombre = "", Cargo = "", Correo = "", Contraseña = "" },
                vendedores = new[] { new { Nombre = "", Cargo = "", Correo = "", Contraseña = "" } }
            });

            // Creamos los objetos Administrador, Supervisor y Vendedores a partir de los datos deserializados
            administrador = new Administrador(datos.administrador.Nombre,datos.administrador.Cargo,datos.administrador.Correo, datos.administrador.Contraseña);
            supervisor = new Supervisor(datos.supervisor.Nombre,datos.supervisor.Cargo, datos.supervisor.Correo, datos.supervisor.Contraseña);
            vendedores = datos.vendedores.Select(v => new Vendedor(v.Nombre,v.Cargo, v.Correo, v.Contraseña)).ToList();
        }

        public string DevolverUsuario(string correo, string contraseña)
        {
            Persona usuario = BuscarUsuario(correo, contraseña);
            if (usuario == null)
            {
                return "El usuario no existe.";
            }

            // Construir la cadena de información del usuario
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Información del usuario:");
            sb.AppendLine($"Nombre completo: {usuario.nombre}");
            sb.AppendLine($"Correo electrónico: {usuario.correo}");
            sb.AppendLine($"Contraseña: {usuario.correo}");
            if (usuario is Vendedor vendedor)
            {
                sb.AppendLine($"Tipo de usuario: Vendedor");
            }
            else if (usuario is Administrador)
            {
                sb.AppendLine($"Tipo de usuario: Administrador");
            }
            else if (usuario is Supervisor)
            {
                sb.AppendLine($"Tipo de usuario: Supervisor");
            }

            return sb.ToString();
        }
    }
}
