using System.Collections.Generic;
using System.IO;
using Telerik.Documents.SpreadsheetStreaming;
using TelerikBlazorNDCApp.Models;

namespace TelerikBlazorNDCApp.Services
{
    public class XlsxExportService
    {
        public Stream Export(IEnumerable<Attendee> source)
        {
            MemoryStream stream = new MemoryStream();

            using (IWorkbookExporter workbookExporter = SpreadExporter.CreateWorkbookExporter(SpreadDocumentFormat.Xlsx, stream))
            {
                using (IWorksheetExporter worksheetExporter = workbookExporter.CreateWorksheetExporter("Attendee information"))
                {
                    ExportRow(worksheetExporter, "Id", "CompanyName", "ContactName", "ContactTitle", "Address", "Country", "Phone", "City");

                    foreach (Attendee attendee in source)
                    {
                        ExportRow(worksheetExporter, attendee.Id.ToString(), attendee.CompanyName, attendee.ContactName, attendee.ContactTitle, attendee.Address, attendee.Country, attendee.Phone, attendee.City);
                    }
                }
            }

            return stream;
        }

        private void ExportRow(IWorksheetExporter worksheetExporter, string id, string companyName, string contactName,
            string contactTitle, string address, string country, string phone, string city)
        {
            using (IRowExporter rowExporter = worksheetExporter.CreateRowExporter())
            {
                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(id);
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(companyName);
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(contactName);
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(contactTitle);
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(address);
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(city);
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(country);
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(phone);
                }
            }
        }
    }
}
