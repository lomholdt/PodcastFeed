using System.Xml.Serialization;

namespace PodcastFeed.Application.Services
{
    [XmlRoot("rss")]
    public class Rss
    {
        [XmlElement("channel")]
        public Channel Channel { get; set; } = new Channel {};
    }
}
