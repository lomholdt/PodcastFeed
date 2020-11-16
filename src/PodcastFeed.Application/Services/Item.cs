using System;
using System.Xml.Serialization;

namespace PodcastFeed.Application.Services
{
    public class Item
    {
        [XmlElement("guid")]
        public string Guid { get; set; } = string.Empty;

        [XmlElement("title")]
        public string Title { get; set; } = string.Empty;

        [XmlElement("description")]
        public string Description { get; set; } = string.Empty;

        [XmlElement("pubDate")]
        public string PubDate { get; set; } = string.Empty;

        public DateTime? PublishedDate
        {
            get { return DateTime.Parse(PubDate); }
        }
    }
}
