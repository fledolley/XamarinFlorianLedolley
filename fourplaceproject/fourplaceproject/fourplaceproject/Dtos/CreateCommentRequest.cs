using Newtonsoft.Json;

namespace fourplaceproject.Model
{
	public class CreateCommentRequest
	{
		[JsonProperty("text")]
		public string Text { get; set; }

        public CreateCommentRequest(string text)
        {
            Text = text;
        }
	}
}