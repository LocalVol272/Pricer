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
        ApiRequest _request;

        internal ApiRequest Request { get => _request; }
        internal Dictionary<string, string> Config { get; set; }

        public void Main()
        {
            InitRequest();
             
        }

        private void InitRequest()
        {
            _request = MakeRequest(Config);
            _request.BuildRequest();
        }

        private ApiRequest MakeRequest(Dictionary<string, string> config)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }






            return new ApiRequest(config); ;

        }

      



    }

}
