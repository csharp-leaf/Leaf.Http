using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Leaf.Http
{
    public static class HeaderExtensions
    {
        // Properties
        public static string Get<T>(this ICollection<T> headerValues, string separator = ",")
        {
            if (headerValues == null || headerValues.Count == 0)
                return null;

            return string.Join(separator, headerValues);
        }

        public static void Set<T>(this ICollection<T> header, string value)
        {
            if (header == null)
                return;

            // Empty string allowed
            if (value == null)
            {
                header.Clear();
                return;
            }

            if (header.Count > 0)
                header.Clear();

            switch (header) {
                case HttpHeaderValueCollection<StringWithQualityHeaderValue> sqHeader:
                    sqHeader.TryParseAdd(value);
                    break;
                case HttpHeaderValueCollection<ProductInfoHeaderValue> pHeader:
                    pHeader.TryParseAdd(value);
                    break;
            }
        }

        // Not properties headers
        public static string Get(this HttpHeaders headers, string name)
        {
            if (headers == null || string.IsNullOrEmpty(name))
                return null;

            headers.TryGetValues(name, out var values);
            return values?.FirstOrDefault();
        }

        public static void Set(this HttpHeaders headers, string name, string value)
        {
            if (headers == null || string.IsNullOrEmpty(name))
                return;

            // Remove if header exists
            headers.TryGetValues(name, out var values);

            var headerValue = values?.FirstOrDefault();
            if (headerValue != null)
                headers.Remove(name);

            // Empty string allowed
            if (value != null)
                headers.TryAddWithoutValidation(name, value);
        }

        public static void Set(this HttpHeaders headers, Dictionary<string, string> nameValues)
        {
            if (headers == null || nameValues == null)
                return;

            foreach (var nameValue in nameValues)
                Set(headers, nameValue.Key, nameValue.Value);
        }
    }
}