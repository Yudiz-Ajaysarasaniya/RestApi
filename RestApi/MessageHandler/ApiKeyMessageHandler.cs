
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace RestApi.MessageHandler
{
    public class ApiKeyMessageHandler : DelegatingHandler
    {
        private const string ApiKey = "alex123654@$backtobackwinner";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("method invoked");
            bool validKey = false;
            IEnumerable<string> requestHeader;
            var checkApiExist = request.Headers.TryGetValues("ApiKey", out requestHeader);

            if (checkApiExist)
            {
                if (requestHeader.FirstOrDefault().Equals(ApiKey))
                {
                    validKey = true;
                }
            }
            if (!validKey)
            {
               // return request.CreateResponse(StatusCodes.Status403Forbidden, "ApiKey Not Valid");
               return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
