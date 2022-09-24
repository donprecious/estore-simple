
using System.Net.Http.Headers;

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Services.Shared
{
    public static class HttpLogger
    {
        public static async Task LogRequest(ILogger logger, string requestId , HttpRequestMessage request)
        {
            var req = request;
            var id = requestId;
            var msg = $"[{id} -   Request]";

            var requestJson = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                MaxDepth = 10
            });
            logger.LogInformation($"{msg}========Start==========");
            logger.LogInformation($"{msg} {req.Method} {req.RequestUri.PathAndQuery} {req.RequestUri.Scheme}/{req.Version}");
            logger.LogInformation($"{msg} Host: {req.RequestUri.Scheme}://{req.RequestUri.Host}");
            logger.LogInformation($"{msg} Host: {req.RequestUri.Scheme}://{req.RequestUri.Host}");
            logger.LogInformation($"{msg} Request: {requestJson}");
    
            foreach (var header in req.Headers)
                logger.LogInformation($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

            if (req.Content != null)
            {
                foreach (var header in req.Content.Headers)
                    logger.LogInformation($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

                if (req.Content is StringContent || IsTextBasedContentType(req.Headers) ||
                   IsTextBasedContentType(req.Content.Headers))
                {
                    var result = await req.Content.ReadAsStringAsync();
                    logger.LogInformation($"{msg} Content:");
                    // logger.LogInformation($"{msg} {string.Join("", result.Cast<char>().Take(255))}...");
                    logger.LogInformation($"{msg} {result}...");
                }
            }
        }


     public   static async Task LogResponse(ILogger logger, string requestId , HttpResponseMessage response)
     {
         var id = requestId;
            var start = DateTime.UtcNow;
            var msg = $"[{id} -   Response]";
            var end = DateTime.UtcNow;

            logger.LogInformation($"{msg} Duration: {end - start}");
            logger.LogInformation($"{msg}==========End==========");

            msg = $"[{id} - Response]";
            logger.LogInformation($"{msg}=========Start=========");

            var resp = response;

            foreach (var header in resp.Headers)
                logger.LogInformation($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

            if (resp.Content != null)
            {
                foreach (var header in resp.Content.Headers)
                    logger.LogInformation($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

                if (resp.Content is StringContent || IsTextBasedContentType(resp.Headers) ||
                    IsTextBasedContentType(resp.Content.Headers))
                {
                    start = DateTime.UtcNow;
                    var result = await resp.Content.ReadAsStringAsync();
                    end = DateTime.UtcNow;
                    logger.LogInformation($"response data : {result}");
                    logger.LogInformation($"{msg} Content:");
                    // logger.LogInformation($"{msg} {string.Join("", result.Cast<char>().Take(255))}...");
                    logger.LogInformation($"{msg} {result}");
                    logger.LogInformation($"{msg} Duration: {end - start}");
                }
            }

            logger.LogInformation($"{msg}==========End==========");
           
        }
        
        static readonly string[] types = new[] {"html", "text", "xml", "json", "txt", "x-www-form-urlencoded"};

       static bool IsTextBasedContentType(HttpHeaders headers)
        {
            IEnumerable<string> values;
            if (!headers.TryGetValues("Content-Type", out values))
                return false;
            var header = string.Join(" ", values).ToLowerInvariant();

            return types.Any(t => header.Contains(t));
        } 
    }
}