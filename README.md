# PodcastFeed

## Notes and Improvements

- Exposing full namespace in errors is probably not cool
- Limit query is not using the RSS feeds limit query param. That means we will fetch the full RSS data set every time and then filter it in memory afterwards. This was a concious decision since limiting the data and then applying a publishedDate filter would give weird results if used together.
- Use Options pattern for configuration so base path to RSS feed is not hardcoded
- Manually modelling the Xml is cumbersome, instead use `Microsoft.Toolkit.Parsers.Rss` to do the heavy lifting for us. The current solution mimmicks the XML structure with one title (and other properties) and several sub items, where the parser mentioned above will output an array of items with the title (and the rest of the fields) merged into each item.
