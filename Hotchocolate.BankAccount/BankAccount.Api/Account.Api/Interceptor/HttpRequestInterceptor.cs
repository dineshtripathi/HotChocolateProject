using HotChocolate.AspNetCore;
using HotChocolate.Execution;

namespace Account.Api.Interceptor
{
   public class HttpRequestInterceptor : DefaultHttpRequestInterceptor
    {
        public override ValueTask OnCreateAsync(HttpContext context, IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder, CancellationToken cancellationToken)
        {
            return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
        }
    }

}
