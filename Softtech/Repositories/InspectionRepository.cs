using AutoMapper.Configuration;
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
    public class InspectionRepository : IInspectionRepository
    {
        private readonly ResManagementDBContext context;

        public InspectionRepository(ResManagementDBContext context)
        {
            this.context = context;
        }
        public async Task<string> AddNew(InspectionViewModel model)
        {
            var newInspec = new TblInspection()
            {
                Comment = model.Comment,
                Date = DateTime.Now,
                Condition = model.Condition,
                RoomId = model.RoomId,
                CheckPdfUrl = model.CheckPdfUrl,
                StudentId = model.StudentId,
                InspectorId = model.InspectorId
            };

          
            await context.AddAsync(newInspec);
            await context.SaveChangesAsync();

            return newInspec.InspectionId;
        }

        public async Task<List<InspectionViewModel>> GetAllInspection()
        {
            return await context.TblInspections.Include(a => a.Student)
                  .Select(insp => new InspectionViewModel()
                  {
                      Comment = insp.Comment,
                      Date = insp.Date,
                      Condition = insp.Condition,
                      RoomId = insp.RoomId,
                      InspectionId = insp.InspectionId,
                      CheckPdfUrl = insp.CheckPdfUrl,
                      StudentId = insp.StudentId,
                      InspectorId = insp.InspectorId
                  }).ToListAsync();
        }

        public async Task<InspectionViewModel> GetCheckById(string id)
        {
            return await context.TblInspections.Where(x => x.InspectionId == id)
                 .Select(insp => new InspectionViewModel()
                 {
                     Comment = insp.Comment,
                     Date = insp.Date,
                     Condition = insp.Condition,
                     RoomId = insp.RoomId,
                     InspectionId = insp.InspectionId,
                     CheckPdfUrl = insp.CheckPdfUrl,
                     StudentId = insp.StudentId,
                     InspectorId = insp.InspectorId
                 }).FirstOrDefaultAsync();
        }
      
    }
}
