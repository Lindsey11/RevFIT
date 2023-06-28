using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.Services.ViewModels
{
    public class APIUserViewModel
    {
        public int UserId { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Salt { get; set; } = null!;

        public DateTime DateCreated { get; set; }
    }
}
