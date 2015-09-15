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
        public long Id { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "O campo nome não pode ter mais de 200 caracteres")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [MaxLength(100, ErrorMessage = "O campo nacionalidade não pode ter mais de 100 caracteres")]
        public string Nationality { get; set; }
        [MaxLength(100, ErrorMessage = "O campo emprego não pode ter mais de 100 caracteres")]
        public string Job { get; set; }
        public List<SlideDTO> Slides { get; set; }
    }
}
