using System.Collections.Generic;
using System.Xml.Serialization;

namespace HelvyTools.Prestashop.Api.Data.ProductElements
{
    [XmlRoot("categories")]
    public class Categories
    {
        [XmlElement("category")]
        public List<Category> CategoryList { get; set; } = new List<Category>();
    }
}
