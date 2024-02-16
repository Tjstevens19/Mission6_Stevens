using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Mission6_Stevens.Models
{
    public class AddMovieModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        public string Category { get; set; }
        public string? Subcategory { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [Range(0,25)]
        public string? Notes { get; set; }

    }
}


