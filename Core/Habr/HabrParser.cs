using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser.Core.Habr
{
    internal class HabrParser : IParser<string[]>
    {
        public Task<string[]> ParseAsync(IHtmlDocument htmlDocument)
        {
            List<string> result = new List<string>();
            var items = htmlDocument.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("tm-article-snippet__title-link"));

            foreach (var item in items)
            {
                result.Add(item.TextContent);
            }

            return Task.Run(()=>result.ToArray());
        }
    }
}
