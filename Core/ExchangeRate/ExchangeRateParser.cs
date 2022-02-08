using AngleSharp.Html.Dom; 

namespace SiteParser.Core.ExchangeRate
{
    public class ExchangeRateParser : IParser<string>
    {
        public Task<string> ParseAsync(IHtmlDocument htmlDocument)
        {
            var items = htmlDocument.QuerySelectorAll("tr");
            string result = null;

            foreach (var item in items)
            {
                foreach(var th in item.ChildNodes)
                {
                    result += th.TextContent + "";
                }
                result += "\n";
            }

            return Task.Run(()=>result);
        }
    }
}
