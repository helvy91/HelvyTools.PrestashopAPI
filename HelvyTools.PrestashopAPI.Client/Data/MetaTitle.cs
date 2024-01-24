using System.Collections.Generic;
using System.Xml.Serialization;

namespace HelvyTools.Prestashop.Api.Data
{
    [XmlRoot("meta_title")]
    public class MetaTitle
    {
        [XmlElement("language")]
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}
