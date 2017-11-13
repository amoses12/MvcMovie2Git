namespace MvcMovie2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations; //provides formatting attributes as well as built in set of validation attributes for class. DataType attributes are not validatoin attributes
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Title")]

        public string MovieName { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] //DataType does not have specific formatting. This line specifies the formatting for how we want Date displayed. ApplyFormatIn Edit Mode applies to edit mode as well.

        public DateTime ReleaseDate { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z''null'\s]")]
        [StringLength(5)]
        public string Rating { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}
