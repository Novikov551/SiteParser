using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser.Core.ExchangeRate
{
    public class ExchangeRateSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://kurs.com.ru";

        public string Prefix { get; set; } = "?source=google_ads_RU_2019-toch-kurs-valyut";

        public int StartPoint { get; set; } = 0;

        public int EndPoint { get; set; } = 0;
    }
}
