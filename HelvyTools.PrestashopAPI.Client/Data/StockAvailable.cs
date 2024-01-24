using System.Xml.Serialization;
using HelvyTools.Prestashop.Api.Attributes;

namespace HelvyTools.Prestashop.Api.Data
{
    [XmlRoot("stock_available")]
    [ApiResourceName("stock_availables")]
    public class StockAvailable : PrestashopResource
    {
        [XmlElement(ElementName = "id_product")]
        public int ProductId { get; set; }

        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }
    }
}
