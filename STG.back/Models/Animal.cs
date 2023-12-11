using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace STG.back.Models;

public partial class Animal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnimalId { get; set; }

    public string Name { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Sex { get; set; } = null!;

    public decimal Price { get; set; }

    public string Status { get; set; } = null!;
}
