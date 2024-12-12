using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticTitans.Core.Dto.AccountsDtos
{
    public class ApplicationUserDto
    {
        public string City { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid? AssociatedPlayerProfile { get; set; }
    }
}
