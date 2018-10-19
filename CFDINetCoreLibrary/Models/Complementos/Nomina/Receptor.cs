using System.Xml.Serialization;

namespace CFDINetCoreLibrary.Models.Complementos.Nomina
{
    public class Receptor
    {
        [XmlAttribute("Curp")]
        public string curp { get; set; }

        [XmlAttribute("NumSeguridadSocial")]
        public string numeroSeguridadSocial { get; set; }

        [XmlAttribute("FechaInicioRelLaboral")]
        public string fechaInicioRelacionLaboral { get; set; }

        [XmlAttribute("Antigüedad")]
        public string antiguedad { get; set; }

        [XmlAttribute("TipoContrato")]
        public string tipoContrato { get; set; }

        [XmlAttribute("Sindicalizado")]
        public string sindicalizado { get; set; }

        [XmlAttribute("TipoJornada")]
        public string tipoJornada { get; set; }

        [XmlAttribute("TipoRegimen")]
        public string tipoRegimen { get; set; }

        [XmlAttribute("NumEmpleado")]
        public string numeroEmpleado { get; set; }

        [XmlAttribute("Departamento")]
        public string departamento { get; set; }

        [XmlAttribute("Puesto")]
        public string puesto { get; set; }

        [XmlAttribute("RiesgoPuesto")]
        public string riesgoPuesto { get; set; }

        [XmlAttribute("PeriodicidadPago")]
        public string periodicidadPago { get; set; }

        [XmlAttribute("Banco")]
        public string banco { get; set; }

        [XmlAttribute("CuentaBancaria")]
        public string cuentaBancaria { get; set; }

        [XmlAttribute("SalarioBaseCotApor")]
        public string salarioBaseCuotaAportacion { get; set; }

        [XmlAttribute("SalarioDiarioIntegrado")]
        public string salarioDiarioIntegrado { get; set; }

        [XmlAttribute("ClaveEntFed")]
        public string claveEntidadFederativa { get; set; }

        [XmlElement("Subcontratacion")]
        public Subcontratacion subcontratacion { get; set; }
    }
}
