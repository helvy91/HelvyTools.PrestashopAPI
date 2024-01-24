using System.Xml.Serialization;
using System.Collections.Generic;

namespace HelvyTools.Prestashop.Api.Data.ProductElements
{
    [XmlRoot("images")]
    public class Images
    {
        [XmlElement("image")]
        public List<Image> ImageList { get; set; } = new List<Image>();
    }
}
