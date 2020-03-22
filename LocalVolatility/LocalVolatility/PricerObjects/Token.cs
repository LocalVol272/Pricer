﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ProjetVolSto.PricerObjects;

namespace ProjetVolSto.Struct
{
    public struct Token 
    { 
        public string value;

        public Token(string _value) => value = _value;

    }
    

    public struct IEXRequest
    {
      
        public string Ticker { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public HttpContent HttpContent { get; set; }
        public HttpResponseMessage Response { get; set; }
        public IEXRequest(string RequestTicker, string RequestType, string UrlRequest, HttpContent RequestContent = null)
        {
            if (RequestContent is null & RequestType=="POST")
            {
                throw new Exception(ConfigError.MissingHttpRequestContent);
            }
            Ticker = RequestTicker; Type = RequestType; Url= UrlRequest; HttpContent = RequestContent;
            Response = null;
        }
    }



}

