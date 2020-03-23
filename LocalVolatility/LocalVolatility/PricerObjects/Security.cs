
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
    class ApiRequest : Request, IEXCloudRequest,IAuthentification
    {
        protected Token token;
        private IEXRequest request;
        private Dictionary<string, object> config;
        Token IEXCloudRequest.Token { get => this.token; set => this.token = value; }
        Token IAuthentification.Token { get => this.token; set => this.token =value; }
        public IEXRequest RequestContent { get => request; set => request = value; }
        public override void Get(IEXRequest Request) => throw new NotImplementedException(ApiRequestError.NonImplementedMethod);
        public override void Post(IEXRequest Request) => throw new NotImplementedException(ApiRequestError.NonImplementedMethod);
        public override void Get(HttpContent Request) => throw new NotImplementedException(ApiRequestError.NonImplementedMethod);
        public override void Post(HttpContent Request) => throw new NotImplementedException(ApiRequestError.NonImplementedMethod);
        public override void Get(object Request) => throw new NotImplementedException(ApiRequestError.NonImplementedMethod);
        public override void Post(object Request) => throw new NotImplementedException(ApiRequestError.NonImplementedMethod);



        public ApiRequest(Dictionary<string, object> config)
        {
            this.config = config;
            this.token = this.GetToken(config);
            
        }

       

        public bool Authentification(Token token)
        {
            throw new NotImplementedException();
        }


        public Token GetToken(Dictionary<string, object> config)
        {
            string Token = "Token";

            if (config.ContainsKey(Token))
            {
                return new Token(config[Token].ToString()) ;
            }
            throw new Exception(String.Format(ConfigError.MissingKey, Token));
        }

        public void BuildRequest()
        {

            this.SetTicker();
            this.SetRequestType();
            this.SetParams();
            this.BuildUrl();
            this.RequestContent = request;
            
        }

        private void SetTicker()
        {
            string Ticker = "Ticker";

            if (config.ContainsKey(Ticker))
            {
                this.request.Ticker = this.config[Ticker].ToString();
            }
            else { throw new Exception(String.Format(ConfigError.MissingKey, Ticker));};


      
        }

        private void SetRequestType()
        {
            string Type = "Type";

            if (config.ContainsKey(Type))
            {
                this.request.Type = this.config[Type].ToString();
            }
            else { throw new Exception(String.Format(ConfigError.MissingKey, Type)); };

        }


        private void BuildUrl()
        {
            

        }

        private void SetParams()
        {
            string Params = "Params";

            if (config.ContainsKey(Params))
            {
                if (this.config[Params].GetType() == typeof(Dictionary<string, object>))
                {


                    this.request.Params = this.config[Params];
                }
            }
            else { throw new Exception(String.Format(ConfigError.MissingKey, Params)); };
        }

        public override async Task<string> Post()
        {
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage message = await client.PostAsync(RequestContent.Url, RequestContent.HttpContent);
                return await message.Content.ReadAsStringAsync();
            }
            catch (Exception _exception)
            {
                Console.WriteLine(_exception);
            }
            return null;
        }

        public override async Task<string> Get()
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage message = await client.GetAsync("https://sandbox.iexapis.com/stable/stock/aapl/options/202001?token=Tsk_bbe66f58b6d149f59a9af4eb83bfc7f5");
                
                Console.WriteLine(message.Content.ToString());
                return await message.Content.ReadAsStringAsync();

            }
            catch (Exception _exception)
            {
                Console.WriteLine(_exception);
            }
            return null;
        }




    }

   



}


