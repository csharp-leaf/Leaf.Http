using Xunit;

namespace Leaf.Http.Tests
{
    public class HttpAgentHeadersTest
    {
        // Нуждается в доработке, управляется handler'ом
        /*
        [Fact]
        public void AcceptEncodingTest()
        {
            var http = new HttpAgent();
            Assert.Null(http.AcceptEncoding);

            const string testAcceptEncoding = "gzip, deflate, br";
            http.AcceptEncoding = testAcceptEncoding;
            Assert.Equal(testAcceptEncoding, http.AcceptEncoding);

            http.AcceptEncoding = null;
            Assert.Null(http.AcceptEncoding);

            // Empty AcceptEncoding is also useless, so header will be removed
            http.AcceptEncoding = "";
            Assert.Null(http.AcceptEncoding);
        }
        */
        
        [Fact]
        public void AcceptLanguageTest()
        {
            var http = new HttpAgent();
            Assert.Null(http.AcceptLanguage);

            const string testAcceptLanguage = "ru-RU,ru; q=0.9,en-US; q=0.8,en; q=0.7";
            http.AcceptLanguage = testAcceptLanguage;
            Assert.Equal(testAcceptLanguage, http.AcceptLanguage);

            http.AcceptLanguage = null;
            Assert.Null(http.AcceptLanguage);

            // Empty AcceptLanguage is also useless, so header will be removed
            http.AcceptLanguage = "";
            Assert.Null(http.AcceptLanguage);
        }

        [Fact]
        public void OriginTest()
        {
            var http = new HttpAgent();
            Assert.Null(http.Origin);

            const string testOrigin = "https://google.com/";
            http.Origin = testOrigin;
            Assert.Equal(testOrigin, http.Origin);

            http.Origin = null;
            Assert.Null(http.Origin);

            // Empty Origin allowed
            http.Origin = "";
            Assert.Equal(string.Empty, http.Origin);
        }
       
        [Fact]
        public void RefererTest()
        {
            var http = new HttpAgent();
            Assert.Null(http.Referer);

            const string testReferer = "https://google.com/";
            http.Referer = testReferer;
            Assert.Equal(testReferer, http.Referer);

            http.Referer = null;
            Assert.Null(http.Referer);

            // Empty Referer is also useless, so header will be removed
            http.Referer = "";
            Assert.Null(http.Referer);
        }

        [Fact]
        public void UserAgentTest()
        {
            var http = new HttpAgent();
            Assert.Null(http.UserAgent);

            const string testUserAgent = "Chrome";
            http.UserAgent = testUserAgent;
            Assert.Equal(testUserAgent, http.UserAgent);

            http.UserAgent = null;
            Assert.Null(http.UserAgent);

            // Empty UserAgent is also useless, so header will be removed
            http.UserAgent = "";
            Assert.Null(http.UserAgent);
        }

    }
}
