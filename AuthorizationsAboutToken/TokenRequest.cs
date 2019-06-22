using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationsAboutToken
{
    public class TokenRequest
    {


        [Required]
        [JsonProperty("username")]
        public string UserName { get; set; }


        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
