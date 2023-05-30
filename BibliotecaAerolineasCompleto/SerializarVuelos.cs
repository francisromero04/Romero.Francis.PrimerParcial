using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Clase utilizada para serializar vuelos en formato XML.
    /// </summary>
    [XmlRoot("SerializarVuelos")]
    public class SerializarVuelos
    {
        /// <summary>
        /// Obtiene o establece la lista de vuelos a serializar.
        /// </summary>
        [XmlElement("Vuelos")]
        public List<Vuelo> Vuelos { get; set; }
    }
}
