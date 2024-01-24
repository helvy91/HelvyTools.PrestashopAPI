using System.Xml.Serialization;

namespace HelvyTools.Prestashop.Api.Data.ProductElements
{
    [XmlRoot("associations")]
    public class Associations
    {
        [XmlElement("categories")]
        public Categories Categories { get; set; }

        [XmlElement("images")]
        public Images Images { get; set; }
    }
}
