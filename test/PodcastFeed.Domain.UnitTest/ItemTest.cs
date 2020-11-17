using Xunit;
using PodcastFeed.Domain;
using System;

namespace PodcastFeed.Domain.UnitTest
{
    public abstract class ItemTest
    {
        public sealed class When_Creating_Instance : ItemTest
        {
            private readonly string _id = "SomeId";
            private readonly string _title = "SomeTitle";
            private readonly string _description = "SomeDescription";
            private readonly DateTime _publishedDate = new DateTime(1988, 09, 21);
            private readonly Item _sut;

            public When_Creating_Instance()
            {
                _sut = new Item
                {
                    Id = _id,
                    Title = _title,
                    Description = _description,
                    PublishedDate = _publishedDate,
                };
            }

            [Fact]
            public void It_sets_the_Id()
            {
                Assert.Equal(_id, _sut.Id);
            }

            [Fact]
            public void It_sets_the_Title()
            {
                Assert.Equal(_title, _sut.Title);
            }

            [Fact]
            public void It_sets_the_Description()
            {
                Assert.Equal(_description, _sut.Description);
            }

            [Fact]
            public void It_sets_the_published_date()
            {
                Assert.Equal(_publishedDate, _sut.PublishedDate);
            }
        }
    }
}
