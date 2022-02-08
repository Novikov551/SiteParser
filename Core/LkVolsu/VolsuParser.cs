using AngleSharp.Html.Dom;

namespace SiteParser.Core.LkVolsu
{
    internal class VolsuParser : IParser<string[]>
    {
        public Task<string[]> ParseAsync(IHtmlDocument document)
        {
            var ratingList = new List<string>();
            var tabs = document.QuerySelectorAll("div")
                .Where(item => item.Id != null && item.ClassName.Contains("tab-pane fade"));

            foreach (var tab in tabs)
            {
                var str = "";
                var tabBody = tab.QuerySelector("tbody");
                var subjects = tabBody.QuerySelectorAll("tr");

                foreach (var subject in subjects)
                {
                    var score = 0;
                    var points = subject.QuerySelectorAll("td");
                    var data = "";
                    for (int i = 0; i < points.Length; i++)
                    {
                        if (i == 0)
                        {
                            data += points[i].TextContent + ")";
                        }

                        if (i == 1)
                        {
                            data += points[i].TextContent + " ";
                        }

                        if (i == 2)
                        {
                            data += "(" + points[i].TextContent + ") ";
                        }

                        if (i >= 3 && i <= 5)
                        {
                            try
                            {
                                score += Convert.ToInt32(points[i].TextContent);
                            }
                            catch
                            {
                                continue;
                            }
                        }

                        if(i>5)
                        {
                            break;
                        }
                    }

                    data += $": {score}\n";
                    str += data; 
                }

                ratingList.Add(str);
            }

            return Task.Run(() => ratingList.ToArray());
        }
    }
}
