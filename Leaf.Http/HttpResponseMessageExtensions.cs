using System.Net.Http;

namespace Leaf.Http
{
    public static class HttpResponseMessageExtensions
    {
        public static string ToStringSync(this HttpResponseMessage self, bool disposeAfter = true)
        {
            var task = self.Content.ReadAsStringAsync();
            task.ConfigureAwait(false);

            var result = task.Result;

            if (disposeAfter)
                self.Dispose();

            return result;
        }
    }
}