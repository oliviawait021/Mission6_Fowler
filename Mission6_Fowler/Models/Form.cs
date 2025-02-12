using System.ComponentModel.DataAnnotations;

namespace Mission6_Fowler.Models;

public class Form
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    public string MovieName { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    public string Edited { get; set; }
    public string LentTo { get; set; }
    public string Notes { get; set; }
}
