namespace SiteParser.Core.Habr
{
    public class HabrSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://habr.com/ru";

        public string Prefix { get; set; } = "all/page{CurrentId}/";

        public int StartPoint { get; set; }

        public int EndPoint { get; set; }
    }
}