using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace FormulaOneApp.Rss.Helpers
{
    public static class RssHelper
    {
        private const string Imgpattern =
            @"<(?<Tag_Name>(a)|img)\b[^>]*?\b(?<URL_Type>(?(1)href|src))\s*=\s*(?:""(?<URL>(?:\\""|[^""])*)""|'(?<URL>(?:\\'|[^'])*)')";

        private const string Urlpattern = @"(www.+|http.+)([\s]|$)";

        private static readonly Dictionary<string, string[]> TimeZones = new Dictionary<string, string[]>
        {
            {"ACDT", new[] {"-1030", "Australian Central Daylight"}},
            {"ACST", new[] {"-0930", "Australian Central Standard"}},
            {"ADT", new[] {"+0300", "(US) Atlantic Daylight"}},
            {"AEDT", new[] {"-1100", "Australian East Daylight"}},
            {"AEST", new[] {"-1000", "Australian East Standard"}},
            {"AHDT", new[] {"+0900", ""}},
            {"AHST", new[] {"+1000", ""}},
            {"AST", new[] {"+0400", "(US) Atlantic Standard"}},
            {"AT", new[] {"+0200", "Azores"}},
            {"AWDT", new[] {"-0900", "Australian West Daylight"}},
            {"AWST", new[] {"-0800", "Australian West Standard"}},
            {"BAT", new[] {"-0300", "Bhagdad"}},
            {"BDST", new[] {"-0200", "British Double Summer"}},
            {"BET", new[] {"+1100", "Bering Standard"}},
            {"BST", new[] {"+0300", "Brazil Standard"}},
            {"BT", new[] {"-0300", "Baghdad"}},
            {"BZT2", new[] {"+0300", "Brazil Zone 2"}},
            {"CADT", new[] {"-1030", "Central Australian Daylight"}},
            {"CAST", new[] {"-0930", "Central Australian Standard"}},
            {"CAT", new[] {"+1000", "Central Alaska"}},
            {"CCT", new[] {"-0800", "China Coast"}},
            {"CDT", new[] {"+0500", "(US) Central Daylight"}},
            {"CED", new[] {"-0200", "Central European Daylight"}},
            {"CET", new[] {"-0100", "Central European"}},
            {"CST", new[] {"+0600", "(US) Central Standard"}},
            {"EAST", new[] {"-1000", "Eastern Australian Standard"}},
            {"EDT", new[] {"+0400", "(US) Eastern Daylight"}},
            {"EED", new[] {"-0300", "Eastern European Daylight"}},
            {"EET", new[] {"-0200", "Eastern Europe"}},
            {"EEST", new[] {"-0300", "Eastern Europe Summer"}},
            {"EST", new[] {"+0500", "(US) Eastern Standard"}},
            {"FST", new[] {"-0200", "French Summer"}},
            {"FWT", new[] {"-0100", "French Winter"}},
            {"GMT", new[] {"+0000", "Greenwich Mean"}},
            {"GST", new[] {"-1000", "Guam Standard"}},
            {"HDT", new[] {"+0900", "Hawaii Daylight"}},
            {"HST", new[] {"+1000", "Hawaii Standard"}},
            {"IDLE", new[] {"-1200", "Internation Date Line East"}},
            {"IDLW", new[] {"+1200", "Internation Date Line West"}},
            {"IST", new[] {"-0530", "Indian Standard"}},
            {"IT", new[] {"-0330", "Iran"}},
            {"JST", new[] {"-0900", "Japan Standard"}},
            {"JT", new[] {"-0700", "Java"}},
            {"MDT", new[] {"+0600", "(US) Mountain Daylight"}},
            {"MED", new[] {"-0200", "Middle European Daylight"}},
            {"MET", new[] {"-0100", "Middle European"}},
            {"MEST", new[] {"-0200", "Middle European Summer"}},
            {"MEWT", new[] {"-0100", "Middle European Winter"}},
            {"MST", new[] {"+0700", "(US) Mountain Standard"}},
            {"MT", new[] {"-0800", "Moluccas"}},
            {"NDT", new[] {"+0230", "Newfoundland Daylight"}},
            {"NFT", new[] {"+0330", "Newfoundland"}},
            {"NT", new[] {"+1100", "Nome"}},
            {"NST", new[] {"-0630", "North Sumatra"}},
            {"NZ", new[] {"-1100", "New Zealand "}},
            {"NZST", new[] {"-1200", "New Zealand Standard"}},
            {"NZDT", new[] {"-1300", "New Zealand Daylight"}},
            {"NZT", new[] {"-1200", "New Zealand"}},
            {"PDT", new[] {"+0700", "(US) Pacific Daylight"}},
            {"PST", new[] {"+0800", "(US) Pacific Standard"}},
            {"ROK", new[] {"-0900", "Republic of Korea"}},
            {"SAD", new[] {"-1000", "South Australia Daylight"}},
            {"SAST", new[] {"-0900", "South Australia Standard"}},
            {"SAT", new[] {"-0900", "South Australia Standard"}},
            {"SDT", new[] {"-1000", "South Australia Daylight"}},
            {"SST", new[] {"-0200", "Swedish Summer"}},
            {"SWT", new[] {"-0100", "Swedish Winter"}},
            {"USZ3", new[] {"-0400", "USSR Zone 3"}},
            {"USZ4", new[] {"-0500", "USSR Zone 4"}},
            {"USZ5", new[] {"-0600", "USSR Zone 5"}},
            {"USZ6", new[] {"-0700", "USSR Zone 6"}},
            {"UT", new[] {"+0000", "Universal Coordinated"}},
            {"UTC", new[] {"+0000", "Universal Coordinated"}},
            {"UZ10", new[] {"-1100", "USSR Zone 10"}},
            {"WAT", new[] {"+0100", "West Africa"}},
            {"WET", new[] {"+0000", "West European"}},
            {"WST", new[] {"-0800", "West Australian Standard"}},
            {"YDT", new[] {"+0800", "Yukon Daylight"}},
            {"YST", new[] {"+0900", "Yukon Standard"}},
            {"ZP4", new[] {"-0400", "USSR Zone 3"}},
            {"ZP5", new[] {"-0500", "USSR Zone 4"}},
            {"ZP6", new[] {"-0600", "USSR Zone 5"}}
        };

        /// <summary>
        ///     Get the specified element's value as datetime
        /// </summary>
        /// <param name="item"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static DateTime? GetSafeElementDate(this XElement item, string elementName)
        {
            return GetSafeElementDate(item, elementName, item.GetDefaultNamespace());
        }

        /// <summary>
        ///     Get the specified element's value as datetime
        /// </summary>
        /// <param name="item"></param>
        /// <param name="elementName"></param>
        /// <param name="xNamespace"></param>
        /// <returns></returns>
        public static DateTime? GetSafeElementDate(this XElement item, string elementName, XNamespace xNamespace)
        {
            DateTime date;
            XElement element = item.Element(xNamespace + elementName);
            if (element == null)
                return null;
            if (TryParseDateTime(element.Value, out date))
                return date;
            return null;
        }

        /// <summary>
        ///     Get the specified element's value as string
        /// </summary>
        /// <param name="item"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static string GetSafeElementString(this XElement item, string elementName)
        {
            if (item == null) return String.Empty;
            return GetSafeElementString(item, elementName, item.GetDefaultNamespace());
        }

        /// <summary>
        ///     Get the specified element's value as string
        /// </summary>
        /// <param name="item"></param>
        /// <param name="elementName"></param>
        /// <param name="xNamespace"></param>
        /// <returns></returns>
        public static string GetSafeElementString(this XElement item, string elementName, XNamespace xNamespace)
        {
            if (item == null) return String.Empty;
            XElement value = item.Element(xNamespace + elementName);
            if (value != null)
                return value.Value;
            return String.Empty;
        }

        /// <summary>
        ///     Get the link element's value as string
        /// </summary>
        /// <param name="item"></param>
        /// <param name="rel"></param>
        /// <returns></returns>
        public static string GetLink(this XElement item, string rel)
        {
            IEnumerable<XElement> links = item.Elements(item.GetDefaultNamespace() + "link");
            var xElements = links as XElement[] ?? links.ToArray();
            IEnumerable<string> link = from l in xElements
                let xAttribute = l.Attribute("rel")
                where xAttribute != null && xAttribute.Value == rel
                let attribute = l.Attribute("href")
                where attribute != null
                select attribute.Value;
            var linkData = link as string[] ?? link.ToArray();
            if (!linkData.Any() && xElements.Any())
            {
                var firstOrDefault = xElements.FirstOrDefault();
                if (firstOrDefault != null) return firstOrDefault.Attributes().First().Value;
            }

            return linkData.FirstOrDefault();
        }

        /// <summary>
        ///     Get the item's image
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetImage(this XElement item)
        {
            string feedDataImage = null;
            try
            {
                if (item == null) return String.Empty;

                feedDataImage = GetImageFromTag(item);
                if (string.IsNullOrEmpty(feedDataImage))
                {
                    feedDataImage = GetImageFromEnclosure(item);
                }
                if (string.IsNullOrEmpty(feedDataImage))
                {
                    feedDataImage = GetImagesInHtmlString(item.Value).FirstOrDefault();
                }
                if (string.IsNullOrEmpty(feedDataImage))
                {
                    feedDataImage = GetImageFromMedia(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return feedDataImage;
        }

        private static string GetImageFromTag(XElement item)
        {
            string image = string.Empty;

            XElement imageElement = item.Element(item.GetDefaultNamespace() + "image");
            if (imageElement != null)
            {
                if (imageElement.HasElements)
                {
                    XElement urlElement = imageElement.Element(item.GetDefaultNamespace() + "url");
                    if (urlElement != null)
                    {
                        image = urlElement.Value;
                    }
                }
                else
                {
                    image = imageElement.Value;
                }
            }

            return image;
        }

        private static string GetImageFromMedia(XElement item)
        {
            XNamespace media = "http://search.yahoo.com/mrss/";
            var content = item.Descendants(media + "content"); //this part doesn't work as expected
            var xElements = content as XElement[] ?? content.ToArray();
            if (xElements.Last() != null)
            {
                var xAttribute = xElements.Last().Attribute("url");
                return xAttribute != null ? xAttribute.Value : string.Empty;
            }
                
            return string.Empty;
        }

        // http://www.w3schools.com/rss/rss_tag_enclosure.asp
        private static string GetImageFromEnclosure(this XElement item)
        {
            string feedDataImage = null;
            try
            {
                XElement element = item.Element(item.GetDefaultNamespace() + "enclosure");
                if (element == null)
                    return null;

                XAttribute typeAttribute = element.Attribute("type");
                if (typeAttribute != null &&
                    !string.IsNullOrEmpty(typeAttribute.Value) &&
                    typeAttribute.Value.StartsWith("image"))
                {
                    XAttribute urlAttribute = element.Attribute("url");
                    feedDataImage = (urlAttribute != null && !string.IsNullOrEmpty(urlAttribute.Value))
                        ? urlAttribute.Value
                        : string.Empty;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return feedDataImage;
        }

        private static IEnumerable<string> GetImagesInHtmlString(string htmlString)
        {
            var images = new List<string>();
            const string pattern = Imgpattern;
            var rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(htmlString);

            for (int i = 0, l = matches.Count; i < l; i++)
            {
                if (matches[i].Value.Contains(".jpg") || matches[i].Value.Contains(".png"))
                {
                    MatchCollection ms = Regex.Matches(matches[i].Value, Urlpattern);
                    if (!string.IsNullOrEmpty(ms[0].Value))
                        images.Add(ms[0].Value.Replace("\"", string.Empty));
                }
            }

            return images;
        }


        private static bool TryParseDateTime(string datetime, out DateTime result)
        {
            try
            {
                result = DateTime.Parse(datetime,
                    DateTimeFormatInfo.InvariantInfo,
                    DateTimeStyles.AllowWhiteSpaces);

                return true;
            }
            catch (FormatException)
            {
                int tzIndex = datetime.LastIndexOf(" ", StringComparison.Ordinal);
                if (tzIndex >= 0)
                {
                    string tz = datetime.Substring(tzIndex, datetime.Length - tzIndex);
                    string offset = TimeZoneToOffset(tz);
                    if (offset != null)
                    {
                        string offsetDate = string.Format("{0} {1}", datetime.Substring(0, tzIndex), offset);
                        return TryParseDateTime(offsetDate, out result);
                    }
                }

                result = default(DateTime);
                return false;
            }
        }

        private static string TimeZoneToOffset(string tz)
        {
            if (tz == null)
                return null;

            tz = tz.ToUpper().Trim();
            if (TimeZones.ContainsKey(tz))
            {
                return TimeZones[tz][0];
            }

            return null;
        }
    }
}