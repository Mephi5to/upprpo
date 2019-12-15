using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Birds.API.Controllers
{
    [Route("api/v1")]
    public sealed class DocumentationController : ControllerBase
    {
        private static readonly AsyncLock Locker = new AsyncLock();
        private static byte[] v1SchemeContent;
        private static byte[] htmlDocContent;

        [HttpGet]
        [Route("swagger.json")]
        public async Task<HttpResponseMessage> GetV1SchemeAsync()
        {
            if (v1SchemeContent == null)
            {
                await InitV1SchemeContentAsync().ConfigureAwait(false);
            }

            var response = CreateContentResponse(v1SchemeContent, "application/json");
            return response;
        }

        [HttpGet]
        [Route("doc.html")]
        public async Task<HttpResponseMessage> GetHtmlDoc()
        {
            if (htmlDocContent == null)
            {
                await InitHtmlDocContentAsync().ConfigureAwait(false);
            }

            var response = CreateContentResponse(htmlDocContent, "text/html");
            return response;
        }

        private static async Task InitV1SchemeContentAsync()
        {
            using (await Locker.LockAsync().ConfigureAwait(false))
            {
                if (v1SchemeContent != null)
                {
                    return;
                }

                v1SchemeContent = await GetManifestResourceAsync("Birds.API.docs.birds-api-v1.json").ConfigureAwait(false);
            }
        }

        private static async Task InitHtmlDocContentAsync()
        {
            using (await Locker.LockAsync().ConfigureAwait(false))
            {
                if (htmlDocContent != null)
                {
                    return;
                }

                htmlDocContent = await GetManifestResourceAsync("Birds.API.docs.birds-api-v1.html").ConfigureAwait(false);
            }
        }

        private static async Task<byte[]> GetManifestResourceAsync(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            byte[] result;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                var contentLength = (int)stream.Length;
                result = new byte[contentLength];
                var offset = 0;

                while (offset < contentLength)
                {
                    offset += await stream.ReadAsync(result, offset, contentLength - offset).ConfigureAwait(false);
                }
            }

            return result;
        }

        private static HttpResponseMessage CreateContentResponse(byte[] content, string contentType)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ByteArrayContent(content),
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            response.Content.Headers.ContentLength = content.Length;

            return response;
        }
    }
}
