using Kebab_Simulator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab_Simulator.Core.Domain.Serviceinterface
{
    public interface IKebabSimulatorServices
    {
        Task<Kebab> DetailsAsync(Guid id);
    }
}
