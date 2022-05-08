using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Softtech.Models;

namespace Softtech.Data
{
    public partial class ResManagementDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
    ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ResManagementDBContext()
        {
        }

        public ResManagementDBContext(DbContextOptions<ResManagementDBContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=sict-sql.mandela.ac.za;User ID=RMS09;Password=rms09-2020;MultipleActiveResultSets=True");
            }
        }
        public virtual DbSet<TblCity> TblCities { get; set; }
        public virtual DbSet<TblBooking> TblBookings { get; set; }
        public virtual DbSet<TblDeposit> TblDeposits { get; set; }
        public virtual DbSet<TblFault> TblFaults { get; set; }
        public virtual DbSet<TblReview> TblReviews { get; set; }
        public virtual DbSet<TblInspection> TblInspections { get; set; }
        public virtual DbSet<TblPayment> TblPayments { get; set; }
        public virtual DbSet<TblRoom> TblRooms { get; set; }
        public virtual DbSet<TblRoomType> TblRoomTypes { get; set; }
        public virtual DbSet<TblVisitor> TblVisitors { get; set; }
        public virtual DbSet<Claim> tblClaims { get; set; }
        public virtual DbSet<ApplicationUser> tblApplicationUser { get; set; }

        public virtual DbSet<Jan> Jan { get; set; }
        public virtual DbSet<Feb> Feb { get; set; }
        public virtual DbSet<Mar> Mar { get; set; }
        public virtual DbSet<Apr> Apr { get; set; }
        public virtual DbSet<May> May { get; set; }
        public virtual DbSet<Jun> Jun { get; set; }
        public virtual DbSet<Jul> Jul { get; set; }
        public virtual DbSet<Aug> Aug { get; set; }
        public virtual DbSet<Sep> Sep { get; set; }
        public virtual DbSet<Oct> Oct { get; set; }
        public virtual DbSet<Nov> Nov { get; set; }
        public virtual DbSet<Dec> Dec { get; set; }

        //approved appointments
        public virtual DbSet<JR> JR { get; set; }
        public virtual DbSet<FR> FR { get; set; }
        public virtual DbSet<MR> MR { get; set; }
        public virtual DbSet<AR> AR { get; set; }
        public virtual DbSet<AR> MA { get; set; }
        public virtual DbSet<JU> JU { get; set; }
        public virtual DbSet<JL> JL { get; set; }
        public virtual DbSet<AU> AU { get; set; }
        public virtual DbSet<SE> SE { get; set; }
        public virtual DbSet<OC> OC { get; set; }
        public virtual DbSet<NO> NO { get; set; }
        public virtual DbSet<DE> DE { get; set; }

        //cancelled appointments
        public virtual DbSet<JA> JA { get; set; }
        public virtual DbSet<FE> FE { get; set; }
        public virtual DbSet<MAR> MAR { get; set; }
        public virtual DbSet<AP> AP { get; set; }
        public virtual DbSet<MY> MY { get; set; }
        public virtual DbSet<JN> JN { get; set; }
        public virtual DbSet<JUL> JUL { get; set; }
        public virtual DbSet<AUGU> AUGU { get; set; }
        public virtual DbSet<SEPT> SEPT { get; set; }
        public virtual DbSet<OCT> OCT { get; set; }
        public virtual DbSet<NOV> NOV { get; set; }
        public virtual DbSet<DEC> DEC { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder
            //    .Entity<TblPayment>()
            //    .HasOne(a => a.Admin)
            //    .WithMany(dr => dr.Administrator)
            //    .HasForeignKey(a => a.PaymentId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder
            //    .Entity<TblPayment>()
            //    .HasOne(a => a.Student)
            //    .WithMany(p => p.Students)
            //    .HasForeignKey(a => a.PaymentId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<TblInspection>()
                .HasOne(a => a.Student)
                .WithMany(p => p.StudentInspec)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
              .Entity<TblInspection>()
              .HasOne(a => a.Inspector)
              .WithMany(p => p.Inspectors)
              .HasForeignKey(a => a.InspectorId)
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TblBooking>(entity =>
            {
                entity.ToTable("TblBookings");

                entity.HasKey(e => e.BookingId);

                entity.Property(e => e.BookingId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.ToTable("TblCities");

                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<TblDeposit>(entity =>
            {
                entity.ToTable("TblDeposits");

                entity.HasKey(e => e.DepositId);

                entity.Property(e => e.DepositId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<TblFault>(entity =>
            {
                entity.ToTable("TblFaults");

                entity.HasKey(e => e.FaultId);

                entity.Property(e => e.FaultId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<TblReview>(entity =>
            {
                entity.ToTable("TblReviews");

                entity.HasKey(e => e.ReviewId);

                entity.Property(e => e.ReviewId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");


            });
            modelBuilder.Entity<TblInspection>(entity =>
            {
                entity.ToTable("TblInspections");

                entity.HasKey(i => i.InspectionId);

                entity.Property(e => e.InspectionId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<TblPayment>(entity =>
            {
                entity.ToTable("TblPayments");

                entity.HasKey(i => i.PaymentId);

                entity.Property(e => e.PaymentId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<TblRoom>(entity =>
            {
                entity.ToTable("TblRooms");

                entity.HasKey(e => e.RoomId);

                entity.Property(e => e.RoomId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<TblRoomType>(entity =>
            {
                entity.ToTable("TblRoomTypes");

                entity.HasKey(e => e.RoomTypeId);

                entity.Property(e => e.RoomTypeId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<TblVisitor>(entity =>
            {
                entity.ToTable("TblVisitors");

                entity.HasKey(e => e.VisitorId);

                entity.Property(e => e.VisitorId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });

                //stored procedures for 2021 appointments

                modelBuilder
           .Entity<Jan>(entity =>
           {
               entity.HasNoKey();
               entity.ToSqlQuery("sp_JanStats");
               entity.Property(v => v.Total).HasColumnName("Total");

           });
                modelBuilder
           .Entity<Feb>(entity =>
           {
               entity.HasNoKey();
               entity.ToSqlQuery("sp_FebStats");
               entity.Property(v => v.Total).HasColumnName("Total");

           });
                modelBuilder
           .Entity<Mar>(entity =>
           {
               entity.HasNoKey();
               entity.ToSqlQuery("sp_MarStats");
               entity.Property(v => v.Total).HasColumnName("Total");

           });
                modelBuilder
          .Entity<Apr>(entity =>
          {
              entity.HasNoKey();
              entity.ToSqlQuery("sp_AprStats");
              entity.Property(v => v.Total).HasColumnName("Total");

          });
                modelBuilder
           .Entity<May>(entity =>
           {
               entity.HasNoKey();
               entity.ToSqlQuery("sp_MaybStats");
               entity.Property(v => v.Total).HasColumnName("Total");

           });
                modelBuilder
           .Entity<Jun>(entity =>
           {
               entity.HasNoKey();
               entity.ToSqlQuery("sp_JunStats");
               entity.Property(v => v.Total).HasColumnName("Total");

           });
                modelBuilder
          .Entity<Jul>(entity =>
          {
              entity.HasNoKey();
              entity.ToSqlQuery("sp_JulStats");
              entity.Property(v => v.Total).HasColumnName("Total");

          });
                modelBuilder
           .Entity<Aug>(entity =>
           {
               entity.HasNoKey();
               entity.ToSqlQuery("sp_AugStats");
               entity.Property(v => v.Total).HasColumnName("Total");

           });
                modelBuilder
           .Entity<Sep>(entity =>
           {
               entity.HasNoKey();
               entity.ToSqlQuery("sp_SeptStats");
               entity.Property(v => v.Total).HasColumnName("Total");

           });
                modelBuilder
          .Entity<Oct>(entity =>
          {
              entity.HasNoKey();
              entity.ToSqlQuery("sp_OctStats");
              entity.Property(v => v.Total).HasColumnName("Total");

          });
                modelBuilder
           .Entity<Nov>(entity =>
           {
               entity.HasNoKey();
               entity.ToSqlQuery("sp_NovStats");
               entity.Property(v => v.Total).HasColumnName("Total");

           });
                modelBuilder
           .Entity<Dec>(entity =>
           {
               entity.HasNoKey();
               entity.ToSqlQuery("sp_DecStats");
               entity.Property(v => v.Total).HasColumnName("Total");

           });

                //for 2021 approved appointments

                modelBuilder
        .Entity<JR>(entity =>
        {
            entity.HasNoKey();
            entity.ToSqlQuery("sp_JanAppr");
            entity.Property(v => v.Total).HasColumnName("Total");

        });
                modelBuilder
         .Entity<FR>(entity =>
         {
             entity.HasNoKey();
             entity.ToSqlQuery("sp_FebAppr");
             entity.Property(v => v.Total).HasColumnName("Total");

         });
                modelBuilder
         .Entity<MR>(entity =>
         {
             entity.HasNoKey();
             entity.ToSqlQuery("sp_MarAppr");
             entity.Property(v => v.Total).HasColumnName("Total");

         });
                modelBuilder
         .Entity<AR>(entity =>
         {
             entity.HasNoKey();
             entity.ToSqlQuery("sp_AprAppr");
             entity.Property(v => v.Total).HasColumnName("Total");

         });
                modelBuilder
        .Entity<MA>(entity =>
        {
            entity.HasNoKey();
            entity.ToSqlQuery("sp_MayAppr");
            entity.Property(v => v.Total).HasColumnName("Total");

        });
                modelBuilder
                   .Entity<JU>(entity =>
                   {
                       entity.HasNoKey();
                       entity.ToSqlQuery("sp_JunAppr");
                       entity.Property(v => v.Total).HasColumnName("Total");

                   });
                modelBuilder
       .Entity<JL>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_JulAppr");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
                modelBuilder
       .Entity<AU>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_AugAppr");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
                modelBuilder
       .Entity<SE>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_SepAppr");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
                modelBuilder
                   .Entity<OC>(entity =>
                   {
                       entity.HasNoKey();
                       entity.ToSqlQuery("sp_OctAppr");
                       entity.Property(v => v.Total).HasColumnName("Total");

                   });
                modelBuilder
       .Entity<NO>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_NovAppr");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
                modelBuilder
       .Entity<DE>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_DecAppr");
           entity.Property(v => v.Total).HasColumnName("Total");

       });

                //2021 cancelled appointments

                modelBuilder
        .Entity<JA>(entity =>
        {
            entity.HasNoKey();
            entity.ToSqlQuery("sp_JanC");
            entity.Property(v => v.Total).HasColumnName("Total");

        });
                modelBuilder
         .Entity<FE>(entity =>
         {
             entity.HasNoKey();
             entity.ToSqlQuery("sp_FebC");
             entity.Property(v => v.Total).HasColumnName("Total");

         });
                modelBuilder
         .Entity<MAR>(entity =>
         {
             entity.HasNoKey();
             entity.ToSqlQuery("sp_MarC");
             entity.Property(v => v.Total).HasColumnName("Total");

         });
                modelBuilder
         .Entity<AP>(entity =>
         {
             entity.HasNoKey();
             entity.ToSqlQuery("sp_AprC");
             entity.Property(v => v.Total).HasColumnName("Total");

         });
                modelBuilder
        .Entity<MY>(entity =>
        {
            entity.HasNoKey();
            entity.ToSqlQuery("sp_MayC");
            entity.Property(v => v.Total).HasColumnName("Total");

        });
                modelBuilder
                   .Entity<JN>(entity =>
                   {
                       entity.HasNoKey();
                       entity.ToSqlQuery("sp_JunC");
                       entity.Property(v => v.Total).HasColumnName("Total");

                   });
                modelBuilder
       .Entity<JUL>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_JulC");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
                modelBuilder
       .Entity<AUGU>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_AugC");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
                modelBuilder
       .Entity<SEPT>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_SepC");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
                modelBuilder
                   .Entity<OCT>(entity =>
                   {
                       entity.HasNoKey();
                       entity.ToSqlQuery("sp_OctC");
                       entity.Property(v => v.Total).HasColumnName("Total");

                   });
                modelBuilder
       .Entity<NOV>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_NovC");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
                modelBuilder
       .Entity<DEC>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_DecC");
           entity.Property(v => v.Total).HasColumnName("Total");

       });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
