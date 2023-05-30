using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Clase utilizada para serializar personas en formato XML.
    /// </summary>
    [XmlRoot("SerializarPersonas")]
    public class SerializarPersonas
    {
        // <summary>
        /// Obtiene o establece la lista de pasajeros a serializar.
        /// </summary>
        [XmlElement("Pasajeros")]
        public List<Pasajero> Pasajeros { get; set; }

    }
}
