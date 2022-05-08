using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softtech.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Students funded by Nsfas in 2021
            var j = @"CREATE PROCEDURE sp_JanAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-01-01' AND '2021-01-31'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(j);
            var f = @"CREATE PROCEDURE sp_FebAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-02-01' AND '2021-02-28'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(f);
            var m = @"CREATE PROCEDURE sp_MarAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-03-01' AND '2021-03-31'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(m);
            var ap = @"CREATE PROCEDURE sp_AprAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-04-01' AND '2021-04-30'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(ap);
            var ma = @"CREATE PROCEDURE sp_MayAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-05-01' AND '2021-05-31'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(ma);
            var ju = @"CREATE PROCEDURE sp_JunAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-06-01' AND '2021-06-30'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(ju);
            var jul = @"CREATE PROCEDURE sp_JulAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-07-01' AND '2021-07-31'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(jul);
            var a = @"CREATE PROCEDURE sp_AugAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-08-01' AND '2021-08-31'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(a);
            var s = @"CREATE PROCEDURE sp_SepAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-09-01' AND '2021-09-30'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(s);
            var o = @"CREATE PROCEDURE sp_OctAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-10-01' AND '2021-10-31'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(o);
            var n = @"CREATE PROCEDURE sp_NovAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-11-01' AND '2021-11-30'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(n);
            var d = @"CREATE PROCEDURE sp_DecAppr
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-12-01' AND '2021-12-31'  AND StudentFundedBy = 'NSFAS'
                          END";
            migrationBuilder.Sql(d);

            //Students funded py a private bursary in 2021

            var q = @"CREATE PROCEDURE sp_JanC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-01-01' AND '2021-01-31'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(q);
            var w = @"CREATE PROCEDURE sp_FebC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-02-01' AND '2021-02-28'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(w);
            var e = @"CREATE PROCEDURE sp_MarC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-03-01' AND '2021-03-31'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(e);
            var r = @"CREATE PROCEDURE sp_AprC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-04-01' AND '2021-04-30'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(r);
            var t = @"CREATE PROCEDURE sp_MayC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-05-01' AND '2021-05-31'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(t);
            var y = @"CREATE PROCEDURE sp_JunC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-06-01' AND '2021-06-30'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(y);
            var u = @"CREATE PROCEDURE sp_JulC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-07-01' AND '2021-07-31'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(u);
            var i = @"CREATE PROCEDURE sp_AugC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-08-01' AND '2021-08-31'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(i);
            var p = @"CREATE PROCEDURE sp_SepC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-09-01' AND '2021-09-30'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(p);
            var g = @"CREATE PROCEDURE sp_OctC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-10-01' AND '2021-10-31'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(g);
            var h = @"CREATE PROCEDURE sp_NovC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-11-01' AND '2021-11-30'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(h);
            var k = @"CREATE PROCEDURE sp_DecC
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-12-01' AND '2021-12-31'  AND StudentFundedBy = 'Private Bursary'
                          END";
            migrationBuilder.Sql(k);

            //appointments made in 2021

            var sqler = @"CREATE PROCEDURE sp_JanStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-01-01' AND '2021-01-31'
                      END";
            migrationBuilder.Sql(sqler);
            var sqle = @"CREATE PROCEDURE sp_FebStats
                            AS
                           BEGIN
                          SET NOCOUNT ON;
                          SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-02-01' AND '2021-02-28'
                          END";
            migrationBuilder.Sql(sqle);
            var sql = @"CREATE PROCEDURE sp_MarStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-03-01' AND '2021-03-31'
                      END";
            migrationBuilder.Sql(sql);

            var sq = @"CREATE PROCEDURE sp_AprStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-04-01' AND '2021-04-30'
                      END";
            migrationBuilder.Sql(sq);

            var data = @"CREATE PROCEDURE sp_MaybStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-05-01' AND '2021-05-31'
                      END";
            migrationBuilder.Sql(data);

            var dat = @"CREATE PROCEDURE sp_JunStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-06-01' AND '2021-06-30'
                      END";
            migrationBuilder.Sql(dat);

            var inf = @"CREATE PROCEDURE sp_JulStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-07-01' AND '2021-07-31'
                      END";
            migrationBuilder.Sql(inf);

            var x = @"CREATE PROCEDURE sp_AugStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-08-01' AND '2021-08-30'
                      END";
            migrationBuilder.Sql(x);

            var ik = @"CREATE PROCEDURE sp_SeptStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-09-01' AND '2021-09-30'
                      END";
            migrationBuilder.Sql(ik);

            var sk = @"CREATE PROCEDURE sp_OctStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-10-01' AND '2021-10-31'
                      END";
            migrationBuilder.Sql(sk);

            var nk = @"CREATE PROCEDURE sp_NovStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-11-01' AND '2021-11-30'
                      END";
            migrationBuilder.Sql(nk);

            var dec = @"CREATE PROCEDURE sp_DecStats
                        AS
                       BEGIN
                      SET NOCOUNT ON;
                      SELECT COUNT(*)AS Total FROM TblBookings WHERE Date BETWEEN '2021-12-01' AND '2021-12-31'
                      END";
            migrationBuilder.Sql(dec);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCities",
                columns: table => new
                {
                    CityId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "tblClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblRooms",
                columns: table => new
                {
                    RoomId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    RoomNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "TblRoomTypes",
                columns: table => new
                {
                    RoomTypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRoomTypes", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextOfKinFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextOfKinLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TblCityCityId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TblCities_TblCityCityId",
                        column: x => x.TblCityCityId,
                        principalTable: "TblCities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TblRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "TblRooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblBookings",
                columns: table => new
                {
                    BookingId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    RoomTypeId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentFundedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BursaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsAndConditions = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_TblBookings_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblBookings_TblRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "TblRooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblBookings_TblRoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "TblRoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblDeposits",
                columns: table => new
                {
                    DepositId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDeposits", x => x.DepositId);
                    table.ForeignKey(
                        name: "FK_TblDeposits_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblFaults",
                columns: table => new
                {
                    FaultId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFaults", x => x.FaultId);
                    table.ForeignKey(
                        name: "FK_TblFaults_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblFaults_TblRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "TblRooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblFines",
                columns: table => new
                {
                    FineId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonOfCharge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFines", x => x.FineId);
                    table.ForeignKey(
                        name: "FK_TblFines_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblInspections",
                columns: table => new
                {
                    InspectionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CheckPdfUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInspections", x => x.InspectionId);
                    table.ForeignKey(
                        name: "FK_TblInspections_AspNetUsers_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblInspections_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblInspections_TblRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "TblRooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblPayments",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountPaid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPayments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_TblPayments_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblVisitors",
                columns: table => new
                {
                    VisitorId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeOut = table.Column<TimeSpan>(type: "time", nullable: false),
                    VisiteeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVisitors", x => x.VisitorId);
                    table.ForeignKey(
                        name: "FK_TblVisitors_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoomId",
                table: "AspNetUsers",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TblCityCityId",
                table: "AspNetUsers",
                column: "TblCityCityId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookings_RoomId",
                table: "TblBookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookings_RoomTypeId",
                table: "TblBookings",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookings_StudentId",
                table: "TblBookings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDeposits_StudentId",
                table: "TblDeposits",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblFaults_RoomId",
                table: "TblFaults",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TblFaults_StudentId",
                table: "TblFaults",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblFines_StudentId",
                table: "TblFines",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInspections_InspectorId",
                table: "TblInspections",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInspections_RoomId",
                table: "TblInspections",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInspections_StudentId",
                table: "TblInspections",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPayments_StudentId",
                table: "TblPayments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblVisitors_StudentId",
                table: "TblVisitors",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AP");

            migrationBuilder.DropTable(
                name: "Apr");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AU");

            migrationBuilder.DropTable(
                name: "Aug");

            migrationBuilder.DropTable(
                name: "AUGU");

            migrationBuilder.DropTable(
                name: "DE");

            migrationBuilder.DropTable(
                name: "Dec");

            migrationBuilder.DropTable(
                name: "DEC");

            migrationBuilder.DropTable(
                name: "FE");

            migrationBuilder.DropTable(
                name: "Feb");

            migrationBuilder.DropTable(
                name: "FR");

            migrationBuilder.DropTable(
                name: "JA");

            migrationBuilder.DropTable(
                name: "Jan");

            migrationBuilder.DropTable(
                name: "JL");

            migrationBuilder.DropTable(
                name: "JN");

            migrationBuilder.DropTable(
                name: "JR");

            migrationBuilder.DropTable(
                name: "JU");

            migrationBuilder.DropTable(
                name: "Jul");

            migrationBuilder.DropTable(
                name: "JUL");

            migrationBuilder.DropTable(
                name: "Jun");

            migrationBuilder.DropTable(
                name: "Mar");

            migrationBuilder.DropTable(
                name: "MAR");

            migrationBuilder.DropTable(
                name: "May");

            migrationBuilder.DropTable(
                name: "MR");

            migrationBuilder.DropTable(
                name: "MY");

            migrationBuilder.DropTable(
                name: "NO");

            migrationBuilder.DropTable(
                name: "Nov");

            migrationBuilder.DropTable(
                name: "NOV");

            migrationBuilder.DropTable(
                name: "OC");

            migrationBuilder.DropTable(
                name: "Oct");

            migrationBuilder.DropTable(
                name: "OCT");

            migrationBuilder.DropTable(
                name: "SE");

            migrationBuilder.DropTable(
                name: "Sep");

            migrationBuilder.DropTable(
                name: "SEPT");

            migrationBuilder.DropTable(
                name: "TblBookings");

            migrationBuilder.DropTable(
                name: "tblClaims");

            migrationBuilder.DropTable(
                name: "TblDeposits");

            migrationBuilder.DropTable(
                name: "TblFaults");

            migrationBuilder.DropTable(
                name: "TblFines");

            migrationBuilder.DropTable(
                name: "TblInspections");

            migrationBuilder.DropTable(
                name: "TblPayments");

            migrationBuilder.DropTable(
                name: "TblVisitors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TblRoomTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TblCities");

            migrationBuilder.DropTable(
                name: "TblRooms");
        }
    }
}
