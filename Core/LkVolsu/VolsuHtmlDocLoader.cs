namespace SiteParser.Core.LkVolsu
{
    internal class VolsuHtmlDocLoader : IHtmlDocLoader
    {
        private readonly HttpClient _httpClient;
        private readonly HttpContent _content;
        private string _url;

        public VolsuHtmlDocLoader(IParserSettings settings,HttpContent content)
        {
            _httpClient = new HttpClient();
            _url = $"{settings.BaseUrl}/{settings.Prefix}";
            _content = content;
        }

        public async Task<string> GetAsync(int pageId)
        {
            string sourse = null; 
            var currentUrl = _url.Replace("{CurrentId}", pageId.ToString());

            await _httpClient.PostAsync("https://lk.volsu.ru/user/sign-in/login", _content);
            var response = await _httpClient.GetAsync(currentUrl);
             
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                sourse = await response.Content.ReadAsStringAsync();
            }

            return sourse;
        }
    }
}
