using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationsAboutToken
{
    public class TokenRequest
    {


        
        [JsonProperty("username")]
        public string UserName { get; set; }


       
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
