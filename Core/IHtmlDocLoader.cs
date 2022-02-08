namespace SiteParser.Core
{
    internal interface IHtmlDocLoader
    {
        Task<string> GetAsync(int id);
    }
}