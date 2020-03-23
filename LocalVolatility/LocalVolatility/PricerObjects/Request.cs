using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ProjetVolSto.PricerObjects
{

    public struct IEXRequest
    {

        public string Ticker { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public HttpContent HttpContent { get; set; }
        public HttpResponseMessage Response { get; set; }
        public object Params { get; set; }
        public IEXRequest(string RequestTicker, string RequestType, string UrlRequest, HttpContent RequestContent = null)
        {
            if (RequestContent is null & RequestType == "POST")
            {
                throw new Exception(ConfigError.MissingHttpRequestContent);
            }
            Ticker = RequestTicker; Type = RequestType; Url = UrlRequest; HttpContent = RequestContent;
            Response = null;Params = null;
        }
    }


    public abstract class Request
    {

        public abstract void Get(HttpContent Request);
        public abstract void Post(HttpContent Request);
        public abstract void Get(IEXRequest Request);
        public abstract void Post(IEXRequest Request);
        public abstract void Get(object Request);
        public abstract void Post(object Request);
        public abstract Task<string> Get();
        public abstract Task<string> Post();



    }
}
