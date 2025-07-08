
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newsite.Models;

public class UserComment{

      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
      public int UserId { get; set; }
      public int PostId { get; set; }
      public bool Active { get; set; }
      public string? Comment { get; set; }
      public DateTime CreatedAt { get; set; }
}