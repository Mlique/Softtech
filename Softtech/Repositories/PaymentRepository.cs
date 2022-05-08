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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ResManagementDBContext context;

        public PaymentRepository(ResManagementDBContext context)
        {
            this.context = context;
        }
        public async Task<string> AddNew(PaymentViewModel model)
        {
            var pay = new TblPayment()
            {
                AmountPaid = model.AmountPaid,
                Date = DateTime.Now,
                DocumentPath = model.DocumentPath,
                ImagePath = model.ImagePath,
                Reference = model.Reference,
                Balance = model.Balance,
                AdminId = model.AdminId,
                StudentId = model.StudentId
            };

            await context.AddAsync(pay);
            await context.SaveChangesAsync();

            return pay.PaymentId;
        }

        public async Task<List<PaymentViewModel>> GetAllPayments()
        {
            return await context.TblPayments
                  .Select(deposit => new PaymentViewModel()
                  {
                      AmountPaid = deposit.AmountPaid,
                      Date = DateTime.Now,
                      DocumentPath = deposit.DocumentPath,
                      ImagePath = deposit.ImagePath,
                      StudentId = deposit.StudentId
                  }).ToListAsync();
        }

        public async Task<PaymentViewModel> GetDepositById(string id)
        {
            return await context.TblPayments.Where(x => x.PaymentId == id)
                 .Select(deposit => new PaymentViewModel()
                 {
                     AmountPaid = deposit.AmountPaid,
                     Date = DateTime.Now,
                     DocumentPath = deposit.DocumentPath,
                     ImagePath = deposit.ImagePath,
                     StudentId = deposit.StudentId
                 }).FirstOrDefaultAsync();
        }
    }
}
