using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Models
{
    public class Helper
    {
        ResManagementDBContext context = new ResManagementDBContext();
        public int January()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-01-01' AND '2021-01-31'");

            var data = context.Jan.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int February()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-02-01' AND '2021-02-28'");

            var data = context.Feb.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }
            return f;
        }

        public int March()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-03-01' AND '2021-03-31'");

            var data = context.Mar.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int April()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-04-01' AND '2021-04-30'");

            var data = context.Apr.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int May()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-05-01' AND '2021-05-31'");

            var data = context.May.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int June()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-06-01' AND '2021-06-30'");

            var data = context.Jun.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int July()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-07-01' AND '2021-07-31'");

            var data = context.Jul.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int August()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-08-01' AND '2021-08-30'");

            var data = context.Aug.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int September()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-09-01' AND '2021-09-30'");

            var data = context.Sep.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int October()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-10-01' AND '2021-10-31'");

            var data = context.Oct.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int November()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-11-01' AND '2021-11-30'");

            var data = context.Nov.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int December()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-12-01' AND '2021-12-31'");

            var data = context.Dec.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int[] Data()
        {
            int[] objs = { January(), February(), March(), April(), May(), June(), July(), August(), September(), October(), November(), December() };

            return objs;
        }
        public int JanAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-01-01' AND '2021-01-31'  AND StudentFundedBy = 'NSFAS'");

            var data = context.JR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int FebAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-02-01' AND '2021-02-28'  AND StudentFundedBy = 'NSFAS'");

            var data = context.FR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int MarAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-03-01' AND '2021-03-31'  AND StudentFundedBy = 'NSFAS'");

            var data = context.MR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int AprAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-04-01' AND '2021-04-30'  AND StudentFundedBy = 'NSFAS'");

            var data = context.AR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int MayAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-05-01' AND '2021-05-31'  AND StudentFundedBy = 'NSFAS'");

            var data = context.MA.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int JunAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-06-01' AND '2021-06-30'  AND StudentFundedBy = 'NSFAS'");

            var data = context.JU.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int JulAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-07-01' AND '2021-07-31'  AND StudentFundedBy = 'NSFAS'");

            var data = context.JL.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int AugAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-08-01' AND '2021-08-31'  AND StudentFundedBy = 'NSFAS'");

            var data = context.AU.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int SepAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-09-01' AND '2021-09-30'  AND StudentFundedBy = 'NSFAS'");

            var data = context.SE.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int OctAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-10-01' AND '2021-10-31'  AND StudentFundedBy = 'NSFAS'");

            var data = context.OC.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int NovAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-11-01' AND '2021-11-30'  AND StudentFundedBy = 'NSFAS'");

            var data = context.NO.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int DecAppr()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-12-01' AND '2021-12-31'  AND StudentFundedBy = 'NSFAS'");

            var data = context.DE.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }

        public int[] Datas()
        {
            int[] objs = { JanAppr(), FebAppr(), MarAppr(), AprAppr(), MayAppr(), JunAppr(), JulAppr(), AugAppr(), SepAppr(), OctAppr(), NovAppr(), DecAppr() };

            return objs;
        }

        public int JanC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-01-01' AND '2021-01-31'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.JR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int FebC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-02-01' AND '2021-02-28'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.FR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int MarC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-03-01' AND '2021-03-31'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.MR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int AprC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-04-01' AND '2021-04-30'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.AR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int MayC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-05-01' AND '2021-05-31'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.MA.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int JunC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-06-01' AND '2021-06-30'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.JU.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int JulC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-07-01' AND '2021-07-31'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.JL.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int AugC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-08-01' AND '2021-08-31'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.AU.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int SepC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-09-01' AND '2021-09-30'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.SE.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int OctC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-10-01' AND '2021-10-31'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.OC.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int NovC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-11-01' AND '2021-11-30'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.NO.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int DecC()
        {
            context.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-12-01' AND '2021-12-31'  AND StudentFundedBy = 'Private Bursary'");

            var data = context.DE.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }

        public int[] Dat()
        {
            int[] objs = { JanC(), FebC(), MarC(), AprC(), MayC(), JunC(), JulC(), AugC(), SepC(), OctC(), NovC(), DecC() };

            return objs;
        }
    }
}

