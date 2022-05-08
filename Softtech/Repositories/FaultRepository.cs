using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Repositories
{
    public class FaultRepository : IFaultRepository
    {
        private readonly ResManagementDBContext context;

        public FaultRepository(ResManagementDBContext context)
        {
            this.context = context;
        }
        public async Task<string> AddNew(FaultViewModel model)
        {
            var fault = new TblFault()
            {
                Description = model.Description,
                ReportDate = DateTime.Now,
                RoomId = model.RoomId,
                ImagePath = model.DocumentPath,
                StudentId = model.StudentId
            };


            await context.AddAsync(fault);
            await context.SaveChangesAsync();

            return fault.FaultId;
        }

        public async Task<List<FaultViewModel>> GetAllFault()
        {
            return await context.TblFaults
                  .Select(faults => new FaultViewModel()
                  {
                      Description = faults.Description,
                      ReportDate = DateTime.Now,
                      RoomId = faults.RoomId,
                      DocumentPath = faults.ImagePath,
                      StudentId = faults.StudentId
                  }).ToListAsync();
        }

        public async Task<FaultViewModel> GetFaultById(string id)
        {
            return await context.TblFaults.Where(x => x.FaultId == id)
                 .Select(faults => new FaultViewModel()
                 {
                     Description = faults.Description,
                     ReportDate = DateTime.Now,
                     RoomId = faults.RoomId,
                     DocumentPath = faults.ImagePath,
                     StudentId = faults.StudentId
                 }).FirstOrDefaultAsync();
        }
    }
}
