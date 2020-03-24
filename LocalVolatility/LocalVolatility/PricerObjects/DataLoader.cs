using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetVolSto.Struct;

namespace ProjetVolSto.PricerObjects
{
    class DataLoader
    {
        public ApiRequest _request;

        public ApiRequest Request { get => _request; set => _request = value; }
        internal Dictionary<string, object> Config { get; set; }

        public void Execute()
        {
            InitRequest();
            string a = ExecuteRequestAsync().GetAwaiter().GetResult();
        }

        private void InitRequest()
        {
            _request = MakeRequest(Config);
            _request.BuildRequest();


        }

        private ApiRequest MakeRequest(Dictionary<string, object> config)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }


            return new ApiRequest(config); ;

        }

        private async Task<string> ExecuteRequestAsync()
        {
            // this method will execute the request with proper config
            if (Request.RequestContent.Type == "GET") { return await Request.Get(); }
            else { return await Request.Get(); }
        }


    }
}
