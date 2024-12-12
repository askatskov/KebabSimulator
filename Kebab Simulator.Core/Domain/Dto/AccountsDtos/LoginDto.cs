using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticTitans.Core.Dto.AccountsDtos
{
    public class LoginDto
    {
        public string Email { get; set; }

        //public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
