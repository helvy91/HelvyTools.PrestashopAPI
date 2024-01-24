using System.Xml.Serialization;
using HelvyTools.Prestashop.Api.Attributes;

namespace HelvyTools.Prestashop.Api.Data
{
    [XmlRoot("image")]
    [ApiResourceName("images")]
    public class Image : PrestashopResource
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("id_product")]
        public int ProductId { get; set; }
    }
}
