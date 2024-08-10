using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2013.Word;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public class fImportData
    {
        public void ImportData(string filePath)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1); 
                    
                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        DateTime InputTime;
                        bool isDateTime = DateTime.TryParse(row.Cell(1).Value.ToString(), out InputTime);
                        if(!isDateTime)
                            InputTime = DateTime.Now;
                        else InputTime = DateTime.Parse(row.Cell(1).Value.ToString());

                        DanhSachSinhVien.Instance.ListSinhVien.Add(new SinhVien(
                                                                       InputTime, 
                                                                       row.Cell(2).Value.ToString(),
                                                                       row.Cell(3).Value.ToString(),
                                                                       row.Cell(4).Value.ToString(),
                                                                       DateTime.Parse(row.Cell(5).Value.ToString()),
                                                                       row.Cell(6).Value.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
