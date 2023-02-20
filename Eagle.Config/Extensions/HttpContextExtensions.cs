using Eagle.Core.Helpers;
using Microsoft.AspNetCore.Http;

namespace Eagle.Config.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetHeader(this HttpContext httpContext, string headerName)
            => GetHeaderData(httpContext, headerName);
        
        public static T? GetHeader<T>(this HttpContext httpContext, string headerName)
        {
            return JsonSerializerHelper.Deserialize<T>(GetHeaderData(httpContext, headerName));
        }


        private static string GetHeaderData(HttpContext httpContext, string headerName)
        {
            string headerData = httpContext.Request.Headers[headerName];
            return headerData;
        }
    }
}
