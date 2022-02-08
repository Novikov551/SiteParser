namespace SiteParser.Core
{
    public class HtmlDocLoader : IHtmlDocLoader
    {
        private readonly HttpClient _httpClient;
        private string _url;

        public HtmlDocLoader(IParserSettings settings)
        {
            _httpClient = new HttpClient();
            _url = $"{settings.BaseUrl}/{settings.Prefix}";
        }

        public async Task<string> GetAsync(int pageId)
        {
            var currentUrl = _url.Replace("{CurrentId}", pageId.ToString());
            var response = await _httpClient.GetAsync(currentUrl);
            string sourse = null;

            if(response!=null && response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                sourse = await response.Content.ReadAsStringAsync(); 
            }

            return sourse;
        }
    }
}
