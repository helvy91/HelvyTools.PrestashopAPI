using System.Xml.Serialization;

namespace HelvyTools.Prestashop.Api.Data.ProductElements
{
    [XmlRoot("description_short")]
    public class DescriptionShort
    {
        [XmlElement("language")]
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}
