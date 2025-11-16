using System.Text;

namespace DesignPattern.DesignPattern.BuilderPattern
{
    public class EndpointBuilder
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        private readonly StringBuilder _stringBuilderParams = new StringBuilder();
        private const char defaultDelimiter = '/';

        public string BaseUrl { get; set; }

        public EndpointBuilder(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
        public EndpointBuilder Append(string value)
        {
            _stringBuilder.Append(value);
            _stringBuilder.Append(defaultDelimiter);
            return this;
        }

        public EndpointBuilder AppendParam(string name, string value)
        {
            _stringBuilderParams.AppendFormat("{0}={1}&", name, value);
            return this;
        }

        public string Build()
        {
            if (BaseUrl.EndsWith(defaultDelimiter))
            {
                _stringBuilder.Insert(0, BaseUrl);
            }
            else
            {
                _stringBuilder.Insert(0, BaseUrl + defaultDelimiter);
            }
            var url = _stringBuilder.ToString().TrimEnd('&');

            if (_stringBuilderParams.Length > 0)
            {
                string qParams = _stringBuilderParams.ToString().TrimEnd('&');
                url = _stringBuilder.ToString().TrimEnd(defaultDelimiter).TrimEnd('?');
                url = $"{url}?{qParams}";
            }
            return url.TrimEnd(defaultDelimiter);
        }
    }

}