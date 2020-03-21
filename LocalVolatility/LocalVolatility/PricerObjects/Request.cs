using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetVolSto.Struct;
namespace ProjetVolSto.PricerObjects
{
    interface IEXCloudRequest
    {
        Token Token { get; set; }
        bool Post(string url);
        bool Get(string url);

    }

    interface IAuthentification
    {
        Token Token { get; set; }
        Token GetToken(Dictionary<string, string> config);
        bool Authentification(Token token);
    }

    interface IEXMessage
    {
        Dictionary<string, string> Read();
    }

    interface IEXCloudResponse: IEXMessage
    {
       bool CheckResponse();
        
    }



}
