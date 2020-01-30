using System.Collections.Generic;
using System.IO;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Documents.Spreadsheet.Model;
using TelerikBlazorNDCApp.Models;

namespace TelerikBlazorNDCApp.Services
{
    public class PdfExportService
    {
        public Stream Export(IEnumerable<Attendee> source)
        {
            int rowIndex = 0;

            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets.Add();

            ExportRow(worksheet, rowIndex++, "Id", "CompanyName", "ContactName", "ContactTitle", "Address", "Country", "Phone", "City");

            foreach (Attendee attendee in source)
            {
                ExportRow(worksheet, rowIndex++, attendee.Id.ToString(), attendee.CompanyName, attendee.ContactName, attendee.ContactTitle, attendee.Address, attendee.Country, attendee.Phone, attendee.City);
            }

            PdfFormatProvider pdfFormatProvider = new PdfFormatProvider();

            MemoryStream stream = new MemoryStream();
            pdfFormatProvider.Export(workbook, stream);

            return stream;
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
