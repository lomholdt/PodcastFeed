using System.Xml.Serialization;

namespace PodcastFeed.Api.Services
{
    public class Item
    {
        [XmlElement("guid")]
        public string Guid { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("pubDate")]
        public string PubDate { get; set; }
    }
}
