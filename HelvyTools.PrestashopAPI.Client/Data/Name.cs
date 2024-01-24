using System.Xml.Serialization;
using System.Collections.Generic;

namespace HelvyTools.Prestashop.Api.Data
{
    [XmlRoot("name")]
    public class Name
    {
        [XmlElement("language")]
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}
