using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hydra.Api.DTO
{
    public class UserUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200, ErrorMessage = "O campo nome não pode ter mais de 200 caracteres")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [MaxLength(100, ErrorMessage = "O campo nacionalidade não pode ter mais de 100 caracteres")]
        public string Nationality { get; set; }
        [MaxLength(100, ErrorMessage = "O campo emprego não pode ter mais de 100 caracteres")]
        public string Job { get; set; }
    }
}
