namespace FormulaOneApp.Rss.Readers
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Exceptions;
    using Models;

    /// <summary>
    /// </summary>
    internal abstract class BaseReader
    {
        private static readonly XNamespace NsMedia = "http://search.yahoo.com/mrss/";
        private static readonly XNamespace NsItunes = "http://www.itunes.com/dtds/podcast-1.0.dtd";
        private static readonly XNamespace NsRdfNamespaceUri = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";

        /// <summary>
        ///     Return the RssType based on the XDocument passed
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static RssType GetFeedType(XDocument doc)
        {
            if (doc.Root == null) throw new NotSupportedFeedException("Not Supported");

            RssType result;
            XNamespace defaultNamespace = doc.Root.GetDefaultNamespace();

            if (defaultNamespace.NamespaceName.EndsWith("Atom"))
            {
                result = RssType.Atom;
            }
            else if (doc.Root.Name == (NsRdfNamespaceUri + "RDF"))
            {
                result = RssType.Rdf;
            }
            else
            {
                result = RssType.Rss;
            }

            return result;
        }

        /// <summary>
        ///     Set the feed's image with the image extracted from the XDocument
        /// </summary>
        /// <param name="feed"></param>
        /// <param name="doc"></param>
        public void SetMediaImage(RssFeed feed, XDocument doc)
        {
            if (doc.Root != null)
            {
                XElement image = doc.Root.Descendants(NsItunes + "image").FirstOrDefault();
                if (image != null)
                {
                    XAttribute xAttribute = image.Attribute("href");
                    if (xAttribute != null) feed.ImageUri = new Uri(xAttribute.Value);
                    return;
                }
            }

            XElement thumbnail = doc.Element(NsMedia + "thumbnail");
            if (thumbnail != null)
            {
                feed.ImageUri = new Uri(thumbnail.Value);
                return;
            }

            feed.ImageUri = new Uri("/Images/DefaultFeedIcon.jpg", UriKind.Relative);
        }

        /// <summary>
        ///     Return a RssFeed object using the XDocument data
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public abstract RssFeed LoadFeed(XDocument doc);
    }
}