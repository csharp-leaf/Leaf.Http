using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Leaf.Http
{
    public class HttpAgent : HttpClient
    {
        public readonly HttpMessageHandler Handler;

        #region Initialization
        
        public HttpAgent()
        {
            InitDefaults();
        }

        public HttpAgent(HttpMessageHandler httpMessageHandler) : base(httpMessageHandler)
        {
            Handler = httpMessageHandler;
            InitDefaults();
        }

        public HttpAgent(HttpMessageHandler httpMessageHandler, bool disposeHandler) : base(httpMessageHandler,
            disposeHandler)
        {
            Handler = httpMessageHandler;
            InitDefaults();
        }

        protected void InitDefaults()
        {
            DefaultRequestHeaders.ExpectContinue = false;
        }

        #endregion


        #region Headers

        // Нуждается в доработке, управляется handler'ом
        /*
        public string AcceptEncoding
        {
            get => DefaultRequestHeaders.AcceptEncoding.AsString();
            set => DefaultRequestHeaders.AcceptEncoding.SetAsString(value);
        }*/

        // Если использовать свойство AcceptLanguage значение будет не полным
        private const string AcceptLanguageHeader = "Accept-Language";
        public string AcceptLanguage
        {
            get => DefaultRequestHeaders.AcceptLanguage.AsString();
            set => DefaultRequestHeaders.AcceptLanguage.SetAsString(value);
        }
        

        private const string OriginHeader = "Origin";
        public string Origin
        {
            get => DefaultRequestHeaders.Get(OriginHeader);
            set => DefaultRequestHeaders.Set(OriginHeader, value);
        }

        public string Referer
        {
            get => DefaultRequestHeaders.Referrer?.ToString();
            set {
                if (value == null)
                {
                    DefaultRequestHeaders.Referrer = null;
                    return;
                }

                DefaultRequestHeaders.Referrer = !string.IsNullOrEmpty(value) ? new Uri(value) : null;
            }
        }

        public string UserAgent
        {
            get => DefaultRequestHeaders.UserAgent.AsString();
            set => DefaultRequestHeaders.UserAgent.SetAsString(value);
        }

        #endregion
    }
}
