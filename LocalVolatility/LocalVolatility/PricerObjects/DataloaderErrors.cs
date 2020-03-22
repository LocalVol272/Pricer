﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVolSto.PricerObjects
{
  
    public static class ConfigError
    {
        public const string MissingTokenValue = "Token Key Do Not Exist In Config";
        public const string MissingKey = "The {0} Is Not Refer In The Dictionary";
        public const string MissingHttpRequestContent = "This Request Cannot Be Executed : Missing _RequestContent";
    }




}
