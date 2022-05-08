using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    [Authorize(Roles = "Receptionist, Security")]
    public class VisitorsController : BaseController
    {
        private readonly ResManagementDBContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public VisitorsController(ResManagementDBContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
       
        public async Task<IActionResult> Index()
        {
            var vist = await context.TblVisitors.CountAsync();
            ViewBag.ListCount = vist;

            var roomV = context.TblRooms;

            var studeVisitors = context.TblVisitors
                .Where(d => d.RoomId == d.StudentId)
                .Count();
            ViewBag.ListRoomCount = vist;

            var visitorList = context.TblVisitors.Include(a => a.Room).Include(b => b.Student).AsNoTracking();
            return View(visitorList);
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(VisitorsViewModel model, string id = null)
        {
            if (id == null)
            {
                PopulateRoomDropDownList();
                var studList = await GetStudentsListItemsAsync();
                model.Students = studList;
                return View(model);
            }
            else
            {
                PopulateRoomDropDownList();
                var studList = await GetStudentsListItemsAsync();
                model.Students = studList;
                var visitors = await context.TblVisitors.FindAsync(id);

                if (visitors != null)
                {
                    model.Date = visitors.Date;
                    model.FullName = visitors.FullName;
                    model.TimeIn = visitors.TimeIn;
                    model.TimeOut = visitors.TimeOut;
                    model.RoomNo = visitors.RoomId;
                    model.VisiteeName = visitors.StudentId;
                }
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, VisitorsViewModel model)
        {
            PopulateRoomDropDownList();
            var studList = await GetStudentsListItemsAsync();
            model.Students = studList;
            if (ModelState.IsValid)
            {
                var vis = context.TblVisitors.Find(id);
                if (id == null)
                {
                    try
                    {
                        var visitor = new TblVisitor
                        {
                            TimeIn = model.TimeIn,
                            TimeOut = model.TimeOut,
                            Date = DateTime.Now,
                            RoomId = model.RoomNo,
                            StudentId = model.VisiteeName,
                            FullName = model.FullName
                        };
                        PopulateRoomDropDownList(visitor.RoomId);
                        context.Add(visitor);
                        await context.SaveChangesAsync();
                        Notify("Your visitor was successfully");
                    }
                    catch (Exception)
                    {
                        Notify("Something went wrong please you provided all necessary info", notificationType: NotificationType.error);
                        return View();
                    }
                }
                else
                {
                    try
                    {
                        vis.TimeIn = model.TimeIn;
                        vis.Date = model.Date;
                        vis.TimeOut = model.TimeOut;
                        vis.RoomId = model.RoomNo;
                        vis.StudentId = model.VisiteeName;
                        vis.FullName = model.FullName;

                        PopulateRoomDropDownList(vis.RoomId);
                        context.Update(vis);
                        await context.SaveChangesAsync();
                        Notify("Visitor has been check out successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(model.VisitorId))
                        {
                            return NotFound();
                        }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(VisitorsController.Index), "Visitors");
            }
            return View(model);
        }
        [HttpGet]
        private async Task<IEnumerable<SelectListItem>> GetStudentsListItemsAsync()
        {
            List<ViewModelUserRole> students = new List<ViewModelUserRole>();
            var student = await userManager.GetUsersInRoleAsync("Student");
            var studentList = student.Select(stud => new SelectListItem
            {
                Text = stud.LastName,
                Value = stud.Id
            })
            .ToList();

            return studentList;
        }
        private bool ModelExists(string id)
        {
            return context.TblVisitors.Any(e => e.VisitorId == id);
        }
        private void PopulateRoomDropDownList(object selectedRoom = null)
        {
            var roomQuery = from d in context.TblRooms
                            orderby d.RoomNo
                            select d;
            ViewBag.RoomId = new SelectList(roomQuery.AsNoTracking(), "RoomId", "RoomNo",
            selectedRoom);
        }

        //----------------------Print PDF District--------------------------
        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created 
            string strPDFFileName = string.Format("SamplePdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns
            PdfPTable tableLayout = new PdfPTable(6);
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table

            //file will created in this path
            //string strAttachment = Report.Load(HttpContext.Current.Server.MapPath("GraduationCertificate.rpt"));


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF 
            doc.Add(Add_Content_To_PDF(tableLayout));

            // Closing the document
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);

        }
        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {
            TimeSpan duration = new TimeSpan(30, 0, 0, 0);
            DateTime printedDate = DateTime.Now.Add(duration);

            float[] headers = { 40, 50, 50, 40, 40, 50 };  //Header Widths
            tableLayout.SetWidths(headers);        //Set the pdf headers
            tableLayout.WidthPercentage = 100;       //Set the PDF File witdh percentage
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top

            List<TblVisitor> visitors = context.TblVisitors
                .Include(s => s.Room)
                .Include(a => a.Student)
                .ToList<TblVisitor>();


            tableLayout.AddCell(new PdfPCell(new Phrase("Soft Tech\nGomery 767 Rd\nSummerStrand\nPort Elizabeth\nEastern Cape\n\nTell: 0839133030\nEmail: RMS09@softtech.com", new Font(Font.HELVETICA, 12, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_LEFT });
            tableLayout.AddCell(new PdfPCell(new Phrase("Date: " + printedDate, new Font(Font.HELVETICA, 12, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
            tableLayout.AddCell(new PdfPCell(new Phrase("Visitor Report", new Font(Font.HELVETICA, 16, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });




            tableLayout.AddCell(new PdfPCell(new Phrase("Hope Corner \n Res Visitors", new Font(Font.HELVETICA, 14, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });


            ////Add header

            AddCellToHeader(tableLayout, "Date");
            AddCellToHeader(tableLayout, "Full Name ");
            AddCellToHeader(tableLayout, "Time In");
            AddCellToHeader(tableLayout, "Time Out");
            AddCellToHeader(tableLayout, "Student");
            AddCellToHeader(tableLayout, "Room");


            ////Add body

            foreach (var emp in visitors)
            {

                AddCellToBody(tableLayout, emp.Date + "\n\n");
                AddCellToBody(tableLayout, emp.FullName + "\n\n");
                AddCellToBody(tableLayout, emp.TimeIn + "\n\n");
                AddCellToBody(tableLayout, emp.TimeOut + "\n\n");
                AddCellToBody(tableLayout, emp.Student.FullName + "\n\n");
                AddCellToBody(tableLayout, emp.Room.RoomNo + "\n\n");

            }

            return tableLayout;
        }

        // Method to add single cell to the Header
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 12, 1, iTextSharp.text.BaseColor.Black))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(204, 204, 255) });
        }

        // Method to add single cell to the body
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 12, 1, iTextSharp.text.BaseColor.Black))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255) });
        }
    }
}

