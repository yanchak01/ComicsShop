using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ComicsShop.DTO
{
    public class RegistrationDTO
    {

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("confirmpassword")]
        public string ConfirmPassword { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
