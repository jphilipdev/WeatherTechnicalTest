using System.Collections.Generic;
using System.Xml.Serialization;

namespace WeatherTechnicalTest.Models
{
    [XmlRoot(ElementName = "Table", Namespace = "http://www.webserviceX.NET")]
    public class Table
    {
        [XmlElement(ElementName = "Country", Namespace = "http://www.webserviceX.NET")]
        public string Country { get; set; }
        [XmlElement(ElementName = "City", Namespace = "http://www.webserviceX.NET")]
        public string City { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet", Namespace = "http://www.webserviceX.NET")]
    public class NewDataSet
    {
        [XmlElement(ElementName = "Table", Namespace = "http://www.webserviceX.NET")]
        public List<Table> Table { get; set; }
    }

    [XmlRoot(ElementName = "string", Namespace = "http://www.webserviceX.NET")]
    public class String
    {
        [XmlElement(ElementName = "NewDataSet", Namespace = "http://www.webserviceX.NET")]
        public NewDataSet NewDataSet { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
