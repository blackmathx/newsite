using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace newsite.Models 
{
public class Submission {

      [Key]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
	  public string? Title { get; set; }
      public string? URL { get; set; }
      public bool Active { get; set; }
      public string? SubmittedBy { get; set; }
      public string? Comment { get; set; }
      public DateTime CreatedAt { get; set; }
}

}