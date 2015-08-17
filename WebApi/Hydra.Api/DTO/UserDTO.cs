using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hydra.Api.DTO
{
    public class UserDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "olha a merda que você ta fazendo")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Nationality { get; set; }
        [MaxLength(100)]
        public string Job { get; set; }
        public List<SlideDTO> Slides { get; set; }
    }
}
