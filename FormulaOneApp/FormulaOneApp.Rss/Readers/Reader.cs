namespace FormulaOneApp.Rss.Readers
{
    using System.Xml.Linq;
    using Helpers;
    using Models;

    internal class Reader : BaseRss
    {
        protected override RssItem ParseItem(XElement item)
        {
            var rssItem = new RssItem
            {
                Title = item.GetSafeElementString("title"),
                Link = item.GetSafeElementString("link"),
                PublishDate = item.GetSafeElementDate("pubDate"),
                Guid = item.GetSafeElementString("guid"),
                Image = item.GetImage()
            };

            string description = item.GetSafeElementString("description");
            rssItem.Description = !string.IsNullOrEmpty(description)
                ? description
                : item.GetSafeElementString("content");

            //Use the element's link as guid if necessary
            if (string.IsNullOrEmpty(rssItem.Guid))
                rssItem.Guid = rssItem.Link;

            return rssItem;
        }
    }
}