namespace SiteParser.Core.LkVolsu
{
    internal class VolsuSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://lk.volsu.ru";

        public string Prefix { get; set; } = "student/grade?id={CurrentId}";
        public int StartPoint { get ; set ; }
        public int EndPoint { get ; set ; }
    }
}
