using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Entity_Security_Plugin.Models;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace Entity_Security_Plugin.Business
{
    public class ExportExcel
    {
        public string Execute(DataGridView dgv, string entityName)
        {
            DialogResult result = MessageBox.Show("Do you want to export with image?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            List<SecurityPrv> currentListSecPrv = (List<SecurityPrv>) dgv.DataSource;
            if (result == DialogResult.Yes)
            {
                return exportWithImg(dgv, entityName);
            }
            else
            {
                return exportWithStateNo(dgv, entityName, currentListSecPrv);
            }

        }

        public string exportWithImg(DataGridView dgv, string entityName)
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
                                picture.SetPosition(i + 1, 5, j, 21);
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value.ToString();

                            }
                        }
                    }

                    // Save the Excel file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.FilterIndex = 2;
                    saveFileDialog.FileName = entityName + ".xlsx";
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the workbook to the file
                        var file = new FileInfo(saveFileDialog.FileName.Replace(".xlsx", "") + ".xlsx");
                        package.SaveAs(file);
                        return file.FullName;
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string exportWithStateNo(DataGridView dgv, string entityName, List<SecurityPrv> currentListSecPrv)
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
                    for (int i = 0; i < currentListSecPrv.Count; i++)
                    {
                        var secPrv = currentListSecPrv[i];
                        worksheet.Cells[i + 2, 1].Value = secPrv.Role;
                        worksheet.Cells[i + 2, 2].Value = secPrv.CreateValue;
                        worksheet.Cells[i + 2, 3].Value = secPrv.ReadValue;
                        worksheet.Cells[i + 2, 4].Value = secPrv.WriteValue;
                        worksheet.Cells[i + 2, 5].Value = secPrv.DeleteValue;
                        worksheet.Cells[i + 2, 6].Value = secPrv.AppendValue;
                        worksheet.Cells[i + 2, 7].Value = secPrv.AppendToValue;
                        worksheet.Cells[i + 2, 8].Value = secPrv.AssignValue;
                        worksheet.Cells[i + 2, 9].Value = secPrv.ShareValue;
                    }

                    // Save the Excel file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.FilterIndex = 2;
                    saveFileDialog.FileName = entityName + ".xlsx";
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the workbook to the file
                        var file = new FileInfo(saveFileDialog.FileName.Replace(".xlsx", "") + ".xlsx");
                        package.SaveAs(file);
                        return file.FullName;
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



