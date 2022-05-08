using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Repositories
{
    public interface IPaymentRepository
    {
        Task<string> AddNew(PaymentViewModel model);
        Task<List<PaymentViewModel>> GetAllPayments();
        Task<PaymentViewModel> GetDepositById(string id);
    }
}
