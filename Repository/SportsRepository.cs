using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace webservicecsharpasmx.Repository
{
    public class SportsRepository
    {  
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        [XmlElement("team   ")]
        public int ProfileId { get; set; }

        [XmlElement("StatusId")]
        public int StatusId { get; set; }
    }
}