using System;
using System.Xml.Serialization;

namespace PodcastFeed.Application.Services
{
    public class Channel
    {
        [XmlElement("title")]
        public string Title { get; set; } = string.Empty;

        [XmlElement("description")]
        public string Description { get; set; } = string.Empty;

        [XmlElement("link")]
        public string Link { get; set; } = string.Empty;

        [XmlElement("category")]
        public string[] Category { get; set; } = Array.Empty<string>();

        [XmlElement("item")]
        public Item[] Items { get; set; } = Array.Empty<Item>();
    }
}
