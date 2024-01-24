using System.Xml.Serialization;

namespace HelvyTools.Prestashop.Api.Data.ProductElements
{
    [XmlRoot("category")]
    public class Category
    {
        [XmlElement("id")]
        public int Id { get; set; }
    }
}
