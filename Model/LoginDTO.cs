using Newtonsoft.Json;

namespace ComicsShop.DTO
{
    public class LoginDTO
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
