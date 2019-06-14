using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedLibrary
{
    /// <summary>
    /// http://hamidmosalla.com/2018/06/24/what-is-synchronizationcontext/
    /// https://devblogs.microsoft.com/pfxteam/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    public class RemoteHelper
    {
        readonly HttpClient httpClient;
        readonly BaseLog log;

        public RemoteHelper(BaseLog log)
        {
            httpClient = new HttpClient();
            this.log = log;
        }

        public HttpResponseMessage GetResponse()
        {
            var task = Task.Run(() => {
                log.Write("RemoteHelper.GetResponse.AnonymousFunction");
                return GetResponseAsync();
            });
            log.Write("RemoteHelper.GetResponse");
            var response = task.GetAwaiter().GetResult();
            log.Write("RemoteHelper.GetResponse");
            return response;
        }

        public HttpResponseMessage GetResponseDeadlock()
        {
            log.Write("RemoteHelper.GetResponseDeadlock");
            var response = GetResponseAsync().GetAwaiter().GetResult();
            log.Write("RemoteHelper.GetResponseDeadlock");
            return response;
        }

        public async Task<HttpResponseMessage> GetResponseAsync()
        {
            log.Write("RemoteHelper.GetResponseAsync");
            var resp = await httpClient.GetAsync("http://localhost:51265/api/Default");
            log.Write("RemoteHelper.GetResponseAsync");
            return resp;
        }
    }
}
