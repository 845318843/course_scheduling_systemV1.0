using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//相关引用
using MSword = Microsoft.Office.Interop.Word;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Threading;
using Microsoft.Office.Interop.Word;
using System.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;
using BLL;
namespace BLL
{
    public class ToWord
    {
        MSword.Application WordApp;
        MSword.Document WordDoc;
        private object filename = "";
        System.Data.DataTable dt = new System.Data.DataTable();
        public bool CourseTable1(System.Data.DataTable dt, string path, string title)
        {
            try
            {
                string str = "";
                string strtitle = title;
                object oEndOfDoc = "\\endofdoc";
                Object Nothing = System.Reflection.Missing.Value;
                filename = path;
                //如果这个位置  出现异常  将引用里面的    office.interop.word  引用-》属性-》嵌入互操作类型改为  false
                WordApp = new MSword.ApplicationClass();
                WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                WordApp.Visible = false;//设置动态建立的word文档可见
                WordDoc.PageSetup.PaperSize = Microsoft.Office.Interop.Word.WdPaperSize.wdPaperA4;//设置纸张样式
                WordDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;//排列方式为横向方向
                WordApp.Selection.PageSetup.LeftMargin = WordApp.CentimetersToPoints(float.Parse("1"));//设置word文档的左边距
                WordApp.Selection.PageSetup.RightMargin = WordApp.CentimetersToPoints(float.Parse("1"));//设置word文档的右边距
                WordApp.Selection.PageSetup.TopMargin = WordApp.CentimetersToPoints(float.Parse("1"));
                WordApp.Selection.PageSetup.BottomMargin = WordApp.CentimetersToPoints(float.Parse("1"));
                WordApp.ActiveWindow.HorizontalPercentScrolled = 11;//设置文档的水平滑动距离
                WordApp.ActiveWindow.ActivePane.View.Zoom.Percentage = 130;//设置文档的百分比例



                WordDoc.PageSetup.HeaderDistance = 30.0f;//页眉位置

                //设置页眉
                WordApp.ActiveWindow.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdOutlineView;//视图样式
                WordApp.ActiveWindow.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekPrimaryHeader;//进入页眉设置，其中页眉边距在页面设置中已完成
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                //去掉页眉的横线
                WordApp.ActiveWindow.ActivePane.Selection.ParagraphFormat.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleNone;
                WordApp.ActiveWindow.ActivePane.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].Visible = false;
                WordApp.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekMainDocument;//退出页眉设置


                //设置页码
                Microsoft.Office.Interop.Word.PageNumbers pns = WordApp.Selection.Sections[1].Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers;//获取当前页的号码
                pns.NumberStyle = Microsoft.Office.Interop.Word.WdPageNumberStyle.wdPageNumberStyleNumberInDash;
                pns.HeadingLevelForChapter = 0;
                pns.IncludeChapterNumber = false;
                pns.RestartNumberingAtSection = false;
                pns.StartingNumber = 0;
                object pagenmbetal = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberCenter;//将号码设置在中间.
                object first = true;
                WordApp.Selection.Sections[1].Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers.Add(ref pagenmbetal, ref first);


                //行距
                WordApp.Selection.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                WordApp.Selection.ParagraphFormat.LineSpacing = 24f;



                MSword.Paragraph d;

                d = WordDoc.Content.Paragraphs.Add(ref Nothing);
                d.Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                d.Range.ParagraphFormat.LineSpacing = 22f;
                d.Range.Text = strtitle;
                d.Range.Font.Bold = 0;
                d.Range.Font.Name = "华文中宋";
                d.Range.Font.Size = 22;
                d.Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphCenter;
                d.Format.SpaceAfter = 5;
                d.Range.InsertParagraphAfter();

                MSword.Table newTable2;
                MSword.Range wrdRngdata = WordDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                newTable2 = WordDoc.Tables.Add(wrdRngdata, 6, 8, ref Nothing, ref Nothing); //设置表格为几行几列，如：3行16列
                newTable2.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                //newTable2.Rows.Height = 70f;//控制行高
                //newTable2.Rows.HeightRule = MSword.WdRowHeightRule.wdRowHeightExactly;//设置行高值为固定
                newTable2.Range.Font.Name = "宋体";
                newTable2.Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                newTable2.Range.ParagraphFormat.LineSpacing = 10f;



                //设置单元格样式居中
                for (int e = 1; e <= 8; e++)
                {
                    newTable2.Columns[e].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                }

                //设置第一行  高
                newTable2.Borders.OutsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = MSword.WdLineWidth.wdLineWidth150pt;
                newTable2.Borders.InsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Rows[1].Height = 38f;
                newTable2.Rows[1].HeightRule = MSword.WdRowHeightRule.wdRowHeightExactly;//设置行高值为固定

                newTable2.Borders.OutsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = MSword.WdLineWidth.wdLineWidth100pt;
                newTable2.Borders.InsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth225pt;
                newTable2.Columns[1].Width = 30f;
                //newTable2.Columns[2].Width = 135f;
                for (int i = 1; i <= 6; i++)
                {
                    newTable2.Cell(i, 1).Range.Font.Size = 14;
                    newTable2.Cell(i, 1).Range.Font.Bold = 1;
                }
                newTable2.Range.Font.Size = 10;
                newTable2.Rows[1].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                newTable2.Rows[1].Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                newTable2.Rows[1].Range.ParagraphFormat.LineSpacing = 14f;
                newTable2.Rows[1].Range.Font.Size = 14;
                newTable2.Rows[1].Range.Font.Bold = 1;

                newTable2.Cell(1, 1).Range.Text = "";
                newTable2.Cell(1, 2).Range.Text = "星期一";
                newTable2.Cell(1, 3).Range.Text = "星期二";
                newTable2.Cell(1, 4).Range.Text = "星期三";
                newTable2.Cell(1, 5).Range.Text = "星期四";
                newTable2.Cell(1, 6).Range.Text = "星期五";
                newTable2.Cell(1, 7).Range.Text = "星期六";
                newTable2.Cell(1, 8).Range.Text = "星期日";

                for (int i = 2; i <= 6; i++)
                {
                    newTable2.Rows[i].Height = 50f;
                    for (int j = 2; j < 8; j++)
                    {
                        newTable2.Cell(i, j).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                }
                for (int k = 1; k <= dt.Rows.Count; k++)
                {
                    for (int i = 1; i <= 8; i++)
                    {
                        newTable2.Cell(k + 1, i).Range.Text = dt.Rows[k - 1][i - 1].ToString();
                        newTable2.Cell(k + 1, i).Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphLeft;
                    }
                }

                WordDoc.SaveAs(ref filename, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing);


                WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                GC.Collect();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool weekCourse(System.Data.DataTable dt, string path, string title)
        {
            try
            {
                string str = "";
                string strtitle = title;
                object oEndOfDoc = "\\endofdoc";
                Object Nothing = System.Reflection.Missing.Value;
                filename = path;
                //如果这个位置  出现异常  将引用里面的    office.interop.word  引用-》属性-》嵌入互操作类型改为  false
                WordApp = new MSword.ApplicationClass();
                WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                WordApp.Visible = false;//设置动态建立的word文档可见
                WordDoc.PageSetup.PaperSize = Microsoft.Office.Interop.Word.WdPaperSize.wdPaperA4;//设置纸张样式
                WordDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;//排列方式为横向方向
                WordApp.Selection.PageSetup.LeftMargin = WordApp.CentimetersToPoints(float.Parse("1"));//设置word文档的左边距
                WordApp.Selection.PageSetup.RightMargin = WordApp.CentimetersToPoints(float.Parse("1"));//设置word文档的右边距
                WordApp.Selection.PageSetup.TopMargin = WordApp.CentimetersToPoints(float.Parse("1"));
                WordApp.Selection.PageSetup.BottomMargin = WordApp.CentimetersToPoints(float.Parse("1"));
                WordApp.ActiveWindow.HorizontalPercentScrolled = 11;//设置文档的水平滑动距离
                WordApp.ActiveWindow.ActivePane.View.Zoom.Percentage = 130;//设置文档的百分比例



                WordDoc.PageSetup.HeaderDistance = 30.0f;//页眉位置

                //设置页眉
                WordApp.ActiveWindow.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdOutlineView;//视图样式
                WordApp.ActiveWindow.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekPrimaryHeader;//进入页眉设置，其中页眉边距在页面设置中已完成
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                //去掉页眉的横线
                WordApp.ActiveWindow.ActivePane.Selection.ParagraphFormat.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleNone;
                WordApp.ActiveWindow.ActivePane.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].Visible = false;
                WordApp.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekMainDocument;//退出页眉设置


                //设置页码
                Microsoft.Office.Interop.Word.PageNumbers pns = WordApp.Selection.Sections[1].Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers;//获取当前页的号码
                pns.NumberStyle = Microsoft.Office.Interop.Word.WdPageNumberStyle.wdPageNumberStyleNumberInDash;
                pns.HeadingLevelForChapter = 0;
                pns.IncludeChapterNumber = false;
                pns.RestartNumberingAtSection = false;
                pns.StartingNumber = 0;
                object pagenmbetal = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberCenter;//将号码设置在中间.
                object first = true;
                WordApp.Selection.Sections[1].Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers.Add(ref pagenmbetal, ref first);


                ////行距
                //WordApp.Selection.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                //WordApp.Selection.ParagraphFormat.LineSpacing = 24f;



                MSword.Paragraph d;

                d = WordDoc.Content.Paragraphs.Add(ref Nothing);
                d.Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                d.Range.ParagraphFormat.LineSpacing = 15f;
                d.Range.Text = strtitle;
                d.Range.Font.Bold = 0;
                d.Range.Font.Name = "华文中宋";
                d.Range.Font.Size = 15;
                d.Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphCenter;
                d.Format.SpaceAfter = 5;
                d.Range.InsertParagraphAfter();

                WordDoc.Paragraphs.Last.Range.Font.Size = 10;
                WordDoc.Paragraphs.Last.Range.Font.Bold = 0;
                WordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
                WordDoc.Paragraphs.LineSpacing = 10f;
                WordDoc.Paragraphs.Last.Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphLeft;
                WordDoc.Paragraphs.Last.Range.Text = "学院（公章）：__________________";

                MSword.Table newTable2;
                MSword.Range wrdRngdata = WordDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                newTable2 = WordDoc.Tables.Add(wrdRngdata, dt.Rows.Count + 1, 12, ref Nothing, ref Nothing); //设置表格为几行几列，如：3行16列
                newTable2.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                newTable2.Range.Font.Name = "宋体";
                newTable2.Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                newTable2.Range.ParagraphFormat.LineSpacing = 10f;

    

                //设置单元格样式居中
                for (int e = 1; e <= 12; e++)
                {
                    newTable2.Columns[e].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                }

                //设置第一行  高
                newTable2.Borders.OutsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = MSword.WdLineWidth.wdLineWidth150pt;
                newTable2.Borders.InsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Rows[1].Height = 38f;
                newTable2.Rows[1].HeightRule = MSword.WdRowHeightRule.wdRowHeightExactly;//设置行高值为固定

                newTable2.Borders.OutsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = MSword.WdLineWidth.wdLineWidth100pt;
                newTable2.Borders.InsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                //newTable2.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth225pt;
                newTable2.Columns[1].Width = 25f;
                for (int i = 1; i <= 6; i++)
                {
                    newTable2.Cell(i, 1).Range.Font.Size = 14;
                    newTable2.Cell(i, 1).Range.Font.Bold = 1;
                }
                newTable2.Range.Font.Size = 7;
                newTable2.Rows[1].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                newTable2.Rows[1].Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                newTable2.Rows[1].Range.ParagraphFormat.LineSpacing = 10f;
                newTable2.Rows[1].Range.Font.Size = 10;
                newTable2.Rows[1].Range.Font.Bold = 1;
                newTable2.Columns[2].Width = 100f;
                newTable2.Columns[3].Width = 100f;
                newTable2.Columns[4].Width = 90f;
                newTable2.Columns[5].Width = 130f;
                newTable2.Columns[6].Width = 80f;
                for (int i = 7; i <= 11; i++)
                {
                    newTable2.Columns[i].Width = 35f;
                }
                newTable2.Cell(1, 1).Range.Text = "序号";
                newTable2.Cell(1, 2).Range.Text = "课程名称";
                newTable2.Cell(1, 3).Range.Text = "班级";
                newTable2.Cell(1, 4).Range.Text = "指导教师(年龄，职称(学历))";
                newTable2.Cell(1, 5).Range.Text = "项目名称";
                newTable2.Cell(1, 6).Range.Text = "是否是综合性.设计性项目";
                newTable2.Cell(1, 7).Range.Text = "周次";
                newTable2.Cell(1, 8).Range.Text = "星期";
                newTable2.Cell(1, 9).Range.Text = "节次";
                newTable2.Cell(1, 10).Range.Text = "人数";
                newTable2.Cell(1, 11).Range.Text = "组别";
                newTable2.Cell(1, 12).Range.Text = "实验室";
                for (int i = 2; i <= dt.Rows.Count; i++)
                {
                    newTable2.Rows[i].Height = 20f;
                    for (int j = 2; j < 12; j++)
                    {
                        newTable2.Cell(i, j).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                }
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        newTable2.Cell(k + 2, i).Range.Text = dt.Rows[k][i - 1].ToString();
                        newTable2.Cell(k + 2, i).Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphLeft;
                    }
                }

                WordDoc.SaveAs(ref filename, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing);
                WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                GC.Collect();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string courseDesign(System.Data.DataTable dt, string path, string title)
        {
            try
            {
                string str = "";
                string strtitle = title;
                object oEndOfDoc = "\\endofdoc";
                Object Nothing = System.Reflection.Missing.Value;
                filename = path;
                //如果这个位置  出现异常  将引用里面的    office.interop.word  引用-》属性-》嵌入互操作类型改为  false
                WordApp = new MSword.ApplicationClass();
                WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                WordApp.Visible = false;//设置动态建立的word文档可见
                WordDoc.PageSetup.PaperSize = Microsoft.Office.Interop.Word.WdPaperSize.wdPaperA4;//设置纸张样式
                //WordDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;//排列方式为横向方向
                WordApp.Selection.PageSetup.LeftMargin = WordApp.CentimetersToPoints(float.Parse("1"));//设置word文档的左边距
                WordApp.Selection.PageSetup.RightMargin = WordApp.CentimetersToPoints(float.Parse("1"));//设置word文档的右边距
                WordApp.Selection.PageSetup.TopMargin = WordApp.CentimetersToPoints(float.Parse("1"));
                WordApp.Selection.PageSetup.BottomMargin = WordApp.CentimetersToPoints(float.Parse("1"));
                WordApp.ActiveWindow.HorizontalPercentScrolled = 11;//设置文档的水平滑动距离
                WordApp.ActiveWindow.ActivePane.View.Zoom.Percentage = 130;//设置文档的百分比例



                WordDoc.PageSetup.HeaderDistance = 30.0f;//页眉位置

                //设置页眉
                WordApp.ActiveWindow.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdOutlineView;//视图样式
                WordApp.ActiveWindow.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekPrimaryHeader;//进入页眉设置，其中页眉边距在页面设置中已完成
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                //去掉页眉的横线
                WordApp.ActiveWindow.ActivePane.Selection.ParagraphFormat.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleNone;
                WordApp.ActiveWindow.ActivePane.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].Visible = false;
                WordApp.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekMainDocument;//退出页眉设置


                //设置页码
                Microsoft.Office.Interop.Word.PageNumbers pns = WordApp.Selection.Sections[1].Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers;//获取当前页的号码
                pns.NumberStyle = Microsoft.Office.Interop.Word.WdPageNumberStyle.wdPageNumberStyleNumberInDash;
                pns.HeadingLevelForChapter = 0;
                pns.IncludeChapterNumber = false;
                pns.RestartNumberingAtSection = false;
                pns.StartingNumber = 0;
                object pagenmbetal = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberCenter;//将号码设置在中间.
                object first = true;
                WordApp.Selection.Sections[1].Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers.Add(ref pagenmbetal, ref first);


                ////行距
                //WordApp.Selection.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                //WordApp.Selection.ParagraphFormat.LineSpacing = 24f;



                MSword.Paragraph d;

                d = WordDoc.Content.Paragraphs.Add(ref Nothing);
                d.Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                d.Range.ParagraphFormat.LineSpacing = 15f;
                d.Range.Text = strtitle;
                d.Range.Font.Bold = 0;
                d.Range.Font.Name = "华文中宋";
                d.Range.Font.Size = 15;
                d.Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphCenter;
                d.Format.SpaceAfter = 5;
                d.Range.InsertParagraphAfter();

                WordDoc.Paragraphs.Last.Range.Font.Size = 12;
                WordDoc.Paragraphs.Last.Range.Font.Bold = 0;
                WordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
                WordDoc.Paragraphs.LineSpacing = 12f;
                WordDoc.Paragraphs.Last.Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphLeft;
                WordDoc.Paragraphs.Last.Range.Text = "学院（公章）：__________________";

                MSword.Table newTable2;
                MSword.Range wrdRngdata = WordDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                newTable2 = WordDoc.Tables.Add(wrdRngdata, dt.Rows.Count + 1, 8, ref Nothing, ref Nothing); //设置表格为几行几列，如：3行16列
                newTable2.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                newTable2.Range.Font.Name = "宋体";
                newTable2.Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                newTable2.Range.ParagraphFormat.LineSpacing = 10f;

                //设置单元格样式居中
                for (int e = 1; e <= 8; e++)
                {
                    newTable2.Columns[e].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                }

                //设置第一行  高
                newTable2.Borders.OutsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = MSword.WdLineWidth.wdLineWidth150pt;
                newTable2.Borders.InsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Rows[1].Height = 30f;
                newTable2.Rows[1].Range.Font.Size = 10;
                newTable2.Rows[1].HeightRule = MSword.WdRowHeightRule.wdRowHeightExactly;//设置行高值为固定

                newTable2.Borders.OutsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = MSword.WdLineWidth.wdLineWidth100pt;
                newTable2.Borders.InsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                //newTable2.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth225pt;
                newTable2.Columns[1].Width = 25f;
                newTable2.Columns[2].Width = 120f;
                newTable2.Columns[3].Width = 120f;
                newTable2.Columns[8].Width = 120f;
                //for (int i = 1; i <= 6; i++)
                //{
                //    newTable2.Cell(i, 1).Range.Font.Size = 14;
                //    newTable2.Cell(i, 1).Range.Font.Bold = 1;
                //}
                newTable2.Range.Font.Size = 7;
                newTable2.Rows[1].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                newTable2.Rows[1].Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                newTable2.Rows[1].Range.ParagraphFormat.LineSpacing = 10f;
                newTable2.Rows[1].Range.Font.Size = 10;
                newTable2.Rows[1].Range.Font.Bold = 1;
                newTable2.Columns[4].Width = 45f;
                for (int i = 5; i <= 7; i++)
                {
                    newTable2.Columns[i].Width = 35f;
                }
                newTable2.Cell(1, 1).Range.Text = "序号";
                newTable2.Cell(1, 2).Range.Text = "课程设计名称";
                newTable2.Cell(1, 3).Range.Text = "班级";
                newTable2.Cell(1, 4).Range.Text = "起止周";
                newTable2.Cell(1, 5).Range.Text = "组别";
                newTable2.Cell(1, 6).Range.Text = "人数";
                newTable2.Cell(1, 7).Range.Text = "地点";
                newTable2.Cell(1, 8).Range.Text = "指导教师(年龄，职称)";

                for (int i = 2; i <= dt.Rows.Count; i++)
                {
                    newTable2.Rows[i].Height = 20f;
                    for (int j = 2; j < 8; j++)
                    {
                        newTable2.Cell(i, j).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                }
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    for (int i = 1; i <= 8; i++)
                    {
                        newTable2.Cell(k + 2, i).Range.Text = dt.Rows[k][i - 1].ToString();
                        newTable2.Cell(k + 2, i).Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphLeft;
                    }
                }


                WordDoc.Paragraphs.Last.Range.Font.Size = 7;
                WordDoc.Paragraphs.Last.Range.Font.Bold = 0;
                WordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
                WordDoc.Paragraphs.LineSpacing = 7f;
                WordDoc.Paragraphs.Last.Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphLeft;
                string sss = "       填表人：             审核人：            填表日期：     年    月    日";
         
                WordDoc.Paragraphs.Last.Range.Text = sss;
                WordDoc.SaveAs(ref filename, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing);
                WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                GC.Collect();
                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// 老版本  带班级和人数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="path"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool newMission(System.Data.DataTable dt, string path, string title)
        {
            try
            {
                string str = "";
                string strtitle = title;
                object oEndOfDoc = "\\endofdoc";
                Object Nothing = System.Reflection.Missing.Value;
                filename = path;
                //如果这个位置  出现异常  将引用里面的    office.interop.word  引用-》属性-》嵌入互操作类型改为  false
                WordApp = new MSword.ApplicationClass();
                WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                WordApp.Visible = false;//设置动态建立的word文档可见
                WordDoc.PageSetup.PaperSize = Microsoft.Office.Interop.Word.WdPaperSize.wdPaperA4;//设置纸张样式
                //WordDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;//排列方式为横向方向
                WordApp.Selection.PageSetup.LeftMargin = WordApp.CentimetersToPoints(float.Parse("1"));//设置word文档的左边距
                WordApp.Selection.PageSetup.RightMargin = WordApp.CentimetersToPoints(float.Parse("1"));//设置word文档的右边距
                WordApp.Selection.PageSetup.TopMargin = WordApp.CentimetersToPoints(float.Parse("1"));
                WordApp.Selection.PageSetup.BottomMargin = WordApp.CentimetersToPoints(float.Parse("1"));
                WordApp.ActiveWindow.HorizontalPercentScrolled = 11;//设置文档的水平滑动距离
                WordApp.ActiveWindow.ActivePane.View.Zoom.Percentage = 130;//设置文档的百分比例



                WordDoc.PageSetup.HeaderDistance = 30.0f;//页眉位置

                //设置页眉
                WordApp.ActiveWindow.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdOutlineView;//视图样式
                WordApp.ActiveWindow.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekPrimaryHeader;//进入页眉设置，其中页眉边距在页面设置中已完成
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                //去掉页眉的横线
                WordApp.ActiveWindow.ActivePane.Selection.ParagraphFormat.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleNone;
                WordApp.ActiveWindow.ActivePane.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].Visible = false;
                WordApp.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekMainDocument;//退出页眉设置


                //设置页码
                Microsoft.Office.Interop.Word.PageNumbers pns = WordApp.Selection.Sections[1].Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers;//获取当前页的号码
                pns.NumberStyle = Microsoft.Office.Interop.Word.WdPageNumberStyle.wdPageNumberStyleNumberInDash;
                pns.HeadingLevelForChapter = 0;
                pns.IncludeChapterNumber = false;
                pns.RestartNumberingAtSection = false;
                pns.StartingNumber = 0;
                object pagenmbetal = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberCenter;//将号码设置在中间.
                object first = true;
                WordApp.Selection.Sections[1].Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers.Add(ref pagenmbetal, ref first);


                //行距
                WordApp.Selection.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                WordApp.Selection.ParagraphFormat.LineSpacing = 24f;



                MSword.Paragraph d;

                d = WordDoc.Content.Paragraphs.Add(ref Nothing);
                d.Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                d.Range.ParagraphFormat.LineSpacing = 22f;
                d.Range.Text = strtitle;
                d.Range.Font.Bold = 0;
                d.Range.Font.Name = "华文中宋";
                d.Range.Font.Size = 15;
                d.Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphCenter;
                d.Format.SpaceAfter = 5;
                d.Range.InsertParagraphAfter();

                MSword.Table newTable2;
                MSword.Range wrdRngdata = WordDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                newTable2 = WordDoc.Tables.Add(wrdRngdata, 23, 14, ref Nothing, ref Nothing); //设置表格为几行几列，如：3行16列
                newTable2.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                newTable2.Range.Font.Name = "宋体";
                newTable2.Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                newTable2.Range.ParagraphFormat.LineSpacing = 10f;

                //设置单元格样式居中
                for (int e = 1; e <= 14; e++)
                {
                    newTable2.Columns[e].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                }

                //设置第一行  高
                newTable2.Borders.OutsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = MSword.WdLineWidth.wdLineWidth150pt;
                newTable2.Borders.InsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Rows[1].Height = 25f;
                newTable2.Rows[2].Height = 25f;
                newTable2.Rows[3].Height = 25f;
                newTable2.Rows[4].Height = 25f;

                newTable2.Rows[21].Height = 25f;
                newTable2.Rows[22].Height = 50f;
                newTable2.Rows[23].Height = 100f;
                newTable2.Rows[1].Range.Font.Size = 10;
                newTable2.Rows[1].HeightRule = MSword.WdRowHeightRule.wdRowHeightExactly;//设置行高值为固定

                newTable2.Borders.OutsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = MSword.WdLineWidth.wdLineWidth100pt;
                newTable2.Borders.InsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;



                newTable2.Cell(1, 1).Merge(newTable2.Cell(1, 2));
                newTable2.Cell(3, 1).Merge(newTable2.Cell(3, 2));
                newTable2.Cell(2, 1).Merge(newTable2.Cell(2, 2));
                newTable2.Cell(4, 1).Merge(newTable2.Cell(4, 2));

                newTable2.Cell(1, 2).Merge(newTable2.Cell(1, 3));
                newTable2.Cell(1, 2).Merge(newTable2.Cell(1, 3));
                newTable2.Cell(1, 2).Merge(newTable2.Cell(1, 3));
                newTable2.Cell(1, 2).Merge(newTable2.Cell(1, 3));

                newTable2.Cell(2, 2).Merge(newTable2.Cell(2, 3));
                newTable2.Cell(2, 2).Merge(newTable2.Cell(2, 3));
                newTable2.Cell(2, 2).Merge(newTable2.Cell(2, 3));
                newTable2.Cell(2, 2).Merge(newTable2.Cell(2, 3));

                newTable2.Cell(3, 2).Merge(newTable2.Cell(3, 3));
                newTable2.Cell(3, 2).Merge(newTable2.Cell(3, 3));
                newTable2.Cell(3, 2).Merge(newTable2.Cell(3, 3));
                newTable2.Cell(3, 2).Merge(newTable2.Cell(3, 3));

                newTable2.Cell(1, 3).Merge(newTable2.Cell(1, 4));
                newTable2.Cell(3, 3).Merge(newTable2.Cell(3, 4));
                newTable2.Cell(2, 3).Merge(newTable2.Cell(2, 4));


                newTable2.Cell(1, 4).Merge(newTable2.Cell(1, 5));
                newTable2.Cell(1, 4).Merge(newTable2.Cell(1, 5));
                newTable2.Cell(1, 4).Merge(newTable2.Cell(1, 5));
                newTable2.Cell(1, 4).Merge(newTable2.Cell(1, 5));

                newTable2.Cell(2, 4).Merge(newTable2.Cell(2, 5));
                newTable2.Cell(2, 4).Merge(newTable2.Cell(2, 5));
                newTable2.Cell(2, 4).Merge(newTable2.Cell(2, 5));
                newTable2.Cell(2, 4).Merge(newTable2.Cell(2, 5));

                newTable2.Cell(3, 4).Merge(newTable2.Cell(3, 5));
                newTable2.Cell(3, 4).Merge(newTable2.Cell(3, 5));
                for (int i = 0; i < 11; i++)
                {
                        newTable2.Cell(4, 2).Merge(newTable2.Cell(4, 3));
                }
                for (int i = 5; i <= 20; i++)
                {
                    int b = 6;
                    while (b > 0)
                    {
                        newTable2.Cell(i, 2).Merge(newTable2.Cell(i, 3));
                        b--;
                    }
                    newTable2.Cell(i, 3).Merge(newTable2.Cell(i, 4));
                    newTable2.Cell(i, 4).Merge(newTable2.Cell(i, 5));
                    newTable2.Cell(i, 5).Merge(newTable2.Cell(i, 6));
                }
                for (int i = 21; i <= 22; i++)
                {
                    newTable2.Cell(i, 1).Merge(newTable2.Cell(i, 2));
                    newTable2.Cell(i, 1).Merge(newTable2.Cell(i, 2));
                    newTable2.Cell(i, 1).Merge(newTable2.Cell(i, 2));

                    newTable2.Cell(i, 2).Merge(newTable2.Cell(i, 3));
                    newTable2.Cell(i, 3).Merge(newTable2.Cell(i, 4));

                    newTable2.Cell(i, 4).Merge(newTable2.Cell(i, 5));
                    newTable2.Cell(i, 4).Merge(newTable2.Cell(i, 5));
                    newTable2.Cell(i, 4).Merge(newTable2.Cell(i, 5));
                    newTable2.Cell(i, 4).Merge(newTable2.Cell(i, 5));
                    newTable2.Cell(i, 4).Merge(newTable2.Cell(i, 5));
                }

                newTable2.Cell(23, 1).Merge(newTable2.Cell(23, 2));
                newTable2.Cell(23, 1).Merge(newTable2.Cell(23, 2));
                newTable2.Cell(23, 1).Merge(newTable2.Cell(23, 2));

                newTable2.Cell(23, 2).Merge(newTable2.Cell(23, 3));
                newTable2.Cell(23, 2).Merge(newTable2.Cell(23, 3));

                newTable2.Cell(23, 3).Merge(newTable2.Cell(23, 4));
                newTable2.Cell(23, 3).Merge(newTable2.Cell(23, 4));
                newTable2.Cell(23, 3).Merge(newTable2.Cell(23, 4));

                newTable2.Cell(23, 4).Merge(newTable2.Cell(23, 5));
                newTable2.Cell(23, 4).Merge(newTable2.Cell(23, 5));




                newTable2.Range.Font.Size = 8;
                newTable2.Rows[1].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                newTable2.Rows[1].Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                newTable2.Rows[1].Range.ParagraphFormat.LineSpacing = 10f;
                newTable2.Rows[1].Range.Font.Size = 9;
                newTable2.Rows[2].Range.Font.Size = 9;
                newTable2.Rows[3].Range.Font.Size = 9;
                newTable2.Cell(1, 1).Range.Text = "课程名称";
                newTable2.Cell(1, 2).Range.Text = dt.Rows[0]["课程名称"].ToString(); ;
                newTable2.Cell(1, 3).Range.Text = "实验学时";
                newTable2.Cell(1, 4).Range.Text = dt.Rows[0]["总学时"].ToString();
              


                newTable2.Cell(2, 1).Range.Text = "实验室所在学院";
                newTable2.Cell(2, 2).Range.Text = "计算机与信息工程学院";
                newTable2.Cell(2, 3).Range.Text = "实验室名称";
                newTable2.Cell(2, 4).Range.Text = dt.Rows[0]["实验室名称"].ToString();
                //newTable2.Cell(2, 5).Range.Text = "项目个数";
                //newTable2.Cell(2, 6).Range.Text = dt.Rows[0]["项目个数"].ToString();

                newTable2.Cell(3, 1).Range.Text = "指导教师";
                newTable2.Cell(3, 2).Range.Text = dt.Rows[0]["教师"].ToString();
                newTable2.Cell(3, 3).Range.Text = "实验室门标";
                newTable2.Cell(3, 4).Range.Text = dt.Rows[0]["实验室门标"].ToString();
                newTable2.Cell(3, 5).Range.Text = "项目个数";
                newTable2.Cell(3, 6).Range.Text = dt.Rows[0]["项目个数"].ToString();

                newTable2.Cell(4, 1).Range.Text = "所属实验室（中心）";
                newTable2.Cell(4, 2).Range.Text = "计算机与信息工程学院实验中心";

                newTable2.Cell(5, 1).Range.Text = "序号";
                newTable2.Cell(5, 2).Range.Text = "项目名称";
                newTable2.Cell(5, 3).Range.Text = "学时";
                newTable2.Cell(5, 4).Range.Text = "拟开周次";
                newTable2.Cell(5, 5).Range.Text = "备注";


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    newTable2.Cell(i + 6, 2).Range.Text = dt.Rows[i]["项目"].ToString();
                    newTable2.Cell(i + 6, 3).Range.Text = "2";
                    newTable2.Cell(i + 6, 4).Range.Text = dt.Rows[i]["周次"].ToString();
                }
                for (int i = 0; i < 15; i++)
                {
                    newTable2.Cell(i + 6, 1).Range.Text = (i + 1).ToString();
                }
                newTable2.Cell(21, 1).Range.Text = "实验室成绩占总成绩比例";
                newTable2.Cell(21, 2).Range.Text = "";
                newTable2.Cell(21, 3).Range.Text = "分组";
                newTable2.Cell(21, 4).Range.Text = "43/2(22+21)或23/1";
                newTable2.Cell(22, 1).Range.Text = "实验项目开出率";
                newTable2.Cell(22, 2).Range.Text = "100%";
                newTable2.Cell(22, 3).Range.Text = "综合性设计性实验(填写序号)";
                newTable2.Cell(22, 4).Range.Text = "";

                newTable2.Rows[23].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalTop;
                newTable2.Cell(23, 1).Range.Text = "教师所在学院(部)意见";
                newTable2.Cell(23, 3).Range.Text = "承担实验教学任务学院(部)";
                newTable2.Cell(23, 2).Range.Text = "\r\n签字\r\n\n盖章";
                newTable2.Cell(23, 4).Range.Text = "\r\n签字\r\n\n盖章";

                WordDoc.Paragraphs.Last.Range.Font.Size = 7;
                WordDoc.Paragraphs.Last.Range.Font.Bold = 0;
                WordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
                WordDoc.Paragraphs.LineSpacing = 7f;
                WordDoc.Paragraphs.Last.Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphLeft;
                string sss = "说明：1.备注栏填写对实验仪器设备或软件等要求及对实验指导老师要求。";
                sss += "2.实验指导教师与承担实验教学任务院（部）为同一单位时，单位负责人在教师所在学院签字。";
                sss += "3.表格中栏目不够可自行添加。";
                sss += "4.本表一式三份，实验课程指导教师，实验室，教务处各一份。";
                sss += "5.指导教师栏中级以上填写职称，其他填写学历或学位信息。";
                sss += "3.分组格式见样表。";
                WordDoc.Paragraphs.Last.Range.Text = sss;
                WordDoc.SaveAs(ref filename, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing);
                WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                GC.Collect();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       /// <summary>
       /// 老版本  带班级和人数
       /// </summary>
       /// <param name="dt"></param>
       /// <param name="path"></param>
       /// <param name="title"></param>
       /// <returns></returns>
        public bool mission(System.Data.DataTable dt, string path, string title)
        {
            try
            {
                string str = "";
                string strtitle = title;
                object oEndOfDoc = "\\endofdoc";
                Object Nothing = System.Reflection.Missing.Value;
                filename = path;
                //如果这个位置  出现异常  将引用里面的    office.interop.word  引用-》属性-》嵌入互操作类型改为  false
                WordApp = new MSword.ApplicationClass();
                WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                WordApp.Visible = false;//设置动态建立的word文档可见
                WordDoc.PageSetup.PaperSize = Microsoft.Office.Interop.Word.WdPaperSize.wdPaperA4;//设置纸张样式
                //WordDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;//排列方式为横向方向
                WordApp.Selection.PageSetup.LeftMargin = WordApp.CentimetersToPoints(float.Parse("1"));//设置word文档的左边距
                WordApp.Selection.PageSetup.RightMargin = WordApp.CentimetersToPoints(float.Parse("1"));//设置word文档的右边距
                WordApp.Selection.PageSetup.TopMargin = WordApp.CentimetersToPoints(float.Parse("1"));
                WordApp.Selection.PageSetup.BottomMargin = WordApp.CentimetersToPoints(float.Parse("1"));
                WordApp.ActiveWindow.HorizontalPercentScrolled = 11;//设置文档的水平滑动距离
                WordApp.ActiveWindow.ActivePane.View.Zoom.Percentage = 130;//设置文档的百分比例



                WordDoc.PageSetup.HeaderDistance = 30.0f;//页眉位置

                //设置页眉
                WordApp.ActiveWindow.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdOutlineView;//视图样式
                WordApp.ActiveWindow.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekPrimaryHeader;//进入页眉设置，其中页眉边距在页面设置中已完成
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                //去掉页眉的横线
                WordApp.ActiveWindow.ActivePane.Selection.ParagraphFormat.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleNone;
                WordApp.ActiveWindow.ActivePane.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].Visible = false;
                WordApp.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekMainDocument;//退出页眉设置


                //设置页码
                Microsoft.Office.Interop.Word.PageNumbers pns = WordApp.Selection.Sections[1].Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers;//获取当前页的号码
                pns.NumberStyle = Microsoft.Office.Interop.Word.WdPageNumberStyle.wdPageNumberStyleNumberInDash;
                pns.HeadingLevelForChapter = 0;
                pns.IncludeChapterNumber = false;
                pns.RestartNumberingAtSection = false;
                pns.StartingNumber = 0;
                object pagenmbetal = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberCenter;//将号码设置在中间.
                object first = true;
                WordApp.Selection.Sections[1].Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers.Add(ref pagenmbetal, ref first);


                //行距
                WordApp.Selection.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                WordApp.Selection.ParagraphFormat.LineSpacing = 24f;



                MSword.Paragraph d;

                d = WordDoc.Content.Paragraphs.Add(ref Nothing);
                d.Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                d.Range.ParagraphFormat.LineSpacing = 22f;
                d.Range.Text = strtitle;
                d.Range.Font.Bold = 0;
                d.Range.Font.Name = "华文中宋";
                d.Range.Font.Size = 15;
                d.Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphCenter;
                d.Format.SpaceAfter = 5;
                d.Range.InsertParagraphAfter();

                MSword.Table newTable2;
                MSword.Range wrdRngdata = WordDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                newTable2 = WordDoc.Tables.Add(wrdRngdata, 23, 14, ref Nothing, ref Nothing); //设置表格为几行几列，如：3行16列
                newTable2.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                newTable2.Range.Font.Name = "宋体";
                newTable2.Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                newTable2.Range.ParagraphFormat.LineSpacing = 10f;

                //设置单元格样式居中
                for (int e = 1; e <= 14; e++)
                {
                    newTable2.Columns[e].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                }

                //设置第一行  高
                newTable2.Borders.OutsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = MSword.WdLineWidth.wdLineWidth150pt;
                newTable2.Borders.InsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Rows[1].Height = 25f;
                newTable2.Rows[2].Height = 25f;
                newTable2.Rows[3].Height = 25f;

                newTable2.Rows[20].Height = 25f;
                newTable2.Rows[21].Height = 50f;
                newTable2.Rows[22].Height = 25f;
                newTable2.Rows[23].Height = 100f;
                newTable2.Rows[1].Range.Font.Size = 10;
                newTable2.Rows[1].HeightRule = MSword.WdRowHeightRule.wdRowHeightExactly;//设置行高值为固定

                newTable2.Borders.OutsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;
                newTable2.Borders.OutsideLineWidth = MSword.WdLineWidth.wdLineWidth100pt;
                newTable2.Borders.InsideLineStyle = MSword.WdLineStyle.wdLineStyleSingle;



                newTable2.Cell(1, 1).Merge(newTable2.Cell(1, 2));
                newTable2.Cell(3, 1).Merge(newTable2.Cell(3, 2));
                newTable2.Cell(2, 1).Merge(newTable2.Cell(2, 2));
                newTable2.Cell(1, 2).Merge(newTable2.Cell(1, 3));
                newTable2.Cell(1, 2).Merge(newTable2.Cell(1, 3));
                newTable2.Cell(1, 2).Merge(newTable2.Cell(1, 3));
                newTable2.Cell(2, 2).Merge(newTable2.Cell(2, 3));
                newTable2.Cell(2, 2).Merge(newTable2.Cell(2, 3));
                newTable2.Cell(2, 2).Merge(newTable2.Cell(2, 3));
                newTable2.Cell(3, 2).Merge(newTable2.Cell(3, 3));
                newTable2.Cell(3, 2).Merge(newTable2.Cell(3, 3));
                newTable2.Cell(3, 2).Merge(newTable2.Cell(3, 3));

                newTable2.Cell(1, 3).Merge(newTable2.Cell(1, 4));
                newTable2.Cell(3, 3).Merge(newTable2.Cell(3, 4));
                newTable2.Cell(2, 3).Merge(newTable2.Cell(2, 4));


                newTable2.Cell(1, 4).Merge(newTable2.Cell(1, 5));
                newTable2.Cell(1, 4).Merge(newTable2.Cell(1, 5));
                newTable2.Cell(2, 4).Merge(newTable2.Cell(2, 5));
                newTable2.Cell(2, 4).Merge(newTable2.Cell(2, 5));
                newTable2.Cell(3, 4).Merge(newTable2.Cell(3, 5));
                newTable2.Cell(3, 4).Merge(newTable2.Cell(3, 5));

                newTable2.Cell(1, 5).Merge(newTable2.Cell(1, 6));
                newTable2.Cell(2, 5).Merge(newTable2.Cell(2, 6));
                newTable2.Cell(3, 5).Merge(newTable2.Cell(3, 6));
                for (int i = 4; i <= 19; i++)
                {
                    int b = 6;
                    while (b > 0)
                    {
                        newTable2.Cell(i, 2).Merge(newTable2.Cell(i, 3));
                        b--;
                    }
                    newTable2.Cell(i, 3).Merge(newTable2.Cell(i, 4));
                    newTable2.Cell(i, 4).Merge(newTable2.Cell(i, 5));
                    newTable2.Cell(i, 5).Merge(newTable2.Cell(i, 6));
                }
                for (int i = 20; i <= 22; i++)
                {
                    newTable2.Cell(i, 1).Merge(newTable2.Cell(i, 2));
                    newTable2.Cell(i, 1).Merge(newTable2.Cell(i, 2));
                    newTable2.Cell(i, 1).Merge(newTable2.Cell(i, 2));
                }
                newTable2.Cell(23, 1).Merge(newTable2.Cell(23, 2));
                newTable2.Cell(23, 1).Merge(newTable2.Cell(23, 2));

                newTable2.Cell(20, 2).Merge(newTable2.Cell(20, 3));
                newTable2.Cell(20, 3).Merge(newTable2.Cell(20, 4));
                newTable2.Cell(21, 2).Merge(newTable2.Cell(21, 3));
                newTable2.Cell(21, 3).Merge(newTable2.Cell(21, 4));
                for (int i = 0; i < 5; i++)
                {
                    newTable2.Cell(20, 4).Merge(newTable2.Cell(20, 5));
                    newTable2.Cell(21, 4).Merge(newTable2.Cell(21, 5));
                }

                for (int i = 0; i < 9; i++)
                {
                    newTable2.Cell(22, 2).Merge(newTable2.Cell(22, 3));
                }

                newTable2.Cell(23, 2).Merge(newTable2.Cell(23, 3));
                newTable2.Cell(23, 2).Merge(newTable2.Cell(23, 3));
                newTable2.Cell(23, 2).Merge(newTable2.Cell(23, 3));

                newTable2.Cell(23, 3).Merge(newTable2.Cell(23, 4));
                newTable2.Cell(23, 3).Merge(newTable2.Cell(23, 4));


                newTable2.Cell(23, 4).Merge(newTable2.Cell(23, 5));
                newTable2.Cell(23, 4).Merge(newTable2.Cell(23, 5));
                newTable2.Cell(23, 4).Merge(newTable2.Cell(23, 5));




                newTable2.Range.Font.Size = 8;
                newTable2.Rows[1].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                newTable2.Rows[1].Range.ParagraphFormat.LineSpacingRule = MSword.WdLineSpacing.wdLineSpaceExactly;
                newTable2.Rows[1].Range.ParagraphFormat.LineSpacing = 10f;
                newTable2.Rows[1].Range.Font.Size = 9;
                newTable2.Rows[2].Range.Font.Size = 9;
                newTable2.Rows[3].Range.Font.Size = 9;
                newTable2.Cell(1, 1).Range.Text = "实验室所在学院";
                newTable2.Cell(1, 2).Range.Text = "计算机与信息工程学院";
                newTable2.Cell(1, 3).Range.Text = "实验室名称";
                newTable2.Cell(1, 4).Range.Text = dt.Rows[0]["实验室名称"].ToString();
                newTable2.Cell(1, 5).Range.Text = "实验室门标";
                newTable2.Cell(1, 6).Range.Text = dt.Rows[0]["实验室门标"].ToString();


                newTable2.Cell(2, 1).Range.Text = "课程名称";
                newTable2.Cell(2, 2).Range.Text = dt.Rows[0]["课程名称"].ToString();
                newTable2.Cell(2, 3).Range.Text = "总学时";
                newTable2.Cell(2, 4).Range.Text = dt.Rows[0]["总学时"].ToString();
                newTable2.Cell(2, 5).Range.Text = "项目个数";
                newTable2.Cell(2, 6).Range.Text = dt.Rows[0]["项目个数"].ToString();

                newTable2.Cell(3, 1).Range.Text = "指导教师";
                newTable2.Cell(3, 2).Range.Text = dt.Rows[0]["教师"].ToString();
                newTable2.Cell(3, 3).Range.Text = "教学班级名称";
                newTable2.Cell(3, 4).Range.Text = dt.Rows[0]["班级"].ToString();
                newTable2.Cell(3, 5).Range.Text = "班级人数";
                newTable2.Cell(3, 6).Range.Text = dt.Rows[0]["人数"].ToString();

                newTable2.Cell(4, 1).Range.Text = "序号";
                newTable2.Cell(4, 2).Range.Text = "项目名称";
                newTable2.Cell(4, 3).Range.Text = "学时";
                newTable2.Cell(4, 4).Range.Text = "拟开周次";
                newTable2.Cell(4, 5).Range.Text = "备注";


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    newTable2.Cell(i + 5, 2).Range.Text = dt.Rows[i]["项目"].ToString();
                    newTable2.Cell(i + 5, 3).Range.Text = "2";
                    newTable2.Cell(i + 5, 4).Range.Text = dt.Rows[i]["周次"].ToString();
                }
                for (int i = 0; i < 15; i++)
                {
                    newTable2.Cell(i + 5, 1).Range.Text = (i + 1).ToString();
                }
                newTable2.Cell(20, 1).Range.Text = "实验室成绩占总成绩比列";
                newTable2.Cell(20, 2).Range.Text = "";
                newTable2.Cell(20, 3).Range.Text = "分组";
                newTable2.Cell(20, 4).Range.Text = "";
                newTable2.Cell(21, 1).Range.Text = "实验项目开出率";
                newTable2.Cell(21, 2).Range.Text = "100%";
                newTable2.Cell(21, 3).Range.Text = "综合性设计性实验(填写序号)";
                newTable2.Cell(21, 4).Range.Text = "";

                newTable2.Cell(22, 1).Range.Text = "实验室（中心）";
                newTable2.Cell(22, 2).Range.Text = "计算机与信息工程实验中心";

                newTable2.Cell(23, 1).Range.Text = "教师所在学院（部）";
                newTable2.Cell(23, 3).Range.Text = "承担实验教学任务学院（部）";


                WordDoc.Paragraphs.Last.Range.Font.Size = 7;
                WordDoc.Paragraphs.Last.Range.Font.Bold = 0;
                WordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
                WordDoc.Paragraphs.LineSpacing = 7f;
                WordDoc.Paragraphs.Last.Range.ParagraphFormat.Alignment = MSword.WdParagraphAlignment.wdAlignParagraphLeft;
                string sss = "说明：1.备注栏填写对实验仪器设备或软件等要求及对实验指导老师要求。";
                sss += "2.实验指导教师与承担实验教学任务院（部）为同一单位时，单位负责人在教师所在学院签字。";
                sss += "3.表格中栏目不够可自行添加。";
                sss += "4.本表一式三份，实验课程指导教师，实验室，教务处各一份。";
                sss += "5.指导教师栏中级以上填写职称，其他填写学历或学位信息。";
                sss += "3.分组格式见样表。";
                WordDoc.Paragraphs.Last.Range.Text = sss;
                WordDoc.SaveAs(ref filename, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing);
                WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                GC.Collect();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
