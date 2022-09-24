
using Microsoft.Extensions.Logging;

namespace Services.Shared
{

    public class HttpLoggingHandler : DelegatingHandler
    {
        private ILogger _logger;
        public HttpLoggingHandler(ILogger logger, HttpMessageHandler innerHandler = null)
            : base(innerHandler ?? new HttpClientHandler())
        {
            _logger = logger;
        }

        async protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var req = request;
            var id = Guid.NewGuid().ToString();

            await HttpLogger.LogRequest(_logger, id, request); 

            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            await HttpLogger.LogResponse(_logger, id, response);
            return response;
        }

    }
}
    
