using AngleSharp.Html.Dom; 

namespace SiteParser.Core
{
    internal interface IParser<T> where T : class
    {
        Task<T> ParseAsync(IHtmlDocument htmlDocument);
    }
}
