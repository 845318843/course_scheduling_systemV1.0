using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System;

namespace DAL
{
    public static class NPOI
    {
        static IWorkbook hssfworkbook;
        public static void DtToExcel(DataTable dt, string FileName)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    SaveFileDialog dlg = new SaveFileDialog();//申请保存对话框
                    dlg.Filter = "Excel文件|*.xls";
                    dlg.FileName = FileName;//默认文件名称
                    if (dlg.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    dlg.InitialDirectory = Directory.GetCurrentDirectory();//返回文件路径
                    string filename = dlg.FileName;//输出的文件名
                    if (filename.Trim() == "")//验证strFileName是否为空或值无效
                        return;

                    hssfworkbook = new HSSFWorkbook();//实例化
                    ISheet sheet = hssfworkbook.CreateSheet("Sheet1");

                    int colsCount = dt.Columns.Count;//定义表格内数据的列数
                    ArrayList arr = new ArrayList();//存储头信息
                    ICellStyle cstyle = hssfworkbook.CreateCellStyle();
                    IRow rowHeader = sheet.CreateRow(0);//创建列头数据  
                    int displayColumnsCount = 0;//用于处理隐藏列头不被显示           

                    HSSFFont hssffont = hssfworkbook.CreateFont() as HSSFFont;
                    hssffont.FontHeightInPoints = 11;

                    //设置单元格边框   
                    for (int i = 0; i < dt.Columns.Count; i++)//生成表头信息  
                    {
                        ICell cell = rowHeader.CreateCell(displayColumnsCount);
                        cell.SetCellValue(dt.Columns[i].ToString());
                        sheet.SetColumnWidth(displayColumnsCount, 17 * 256);
                        displayColumnsCount++;
                        arr.Add(dt.Columns[i].ToString());
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IRow irow = sheet.CreateRow(i + 1);
                        for (int j = 0; j < dt.Columns.Count - 1; j++)
                        {
                            ICell cell = irow.CreateCell(j);
                            cell.SetCellValue(dt.Rows[i][j].ToString());
                        }
                    }
                    using (Stream stream = File.OpenWrite(filename))
                    {
                        hssfworkbook.Write(stream);
                        MessageBox.Show(filename + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("没有数据可供导出", "提示");
                }
            }
            catch
            {
                MessageBox.Show("操作失败", "提示");
            }
        }
    }
}
           