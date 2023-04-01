using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace Entity_Security_Plugin.Business
{
    public class ExportExcel
    {
        public string Execute(DataGridView dgv)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    // Add a new worksheet to the workbook
                    var worksheet = package.Workbook.Worksheets.Add("Roles");

                    // Write the headers to the worksheet
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
                    }

                    // Write the data rows to the worksheet
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            if (dgv.Rows[i].Cells[j].Value is Bitmap)
                            {
                                MemoryStream stream = new MemoryStream();
                                Bitmap bitmap = (Bitmap)dgv.Rows[i].Cells[j].Value;
                                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                                // Create a new MemoryStream object from the byte array
                                MemoryStream imageStream = new MemoryStream(stream.ToArray());
                                ExcelPicture picture = worksheet.Drawings.AddPicture("img_" + i + "_" + j + "", imageStream);
                                // Calculate the position of the top left corner of the cell
                                picture.SetPosition(i +1 , 5, j , 21);
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value.ToString();

                            }
                        }
                    }

                    // Save the Excel file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 2;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the workbook to the file
                        var file = new FileInfo(saveFileDialog.FileName.Replace(".xlsx","") + ".xlsx");
                        package.SaveAs(file);
                        return  file.FullName;
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}



