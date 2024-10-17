using Kebab_Simulator.Core.Domain;
using Kebab_Simulator.Core.Domain.Serviceinterface;
using Kebab_Simulator.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab_Simulator.ApplicationServices.Services
{
    public class KebabServices : IKebabSimulatorServices
    {
        private readonly KebabSimulatorContext _context;

        public KebabServices(KebabSimulatorContext context)
        {
            _context = context;
        
        }

        public async Task<Kebab> DetailsAsync(Guid id)
        {
            var result = await _context.Kebabs
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
    }
}
