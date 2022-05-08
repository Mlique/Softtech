using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using Softtech.Repositories;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    public class FaultsController : BaseController
    {
        private readonly ResManagementDBContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFaultRepository repository;

        public FaultsController(ResManagementDBContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment, IFaultRepository repository)
        {
            this.context = context;
            this.userManager = userManager;
            _webHostEnvironment = hostEnvironment;
            this.repository = repository;
        }


        public IActionResult ListOfFaults()
        {
            var data = context.TblFaults.Include(s => s.Room).Include(a => a.Student).AsNoTracking();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> AddFaults(string id = null)
        {
            if (id == null)
            {
                PopulateRoomDropDownList();
                return View(new FaultViewModel());
            }
            else
            {
                PopulateRoomDropDownList();
                var inspec = await context.TblInspections.FindAsync(id);
                if (inspec == null)
                {
                    return NotFound();
                }
                return View(inspec);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFaults(string id, FaultViewModel model)
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            PopulateRoomDropDownList();
            if (ModelState.IsValid)
            {
                PopulateRoomDropDownList();
                var faults = context.TblFaults.Find(id);

                if (id == null)
                {
                    try
                    {
                        if (model.PdfFile != null)
                        {
                            string folder = "Faultlist/pdf/";
                            model.DocumentPath = await UploadImage(folder, model.PdfFile);
                        }
                        if (model.StudentId == null)
                        {
                            model.StudentId = currentUser.Id;
                        }
                        PopulateRoomDropDownList(model.RoomId);
                        await repository.AddNew(model);
                        Notify("Your fault has been launch successfully");
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
                        model.ReportDate = DateTime.Now;
                        model.RoomId = faults.RoomId;
                        model.StudentId = faults.StudentId;

                        PopulateRoomDropDownList(model.FaultId);
                        context.Update(model);
                        await context.SaveChangesAsync();
                        Notify("Fault has been attended");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(model.FaultId))
                        {
                            return NotFound();
                        }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(StudentsController.Index), "Students");
            }
            return View(model);
        }
        private bool ModelExists(string id)
        {
            return context.TblFaults.Any(e => e.FaultId == id);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fault = await context.TblFaults
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.FaultId == id);
            if (fault == null)
            {
                return NotFound();
            }
            return View(fault);
        }
        public IActionResult Delete(string Id)
        {
            TblFault fault = context.TblFaults.Find(Id);
            if (fault != null)
            {
                context.TblFaults.Remove(fault);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(fault);
        }
        private void PopulateRoomDropDownList(object selectedRoom = null)
        {
            var roomQuery = from d in context.TblRooms
                            orderby d.RoomNo
                            select d;
            ViewBag.RoomId = new SelectList(roomQuery.AsNoTracking(), "RoomId", "RoomNo",
            selectedRoom);
        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
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
            PdfPTable tableLayout = new PdfPTable(4);
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

            float[] headers = { 40, 50, 50, 40};  //Header Widths
            tableLayout.SetWidths(headers);        //Set the pdf headers
            tableLayout.WidthPercentage = 100;       //Set the PDF File witdh percentage
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top

            List<TblFault> faults = context.TblFaults
                .Include(s => s.Room)
                .Include(a => a.Student)
                .ToList<TblFault>();


            tableLayout.AddCell(new PdfPCell(new Phrase("Soft Tech\nGomery 767 Rd\nSummerStrand\nPort Elizabeth\nEastern Cape\n\nTell: 0839133030\nEmail: RMS09@softtech.com", new Font(Font.HELVETICA, 12, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_LEFT });
            tableLayout.AddCell(new PdfPCell(new Phrase("Date: " + printedDate, new Font(Font.HELVETICA, 12, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
            tableLayout.AddCell(new PdfPCell(new Phrase("Fault Report", new Font(Font.HELVETICA, 16, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });




            tableLayout.AddCell(new PdfPCell(new Phrase("Hope Corner \n Res Crew", new Font(Font.HELVETICA, 14, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });


            ////Add header

            AddCellToHeader(tableLayout, "Description");
            AddCellToHeader(tableLayout, "Report Date");
            AddCellToHeader(tableLayout, "Room");
            AddCellToHeader(tableLayout, "Student");


            ////Add body

            foreach (var emp in faults)
            {

                AddCellToBody(tableLayout, emp.Description + "\n\n");
                AddCellToBody(tableLayout, emp.ReportDate + "\n\n");
                AddCellToBody(tableLayout, emp.Room.RoomNo + "\n\n");
                AddCellToBody(tableLayout, emp.Student.FullName + "\n\n");

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