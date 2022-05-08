using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Repositories
{
    public interface IInspectionRepository
    {
        Task<string> AddNew(InspectionViewModel model);
        Task<List<InspectionViewModel>> GetAllInspection();
        Task<InspectionViewModel> GetCheckById(string id);
       
    }
}
