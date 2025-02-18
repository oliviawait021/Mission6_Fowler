using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Fowler.Models;

public class Form // create database format
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CatgoryId")] // foreign key connecting different table
    public int CategoryId { get; set; }
    public Categories? Category { get; set; }
    [Required(ErrorMessage = "Please enter the movie title.")]
    public string Title { get; set; }
    [Required]
    [Range(1880, int.MaxValue, ErrorMessage = "Year must be 1880 or later.")]
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    [Required(ErrorMessage = "Please enter if the movie has been edited.")]
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    [Required(ErrorMessage = "Please enter if the movie has been copied to plex.")]
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
}
