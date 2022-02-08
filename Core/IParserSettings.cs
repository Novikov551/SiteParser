namespace SiteParser.Core
{
    public interface IParserSettings
    {
        public string BaseUrl { get; set; }

        public string Prefix { get; set; }

        public int StartPoint { get; set; }

        public int EndPoint { get; set; }   
    }
}