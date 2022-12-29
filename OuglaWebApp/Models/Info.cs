using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OuglaWebApp.Models;

public partial class Info
{
    [Key]
    [Required(ErrorMessage ="Please Enter your sitename to continue")]
    public string Sitename { get; set; } = null!;
    [Required(ErrorMessage = "Please Enter your Name to continue")]
    public string Ownername { get; set; } = null!;
    [Required(ErrorMessage = "Please Enter a Password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string Password { get; set; } = null!;
    [Required(ErrorMessage = "Please Enter a Password")]
    [NotMapped]
    public int ComparePassword { get; set; }

    public virtual ICollection<Record> Records { get; } = new List<Record>();
}
