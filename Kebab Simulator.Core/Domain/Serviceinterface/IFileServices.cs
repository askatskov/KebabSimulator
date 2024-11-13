using Kebab_Simulator.Core.Domain.Dto;
using Kebab_Simulator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab_Simulator.Core.Domain.Serviceinterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(KebabDto dto, Kebab domain);
        async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);

    }
}
