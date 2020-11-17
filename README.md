# PodcastFeed

## Notes and Improvements

- Lookup by name is based on the RSS feeds name and not an internal database maintaing a list of available podcasts. I believe this would be a business decision if this was good enough or a smarter option would be prefered.
- Exposing full namespace in errors is probably not cool
- Limit query is not using the RSS feeds limit query param. That means we will fetch the full RSS data set every time and then filter it in memory afterwards. This was a concious decision since limiting the data and then applying a publishedDate filter would give weird results if used together.
- Use Options pattern for configuration so base path to RSS feed is not hardcoded
- Manually modelling the Xml is cumbersome, instead use `Microsoft.Toolkit.Parsers.Rss` to do the heavy lifting for us. The current solution mimmicks the XML structure with one title (and other properties) and several sub items, where the parser mentioned above will output an array of items with the title (and the rest of the fields) merged into each item.
- I do _not_ have full coverage. I have only implemented an example of some unit tests.
- No integration tests
