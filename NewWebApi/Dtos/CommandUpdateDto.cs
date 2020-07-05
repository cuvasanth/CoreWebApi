using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebApi.Dtos
{
    public class CommandUpdateDto
    {

        [Required]
        [MaxLength(240)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
