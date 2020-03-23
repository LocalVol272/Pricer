using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetVolSto.Struct;
using System.Net.Http;
namespace ProjetVolSto.PricerObjects
{
    interface IEXCloudRequest
    {
        Token Token { get; set; }
       

    }

    interface IAuthentification
    {
        Token Token { get; set; }
        Token GetToken(Dictionary<string, object> config);
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

    interface IEXDate
    {
        int Year { get; set; }
        int Month{ get; set; }
        int Day { get; set; }
        string Format();
    }




}
