using System.Xml.Serialization;

namespace HelvyTools.Prestashop.Api.Data.ProductElements
{
    [XmlRoot("description")]
    public class Description
    {
        [XmlElement("language")]
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}
