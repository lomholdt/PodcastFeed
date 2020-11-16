using System.Xml.Serialization;

namespace PodcastFeed.Api.Services
{
    public class Channel
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("link")] // Maybe Uri instead?
        public string Link { get; set; }

        [XmlElement("category")]
        public string Category { get; set; }

        [XmlElement("item")]
        public Item[] Items { get; set; }
    }
}
