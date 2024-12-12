using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab_Simulator.Core.Domain.Dto
{
    public class EmailTokenDto : EmailDto
    {
        public string Token { get; set; }
    }
}
