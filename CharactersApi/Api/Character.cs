using System;
using System.ComponentModel.DataAnnotations;

namespace Api
{
    public class Character
    {
        [Key]
        public Guid Id {  get; set; }
        [Required]
        public int CharId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Status { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
