using System.Xml.Serialization;

namespace PodcastFeed.Api.Services
{
    [XmlRoot("rss")]
    public class Rss
    {
        [XmlElement("channel")]
        public Channel Channel { get; set; }
    }
}
