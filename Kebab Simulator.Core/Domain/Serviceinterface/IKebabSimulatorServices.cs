using Kebab_Simulator.Core.Domain;
using Kebab_Simulator.Core.Domain.Dto;
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
        Task<Kebab> Create(KebabDto dto);
        Task<Kebab> Update(KebabDto dto);
        Task<Kebab> Delete(Guid id);

    }
}
