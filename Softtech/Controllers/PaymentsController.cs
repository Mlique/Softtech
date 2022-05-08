using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class PaymentsController : BaseController
    {
        private readonly ResManagementDBContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPaymentRepository repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PaymentsController(ResManagementDBContext context, UserManager<ApplicationUser> userManager, IPaymentRepository repository, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.userManager = userManager;
            this.repository = repository;
            _webHostEnvironment = hostEnvironment;
        }
        public IActionResult ViewDetails(string id)
        {
            var app = context.TblPayments.Find(id);

            return View(app);
        }
        public IActionResult ListOfPayments()
        {
            var payList = context.TblPayments.Include(p => p.Student).AsNoTracking();
            return View(payList);
        }
        [HttpGet]
        public async Task<IActionResult> AddPayments(string id = null)
        {
            if (id == null)
            {
                return View(new PaymentViewModel());
            }
            else
            {
                var payment = await context.TblPayments.FindAsync(id);
                if (payment == null)
                {
                    return NotFound();
                }
                return View(payment);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPayments(string id, PaymentViewModel model)
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                var payment = context.TblPayments.Find(id);

                if (id == null)
                {
                    try
                    {
                        if (model.ProofOfPayPdf != null)
                        {
                            string folder = "paymentlist/pdf/";
                            model.DocumentPath = await UploadImage(folder, model.ProofOfPayPdf);
                        }
                        if (model.StudentId == null)
                        {
                            model.StudentId = currentUser.Id;
                        }
                        await repository.AddNew(model);
                        Notify("Your proof of payment was uploaded successfully");
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
                        model.Date = payment.Date;
                        model.AmountPaid = payment.AmountPaid;
                        model.StudentId = payment.StudentId;

                        context.Update(model);
                        await context.SaveChangesAsync();
                        Notify("Your payment has been recieved");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(model.PaymentId))
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
            return context.TblPayments.Any(e => e.PaymentId == id);
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

            List<TblPayment> payments = context.TblPayments
                .Include(a => a.Student)
                .ToList<TblPayment>();


            tableLayout.AddCell(new PdfPCell(new Phrase("Soft Tech\nGomery 767 Rd\nSummerStrand\nPort Elizabeth\nEastern Cape\n\nTell: 0839133030\nEmail: RMS09@softtech.com", new Font(Font.HELVETICA, 12, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_LEFT });
            tableLayout.AddCell(new PdfPCell(new Phrase("Date: " + printedDate, new Font(Font.HELVETICA, 12, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
            tableLayout.AddCell(new PdfPCell(new Phrase("Payments Report", new Font(Font.HELVETICA, 16, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });




            tableLayout.AddCell(new PdfPCell(new Phrase("Hope Corner \n Res Payments", new Font(Font.HELVETICA, 14, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });


            ////Add header

            AddCellToHeader(tableLayout, "Amount Paid");
            AddCellToHeader(tableLayout, "Balance ");
            AddCellToHeader(tableLayout, "Reference");
            AddCellToHeader(tableLayout, "Student");
            AddCellToHeader(tableLayout, "Admin");
            AddCellToHeader(tableLayout, "Document");
            AddCellToHeader(tableLayout, "Image");


            ////Add body

            foreach (var emp in payments)
            {

                AddCellToBody(tableLayout, emp.AmountPaid + "\n\n");
                AddCellToBody(tableLayout, emp.Balance + "\n\n");
                AddCellToBody(tableLayout, emp.Reference + "\n\n");
                AddCellToBody(tableLayout, emp.Student.FullName + "\n\n");
                AddCellToBody(tableLayout, emp.DocumentPath + "\n\n");
                AddCellToBody(tableLayout, emp.ImagePath + "\n\n");


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
