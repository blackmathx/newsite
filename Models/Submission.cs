

namespace newsite.Models;

public class Submission {

      [Key]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public integer Id { get; set; }
      public string URL { get; set; }
      public bool Active { get; set; }
      public string SubmittedBy { get; set; }
      public string Comment { get; set; }
      public DateTime SubmittedOn { get; set; }
}