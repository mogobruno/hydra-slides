using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hydra.Api.DTO
{
    public class SlideDTO
    {
        [Required]
        public long Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "O campo titulo não pode ter mais de 100 caracteres")]
        public string Title { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "O campo sub-título não pode ter mais de 100 caracteres")]
        public string SubTitle { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "O campo descrição não pode ter mais de 1000 caracteres")]
        public string Description { get; set; }
        [Required]
        public string Theme { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}