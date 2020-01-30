using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.Documents.SpreadsheetStreaming;
using TelerikBlazorNDCApp.Models;

namespace TelerikBlazorNDCApp.Services
{
    public class XlsxExportService
    {
        public byte[] Export(IEnumerable<Attendee> source)
        {
            MemoryStream stream = new MemoryStream();

            double[] columnWidths = new double[] { 4.22, 28.56, 16.11, 17.22, 39.11, 11.67, 9.56, 14.22 };

            using (IWorkbookExporter workbookExporter = SpreadExporter.CreateWorkbookExporter(SpreadDocumentFormat.Xlsx, stream))
            {
                SpreadCellStyle titleStyle = workbookExporter.CellStyles["Heading 1"];
                SpreadCellFormat titleFormat = new SpreadCellFormat()
                {
                    CellStyle = titleStyle
                };

                using (IWorksheetExporter worksheetExporter = workbookExporter.CreateWorksheetExporter("Attendee information"))
                {
                    for (int i = 0; i < columnWidths.Length; i++)
                    {
                        using (IColumnExporter columnExporter = worksheetExporter.CreateColumnExporter())
                        {
                            columnExporter.SetWidthInCharacters(columnWidths[i]);
                        }
                    }

                    ExportRow(worksheetExporter, "Id", "CompanyName", "ContactName", "ContactTitle", "Address", "Country", "Phone", "City", titleFormat);

                    foreach (Attendee attendee in source.Take(10000))
                    {
                        ExportRow(worksheetExporter, attendee.Id.ToString(), attendee.CompanyName, attendee.ContactName, attendee.ContactTitle, attendee.Address, attendee.Country, attendee.Phone, attendee.City);
                    }
                }
            }

            return stream.ToArray();
        }

        private void ExportRow(IWorksheetExporter worksheetExporter, string id, string companyName, string contactName,
            string contactTitle, string address, string country, string phone, string city, SpreadCellFormat titleFormat = null)
        {

            using (IRowExporter rowExporter = worksheetExporter.CreateRowExporter())
            {
                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(id);
                    if (titleFormat != null)
                    {
                        cellExporter.SetFormat(titleFormat);
                    }
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(companyName);
                    if (titleFormat != null)
                    {
                        cellExporter.SetFormat(titleFormat);
                    }
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(contactName);
                    if (titleFormat != null)
                    {
                        cellExporter.SetFormat(titleFormat);
                    }
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(contactTitle);
                    if (titleFormat != null)
                    {
                        cellExporter.SetFormat(titleFormat);
                    }
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(address);
                    if (titleFormat != null)
                    {
                        cellExporter.SetFormat(titleFormat);
                    }
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(city);
                    if (titleFormat != null)
                    {
                        cellExporter.SetFormat(titleFormat);
                    }
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(country);
                    if (titleFormat != null)
                    {
                        cellExporter.SetFormat(titleFormat);
                    }
                }

                using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                {
                    cellExporter.SetValue(phone);
                    if (titleFormat != null)
                    {
                        cellExporter.SetFormat(titleFormat);
                    }
                }
            }
        }
    }
}
