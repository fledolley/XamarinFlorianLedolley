using Newtonsoft.Json;

namespace fourplaceproject.Model
{
    public class UserItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("image_id")]
        public int? ImageId { get; set; }

        public UserItem (int id, string first, string last, string email, int? imageid)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            Email = Email;
            ImageId = imageid;
        }
    }
}