using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibliotecaAerolineasCompleto
{
    [XmlRoot("SerializarPersonas")]
    public class SerializarPersonas
    {
        [XmlElement("Pasajeros")]
        public List<Pasajero> Pasajeros { get; set; }

    }
}
