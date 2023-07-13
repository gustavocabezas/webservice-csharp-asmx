﻿using System.Xml.Serialization;

namespace webservicecsharpasmx.Models
{
    public class Authentication
    {

        [XmlElement("Token")]
        public string Token { get; set; } = string.Empty;

        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Username")]
        public string Username { get; set; } = string.Empty;

        [XmlElement("ProfileId")]
        public int ProfileId { get; set; }

        [XmlElement("StatusId")]
        public int StatusId { get; set; }
    }
}
