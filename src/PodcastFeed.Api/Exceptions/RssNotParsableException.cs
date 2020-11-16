using System;

namespace PodcastFeed.Api.Exceptions
{
    [Serializable]
    public class RssNotParsableException : Exception
    {
        public RssNotParsableException() { }
        public RssNotParsableException(string message) : base(message) { }
        public RssNotParsableException(string message, System.Exception inner) : base(message, inner) { }
        protected RssNotParsableException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
