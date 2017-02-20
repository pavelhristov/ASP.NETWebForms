using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Data.Models
{
    public class Superhero
    {
        // TODO: research guid vs int!
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string SecretIdentity { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        public bool isDeleted { get; set; }
    }
}
