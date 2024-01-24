using System.Xml.Serialization;
using System.Collections.Generic;

namespace HelvyTools.Prestashop.Api.Data.ProductElements
{
    [XmlRoot("link_rewrite")]
    public class LinkRewrite
    {
        [XmlElement("language")]
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}
