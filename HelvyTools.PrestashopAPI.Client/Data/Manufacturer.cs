using System.Xml.Serialization;
using HelvyTools.Prestashop.Api.Attributes;

namespace HelvyTools.Prestashop.Api.Data
{
    [ApiResourceName("manufacturers")]
	[XmlRoot(ElementName = "manufacturer")]
	public class Manufacturer : PrestashopResource
    {
		[XmlElement(ElementName = "id")]
		public int? Id { get; set; }

		[XmlElement(ElementName = "active")]
		public int Active { get; set; }

		[XmlElement(ElementName = "name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "meta_title")]
        public MetaTitle MetaTitle { get; set; }
    }
}
