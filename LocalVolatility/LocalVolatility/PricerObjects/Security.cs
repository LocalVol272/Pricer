
using System;
using System.Collections.Generic;
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
        private Dictionary<string, string> config;
        Token IEXCloudRequest.Token { get => this.token; set => this.token = value; }
        Token IAuthentification.Token { get => this.token; set => this.token =value; }

        public ApiRequest(Dictionary<string, string> config)
        {
            this.config = config;
            this.token = this.GetToken(config);
        }


        public bool Post(string url) => throw new NotImplementedException();
        public bool Get(string url) => throw new NotImplementedException();
    


        public bool Authentification(Token token)
        {
            throw new NotImplementedException();
        }




        public Token GetToken(Dictionary<string, string> config)
        {
            if (config.ContainsKey("Token"))
            {
                return new Token(config["Token"]) ;
            }
            throw new Exception("Token Key Do Not Exist In Config");
        }


    }




    class DataLoader
    {
        private Dictionary<string, string> config;
        IEXCloudRequest _request;

        internal IEXCloudRequest Request { get => _request;}
        internal Dictionary<string, string> Config { get => config; set => config = value; }

        public void Main()
        {
            InitRequest();
        }

        private void InitRequest()
        {
            _request = MakeRequest(Config);
        }

        private ApiRequest MakeRequest(Dictionary<string,string> config)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            return new ApiRequest(config);
 
        }

       
    }




}


