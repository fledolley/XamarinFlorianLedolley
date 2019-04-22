using Newtonsoft.Json;

namespace fourplaceproject.Model
{
    public class RefreshRequest
    {
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        public RefreshRequest(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
    
}