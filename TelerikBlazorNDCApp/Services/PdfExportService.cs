using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Documents.Spreadsheet.Model;
using TelerikBlazorNDCApp.Models;

namespace TelerikBlazorNDCApp.Services
{
    public class PdfExportService
    {
        public byte[] Export(IEnumerable<Attendee> source)
        {
            int rowIndex = 0;

            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets.Add();

            ExportRow(worksheet, rowIndex++, "Id", "CompanyName", "ContactName", "ContactTitle", "Address", "Country", "Phone", "City");
            worksheet.Cells[0, 0, 0, 8].SetStyleName("Heading 1");

            foreach (Attendee attendee in source.Take(500))
            {
                ExportRow(worksheet, rowIndex++, attendee.Id.ToString(), attendee.CompanyName, attendee.ContactName, attendee.ContactTitle, attendee.Address, attendee.Country, attendee.Phone, attendee.City);
            }

            worksheet.Columns[0, 8].AutoFitWidth();

            PdfFormatProvider pdfFormatProvider = new PdfFormatProvider();

            byte[] byteArray = pdfFormatProvider.Export(workbook);

            return byteArray;
        }

        private void ExportRow(Worksheet worksheet, int rowIndex, string id, string companyName, string contactName,
            string contactTitle, string address, string country, string phone, string city)
        {
            int columnIndex = 0;
            worksheet.Cells[rowIndex, columnIndex++].SetValueAsText(id);
            worksheet.Cells[rowIndex, columnIndex++].SetValueAsText(companyName);
            worksheet.Cells[rowIndex, columnIndex++].SetValueAsText(contactName);
            worksheet.Cells[rowIndex, columnIndex++].SetValueAsText(contactTitle);
            worksheet.Cells[rowIndex, columnIndex++].SetValueAsText(address);
            worksheet.Cells[rowIndex, columnIndex++].SetValueAsText(city);
            worksheet.Cells[rowIndex, columnIndex++].SetValueAsText(country);
            worksheet.Cells[rowIndex, columnIndex++].SetValueAsText(phone);
        }
    }
}
