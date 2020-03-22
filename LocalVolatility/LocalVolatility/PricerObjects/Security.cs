
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetVolSto.PricerObjects;
using ProjetVolSto.Struct;

namespace ProjetVolSto.PricerObjects
{
    class ApiRequest : IEXCloudRequest,IAuthentification
    {
        protected Token token;
        private IEXRequest request;
        private Dictionary<string, string> config;
        Token IEXCloudRequest.Token { get => this.token; set => this.token = value; }
        Token IAuthentification.Token { get => this.token; set => this.token =value; }
        public IEXRequest RequestContent { get => request; set => request = value; }

        public ApiRequest(Dictionary<string, string> config)
        {
            this.config = config;
            this.token = this.GetToken(config);
            
        }

        public async void Post(IEXRequest Request) 
        {
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage message = await client.PostAsync(Request.Url, Request.HttpContent);
            }
            catch(Exception _exception)
            {
                Console.WriteLine(_exception);
            }
            
        }

        public async void Get(IEXRequest Request)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage message = await client.GetAsync(Request.Url);
            }
            catch(Exception _exception)
            {
                Console.WriteLine(_exception);
            }
        }
    

        public bool Authentification(Token token)
        {
            throw new NotImplementedException();
        }


        public Token GetToken(Dictionary<string, string> config)
        {
            string Token = "Token";

            if (config.ContainsKey(Token))
            {
                return new Token(config[Token]) ;
            }
            throw new Exception(String.Format(ConfigError.MissingKey, Token));
        }

        public void BuildRequest()
        {

            this.SetTicker();
            this.SetRequestType();
            this.RequestContent = request;
            
        }

        private void SetTicker()
        {
            string Ticker = "Ticker";

            if (config.ContainsKey(Ticker))
            {
                this.request.Ticker = this.config[Ticker];
            }
            else { throw new Exception(String.Format(ConfigError.MissingKey, Ticker));};


      
        }

        private void SetRequestType()
        {
            string Type = "Type";

            if (config.ContainsKey(Type))
            {
                this.request.Ticker = this.config[Type];
            }
            else { throw new Exception(String.Format(ConfigError.MissingKey, Type)); };

        }


    }

   



}


