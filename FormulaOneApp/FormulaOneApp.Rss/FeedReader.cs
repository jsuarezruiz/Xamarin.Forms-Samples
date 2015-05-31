namespace FormulaOneApp.Rss
{
    using System;
    using System.Xml.Linq;
    using Exceptions;
    using Models;
    using Readers;

    public static class FeedReader
    {
        /// <summary>
        ///     Parse the xml string into a RssFeed object
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static RssFeed LoadFeed(string xml)
        {
            XDocument doc;
            try
            {
                doc = XDocument.Parse(xml);
            }
            catch (Exception ex)
            {
                throw new NotSupportedFeedException("Not Supported", ex);
            }

            RssType type = BaseReader.GetFeedType(doc);

            BaseReader reader;
            switch (type)
            {
                case RssType.Atom:
                    reader = new AtomReader();
                    break;
                case RssType.Rdf:
                    reader = new RDFReader();
                    break;
                default:
                    reader = new Reader();
                    break;
            }
            return reader.LoadFeed(doc);
        }
    }
}