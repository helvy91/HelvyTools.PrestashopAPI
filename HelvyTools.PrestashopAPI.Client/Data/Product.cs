using System.Xml.Serialization;
using HelvyTools.Prestashop.Api.Attributes;
using HelvyTools.Prestashop.Api.Data.ProductElements;

namespace HelvyTools.Prestashop.Api.Data
{
	[XmlRoot("product")]
	[ApiResourceName("products")]
	public class Product : PrestashopResource
    {
		[XmlElement(ElementName = "id")]
		public int? Id { get; set; }

		[XmlElement(ElementName = "id_manufacturer")]
		public int IdManufacturer { get; set; }

		[XmlElement(ElementName = "id_category_default")]
		public int IdCategoryDefault { get; set; }

		[XmlElement(ElementName = "id_default_image")]
        public string IdDefaultImage { get; set; }

		[XmlIgnore]
        public int? IdDefaultImageValue
        {
			get => string.IsNullOrEmpty(IdDefaultImage) ? null : int.Parse(IdDefaultImage);
			set
            {
				IdDefaultImage = value.ToString();
            }
        }

        [XmlElement(ElementName = "id_tax_rules_group")]
		public int IdTaxRulesGroup { get; set; }

		[XmlElement("state")]
        public int State { get; set; }

		[XmlElement("minimal_quantity")]
        public int MinimalQuantity { get; set; }

		[XmlElement("low_stock_alert")]
        public int LowStockAlert { get; set; }

		[XmlElement("show_price")]
        public int ShowPrice { get; set; }

		[XmlElement("available_for_order")]
		public int AvailableForOrder { get; set; }

        [XmlElement(ElementName = "reference")]
		public string Reference { get; set; }

		[XmlElement(ElementName = "ean13")]
		public string Ean13 { get; set; }

		[XmlElement(ElementName = "price")]
		public decimal Price { get; set; }

		[XmlElement(ElementName = "active")]
		public int Active { get; set; }

		[XmlElement("additional_delivery_times")]
        public int AdditionalDeliveryTimes { get; set; }

        [XmlElement(ElementName = "name")]
		public Name Name { get; set; }

		[XmlElement(ElementName = "description")]
		public Description Description { get; set; }

		[XmlElement(ElementName = "description_short")]
		public DescriptionShort DescriptionShort { get; set; }

		[XmlElement("link_rewrite")]
        public LinkRewrite LinkRewrite { get; set; }

		[XmlElement("associations")]
        public Associations Associations { get; set; }
    }
}
