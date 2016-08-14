using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(4096, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(4096, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
