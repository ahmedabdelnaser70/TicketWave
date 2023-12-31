﻿using System.ComponentModel.DataAnnotations;
using ticketWave.Data.Base;

namespace ticketWave.Models
{
    public class Actor :BaseEntity
    {
        [Key]
        public new int Id { get; set; }

        [Display(Name = "Profile Picture URL")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage = "Full Name must be at least 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relationships
        public ICollection<Actor_Movie> Actors_Movies { get; set; } = new HashSet<Actor_Movie>();
    }
}
