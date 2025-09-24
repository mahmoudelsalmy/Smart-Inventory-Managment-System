using ClosedXML.Excel;
using Inventory_Managment_System_Project.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace Inventory_Managment_System_Project.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        MyContext _context = new MyContext();


        public IActionResult Reports()
        {
            var data = _context.Products
                .Include(p => p.Category)
                .Include(p => p.OrderItems)
                    .ThenInclude(o => o.Order)
                .Select(static p => new Report
                {
                    TotalRevenue = (int?)(p.OrderItems.Sum(o => (double?)o.TotalAmount) ?? 0),
                    ProductId = p.ProductId,
                    ProductName = p.Name,
                    CategoryName = p.Category.CategoryName,
                    Stock = (int)p.Stock,
                    Price = (decimal)p.Price,
                    TotalOrders = p.OrderItems.Count(),
                    UserName = p.OrderItems
                                .Select(o => o.Order.User.Username)
                                .FirstOrDefault()
                }).ToList();

            return View(data);
        }


        public IActionResult ExportExcel()
        {
            var data = GetReportData(); 

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Report");
                worksheet.Cell(1, 1).InsertTable(data);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Report.xlsx");
                }
            }
        }

        private List<Report> GetReportData()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.OrderItems)
                    .ThenInclude(o => o.Order)
                .Select(p => new Report
                {
                    TotalRevenue = (int?)(_context.Orders.Sum(o => (double?)o.TotalAmount) ?? 0),
                    ProductId = p.ProductId,
                    ProductName = p.Name,
                    CategoryName = p.Category.CategoryName,
                    Stock = (int)p.Stock,
                    Price = (decimal)p.Price,
                    TotalOrders = p.OrderItems.Count(),
                    UserName = p.OrderItems
                                .Select(o => o.Order.User.Username)
                                .FirstOrDefault()
                }).ToList();
        }

        public IActionResult ExportPdf()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var data = GetReportData();

                // إنشاء ملف PDF
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(pdfDoc, stream).CloseStream = false;
                pdfDoc.Open();

                // عنوان التقرير
                pdfDoc.Add(new Paragraph("Product Report"));
                pdfDoc.Add(new Paragraph(" ")); // سطر فاضي

                // عمل جدول بعدد الأعمدة
                PdfPTable table = new PdfPTable(8); //  8 أعمدة
                table.WidthPercentage = 100;

                // الهيدر
                table.AddCell("Product ID");
                table.AddCell("Product Name");
                table.AddCell("Category");
                table.AddCell("Quantity");
                table.AddCell("Price");
                table.AddCell("Total Orders");
                table.AddCell("Total Shipments");
                table.AddCell("User");

                // البيانات
                foreach (var item in data)
                {
                    table.AddCell(item.ProductId.ToString());
                    table.AddCell(item.ProductName);
                    table.AddCell(item.CategoryName);
                    table.AddCell(item.Stock.ToString());
                    table.AddCell(item.Price?.ToString("F2"));
                    table.AddCell(item.TotalOrders.ToString());
                    table.AddCell(item.TotalRevenue.ToString());
                    table.AddCell(item.UserName ?? "-");
                }

                // إضافة الجدول للملف
                pdfDoc.Add(table);

                // إنهاء الملف
                pdfDoc.Close();

                byte[] bytes = stream.ToArray();
                return File(bytes, "application/pdf", "Report.pdf");
            }
        }



    }
}
