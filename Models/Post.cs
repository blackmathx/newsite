
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newsite.Models;

public class Post
{
	[Key]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public bool Active { get; set; }
	public bool Published { get; set; }
	public string? Title { get; set; }
	public string? Url { get; set; }
	public string? Source { get; set; }
	public string? Commentary { get; set; }
	public string? SubmittedBy { get; set; }
	public DateTime CreatedAt { get; set; }

}