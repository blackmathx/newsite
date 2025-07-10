
namespace newsite.ViewModels;
public class PostViewModel
{
    public int Id { get; set; }
	public bool Active { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
	public string Commentary { get; set; } = string.Empty;
    public DateTime PostedOn { get; set; }
    public string SubmittedBy {get; set; } = string.Empty;

}