using Newtonsoft.Json;

namespace fourplaceproject.Model
{
	public class RegisterRequest
	{
		[JsonProperty("email")]
		public string Email { get; set; }
		
		[JsonProperty("first_name")]
		public string FirstName { get; set; }
		
		[JsonProperty("last_name")]
		public string LastName { get; set; }
		
		[JsonProperty("password")]
		public string Password { get; set; }

        public RegisterRequest(string email, string firstname, string lastname, string password)
        {
            Email = email;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
        }
	}
}