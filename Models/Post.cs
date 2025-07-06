
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newsite.Models;

public class Post
{
	[Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string? Url { get; set; }
	public string? Title { get; set; }
	public DateTime PostedOn { get; set; }
}