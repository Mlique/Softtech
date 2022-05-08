using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Repositories
{
    public interface IFaultRepository
    {
        Task<string> AddNew(FaultViewModel model);
        Task<List<FaultViewModel>> GetAllFault();
        Task<FaultViewModel> GetFaultById(string id);
    }
}
