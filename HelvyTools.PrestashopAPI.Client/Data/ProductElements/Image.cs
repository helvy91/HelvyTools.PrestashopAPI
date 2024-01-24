using System.Xml.Serialization;

namespace HelvyTools.Prestashop.Api.Data.ProductElements
{
    [XmlRoot("image")]
    public class Image
    {
        [XmlElement("id")]
        public int Id { get; set; }
    }
}
