using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsecurityWithSaltAndHash.Entity
{
    public class HashAndSalt
    {
        public string hashWithSaltResult { get; set; }
        public string saltString { get; set; }
        public HashAndSalt(string saltStringData,string hashWithSaltResultString)
        {
            hashWithSaltResult= hashWithSaltResultString;
            saltString = saltStringData;  
        }
    }
}
