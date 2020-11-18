using PodcastFeed.Api.Exceptions;
using PodcastFeed.Api.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PodcastFeed.Api.UnitTest.Services
{
    public abstract class RssServiceTest
    {
        private readonly MockHttpMessageHandlerBuilder _mockHandlerBuilder = new MockHttpMessageHandlerBuilder();

        public sealed class When_creating_instance
        {
            [Fact]
            public void It_throws_if_client_is_null()
            {
                Assert.Throws<ArgumentNullException>(() => new RssService(default));
            }
        }

        public sealed class When_getting_channel : RssServiceTest
        {
            private readonly string _baseAddress = "http://localhost";

            private readonly string _name = "SomeFeedName";

            private readonly string _rss = "<?xml version=\"1.0\" encoding=\"utf-8\"?><rss xmlns:a10=\"http://www.w3.org/2005/Atom\" version=\"2.0\"><channel><title>SomeTitle</title><item></item></channel></rss>";

            private readonly string _invalidRss = "InvalidFeed";

            [Fact]
            public async Task It_calls_the_endpoint()
            {
                var called = false;

                var uri = GetUri(_name);

                var handler = _mockHandlerBuilder
                    .When(uri)
                    .Return(HttpStatusCode.OK, _rss)
                    .WhenCalled(_ => called = true)
                    .Build();

                var client = new HttpClient(handler) { BaseAddress = new Uri(_baseAddress) };

                var sut = new RssService(client);

                await sut.GetChannel(_name);

                Assert.True(called);
            }

            [Fact]
            public async Task It_throws_rss_not_parsable_exception_when_rss_is_invalid()
            {
                var uri = GetUri(_name);

                var handler = _mockHandlerBuilder
                    .When(uri)
                    .Return(HttpStatusCode.OK, _invalidRss)
                    .Build();

                var client = new HttpClient(handler) { BaseAddress = new Uri(_baseAddress) };

                var sut = new RssService(client);

                await Assert.ThrowsAsync<RssNotParsableException>(() => sut.GetChannel(_name));
            }

            private string GetUri(string name) => $"{_baseAddress}/mu/feed/{name}";
        }

        private class MockHttpMessageHandlerBuilder
        {
            private HttpStatusCode _statusCode;

            private string _body = string.Empty;

            private Action<HttpRequestMessage> _whenCalled;

            private string _uri = string.Empty;

            public MockHttpMessageHandlerBuilder When(string uri)
            {
                _uri = uri;
                return this;
            }

            public MockHttpMessageHandlerBuilder Return(HttpStatusCode statusCode, string body = "")
            {
                _statusCode = statusCode;
                _body = body;
                return this;
            }

            public MockHttpMessageHandlerBuilder WhenCalled(Action<HttpRequestMessage> action)
            {
                _whenCalled = action;
                return this;
            }

            public HttpMessageHandler Build() => new MockHttpMessageHandler(_uri, _statusCode, _body, _whenCalled);

            private class MockHttpMessageHandler : HttpMessageHandler
            {
                private readonly HttpResponseMessage _response;

                private readonly string _uri;

                private readonly Action<HttpRequestMessage> _whenCalled;

                public MockHttpMessageHandler(string uri, HttpStatusCode statusCode, string content, Action<HttpRequestMessage> whenCalled)
                {
                    _response = new HttpResponseMessage
                    {
                        StatusCode = statusCode,
                        Content = new StringContent(content),
                    };

                    _uri = uri;

                    _whenCalled = whenCalled;
                }

                protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                {
                    if (request.RequestUri == new Uri(_uri))
                    {
                        _whenCalled?.Invoke(request);
                        return Task.FromResult(_response);
                    }
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
                }
            }
        }
    }
}
