using Kebab_Simulator.Core.Domain;
using Kebab_Simulator.Core.Domain.Dto;
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
        private readonly IFileServices _fileServices;

        public KebabServices(KebabSimulatorContext context , IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        
        }

        public async Task<Kebab> DetailsAsync(Guid id)
        {
            var result = await _context.Kebabs
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
        public async Task<Kebab> Create(KebabDto dto)
        {
            Kebab kebab = new Kebab();

            kebab.ID = Guid.NewGuid();

            kebab.KebabXP = 0;
            kebab.KebabXPNextLevel = 100;
            kebab.KebabLevel = 0;
            kebab.KebabStatus = Core.Domain.KebabStatus.Making;
            kebab.KebabStart = DateTime.Now;
            kebab.KebabDone = DateTime.Parse("01/01/999 00:00:00");

            //set by user

            kebab.KebabName = dto.KebabName;
            kebab.KebabType = (Core.Domain.KebabType)dto.KebabType;
            kebab.Checkout = dto.Checkout;
            kebab.KebabBankAccount = dto.KebabBankAccount;


            //set for db
            kebab.CreatedAt = DateTime.Now;
            kebab.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, kebab);
            }
            await _context.Kebabs.AddAsync(kebab);
            await _context.SaveChangesAsync();

            return kebab;

        }
    }
}
