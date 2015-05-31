namespace FormulaOneApp.Rss.Readers
{
    using System.Xml.Linq;
    using Helpers;
    using Models;

    internal class RDFReader : BaseRss
    {
        private readonly XNamespace _nsRdfElementsNamespaceUri = "http://purl.org/dc/elements/1.1/";

        protected override RssItem ParseItem(XElement item)
        {
            var rssItem = new RssItem
            {
                Title = item.GetSafeElementString("title"),
                Link = item.GetSafeElementString("link"),
                Image = item.GetImage()
            };


            string description = item.GetSafeElementString("description");
            rssItem.Description = !string.IsNullOrEmpty(description)
                ? description
                : item.GetSafeElementString("content");

            rssItem.PublishDate = item.GetSafeElementDate("date", _nsRdfElementsNamespaceUri);
            rssItem.Guid = item.GetSafeElementString("identifier", _nsRdfElementsNamespaceUri);

            //Use the element's link as guid if necessary
            if (string.IsNullOrEmpty(rssItem.Guid))
                rssItem.Guid = rssItem.Link;

            return rssItem;
        }
    }
}