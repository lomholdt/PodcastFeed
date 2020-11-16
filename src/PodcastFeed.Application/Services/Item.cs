using System;
using System.Xml.Serialization;

namespace PodcastFeed.Application.Services
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

        public DateTime? PublishedDate
        {
            get { return DateTime.Parse(PubDate); }
        }
    }
}
