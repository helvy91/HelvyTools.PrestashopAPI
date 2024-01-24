using System.Xml.Serialization;

namespace HelvyTools.Prestashop.Api.Data
{
    [XmlRoot("language")]
    public class Language
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
