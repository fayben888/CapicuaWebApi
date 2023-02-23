using System.ComponentModel.DataAnnotations;

public class Capicua
{    [Key]
     public Guid CapicuaId { get; set; }
    
    [Required]
    [MaxLength(150)]
     public string Word { get; set; } ="";
    // public DateTime Created { get; set; }

    
}