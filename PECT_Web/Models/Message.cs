using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PECT_Web.Models
{
    public class Message
    {
        [Required(ErrorMessage = "You haven't written any secret data! :(")]
        [MinLength(4, ErrorMessage = "The length must be at least 4 charachters!")]
        [MaxLength(100000, ErrorMessage = "The length must be less than 100 000 charachters!")]
        public string InputMessage { get; set; }
    }
}
