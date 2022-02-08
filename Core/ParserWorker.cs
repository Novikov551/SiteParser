using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser.Core
{
    internal class ParserWorker<T> where T : class
    {
        private IParser<T> _parser;
        private IParserSettings _settings;
        private IHtmlDocLoader _loader;
        private bool _isActive;

        public event Action<object, T> OnUpdatedData;
        public event Action<object> OnCompleted;

        public IParser<T> Parser
        {
            get { return _parser; }
            set { _parser = value; }
        }

        public IParserSettings Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        public ParserWorker(IParser<T> parser)
        {
            Parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings settings) : this(parser)
        {
            Settings = settings;
            _loader=new HtmlDocLoader(settings);
        }

        public ParserWorker(IParser<T> parser, IParserSettings settings,IHtmlDocLoader docLoader) : this(parser,settings)
        {
            _loader = docLoader;
        }

        public void Start()
        {
            _isActive = true;
            Work();
        }

        public void Stop()
        {
            _isActive = false;
        }

        public async Task Work()
        {
            for (int i = Settings.StartPoint; i <= Settings.EndPoint; i++)
            {
                if (!_isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }

                var str = await _loader.GetAsync(i);
                var parser = new HtmlParser();
                var doc = await parser.ParseDocumentAsync(str);
                var result = await Parser.ParseAsync(doc);
                OnUpdatedData?.Invoke(this, result);
            }

            OnCompleted?.Invoke(this);
            _isActive = false;
        }
    }
}
