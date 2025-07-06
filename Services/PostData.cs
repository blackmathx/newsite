using newsite.Models;

namespace newsite.Services;

public class PostData
{
	public static List<Post> GetPosts()
	{
		return new List<Post>
		{
			new Post { Id = 1, Url = "https://example.com/post1", Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", PostedOn = DateTime.Now },
			new Post { Id = 2, Url = "https://example.com/post2", Title = "Sed ut perspiciatis unde omnis iste", PostedOn = DateTime.Now.AddDays(-1) },
			new Post { Id = 4, Url = "https://example.com/post1", Title = "Ut enim ad minima veniam, quis nostrum exercitationem", PostedOn = DateTime.Now.AddDays(-1) },
			new Post { Id = 6, Url = "https://example.com/post2", Title = "Quis autem vel eum", PostedOn = DateTime.Now.AddDays(-3) },
			new Post { Id = 7, Url = "https://example.com/post1", Title = "Architecto beatae vitae dicta", PostedOn = DateTime.Now.AddDays(-4) },
			new Post { Id = 8, Url = "https://example.com/post2", Title = "Ullam corporis suscipit", PostedOn = DateTime.Now.AddDays(-4) }
		};
	}
}