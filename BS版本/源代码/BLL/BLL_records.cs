using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{

    public class BLL_records
    {
        DAL_records r = new DAL_records();
        public string returnNum(string n)
        {
            switch (n)
            {
                case "一": return "1";
                case "二": return "2";
                case "三": return "3";
                case "四": return "4";
                case "五": return "5";
                case "六": return "6";
                default: return "7";
            }
        }
        public string returnChinese(string n)
        {
            switch (n)
            {
                case "1": return "一";
                case "2": return "二";
                case "3": return "三";
                case "4": return "四";
                case "5": return "五";
                case "6": return "六";
                default: return "日";
            }
        }
        public string returnSecNum(string n)
        {
            switch (n)
            {
                case "1.2": return "1";
                case "3.4": return "2";
                case "5.6": return "3";
                case "7.8": return "4";
                default: return "5";
            }
        }
        public string returnSec(string n)
        {
            switch (n)
            {
                case "1": return "1.2";
                case "2": return "3.4";
                case "3": return "5.6";
                case "4": return "7.8";
                default: return "9.10";
            }
        }
        public string returnDay(int n)
        {
            if (n % 7 == 1)
                return "一";
            else if (n % 7 == 2)
                return "二";
            else if (n % 7 == 3)
                return "三";
            else if (n % 7 == 4)
                return "四";
            else if (n % 7 == 5)
                return "五";
            else if (n % 7 == 6)
                return "六";
            else
                return "日";
        }
        public string returnSec(int n)
        {
            if (n >= 1 && n <= 7)
                return "1.2";
            else if (n >= 8 && n <= 14)
                return "3.4";
            else if (n >= 15 && n <= 21)
                return "5.6";
            else if (n >= 22 && n <= 28)
                return "7.8";
            else
                return "9.10";
        }

        public DataTable recordDemo(string courseName, string classs, string tea, string lab, string week, string sec1, string sec2, string sec3, string sec4, string sec5)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("课程");
                table.Columns.Add("班级");
                table.Columns.Add("教师");
                table.Columns.Add("周次");
                table.Columns.Add("星期");
                table.Columns.Add("节次");
                table.Columns.Add("人数");
                table.Columns.Add("组别");
                table.Columns.Add("实验室");
                table.Columns.Add("操作人");
                table.Columns.Add("提交时间");

                table.Columns.Add("项目名称");
                table.Columns.Add("是否综合性");
                table.Columns.Add("detailID");
                table.Columns.Add("courseID");
                DataTable dd = r.recordDemo(courseName, classs, tea, lab);

                if (dd != null)
                {
                    if (dd.Rows.Count > 0)
                    {
                        for (int j = 0; j < dd.Rows.Count; j++)
                        {
                            DataTable dt = r.findDetail(dd.Rows[j]["id"].ToString());
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataRow row = table.NewRow();
                                row[0] = dd.Rows[j][1].ToString();
                                row[1] = dd.Rows[j][2].ToString();
                                row[2] = dd.Rows[j][3].ToString();
                                row[3] = dt.Rows[i]["week"].ToString();
                                row[4] = dt.Rows[i]["remark1"].ToString();
                                row[5] = dt.Rows[i]["remark2"].ToString();
                                row[6] = dd.Rows[j]["count"].ToString();
                                row[7] = dd.Rows[j]["groups"].ToString();
                                row[8] = dd.Rows[j]["lab"].ToString();
                                row[9] = dd.Rows[j]["person"].ToString();
                                row[10] = dd.Rows[j]["time"].ToString();
                                row[11] = dt.Rows[i]["project"].ToString();
                                if (dt.Rows[i][2].ToString().Trim() == "0")
                                    row[12] = "否";
                                else
                                    row[12] = "是";
                                row[13] = dt.Rows[i][0].ToString();
                                row[14] = dd.Rows[j][0].ToString();
                                table.Rows.Add(row.ItemArray);
                            }
                        }
                    }
                    int f = 0;
                    string str = "", ss = ""; ;
                    if (week.Trim() != "undefined")
                    {
                        str = "周次='" + week + "'";
                        f = 1;
                    }
                    int c = 0;
                    string sec = "", days = "";

                    if (sec1.Trim() != "undefined")
                    {
                        sec = returnSec(int.Parse(sec1));
                        days = returnDay(int.Parse(sec1));
                        ss = " (星期='" + days + "' and 节次='" + sec + "') ";
                        if (f == 1)
                            str += " and ( " + ss;
                        else
                            str += " ( " + ss;
                        c = 1;
                    }
                    if (sec2.Trim() != "undefined")
                    {
                        sec = returnSec(int.Parse(sec2));
                        days = returnDay(int.Parse(sec2));
                        ss = " (星期='" + days + "' and 节次='" + sec + "') ";
                        if (c == 0)
                            if (f == 1)
                                str += " and ( " + ss;
                            else
                                str += " ( " + ss;
                        else
                            str += " or " + ss;
                        c = 1;
                    }
                    if (sec3.Trim() != "undefined")
                    {
                        sec = returnSec(int.Parse(sec3));
                        days = returnDay(int.Parse(sec3));
                        ss = " (星期='" + days + "' and 节次='" + sec + "') ";
                        if (c == 0)
                            if (f == 1)
                                str += " and ( " + ss;
                            else
                                str += " ( " + ss;
                        else
                            str += " or " + ss;
                        c = 1;
                    }
                    if (sec4.Trim() != "undefined")
                    {
                        sec = returnSec(int.Parse(sec4));
                        days = returnDay(int.Parse(sec4));
                        ss = " (星期='" + days + "' and 节次='" + sec + "') ";
                        if (c == 0)
                            if (f == 1)
                                str += " and ( " + ss;
                            else
                                str += " ( " + ss;
                        else
                            str += " or " + ss;
                        c = 1;
                    }
                    if (sec5.Trim() != "undefined")
                    {
                        sec = returnSec(int.Parse(sec5));
                        days = returnDay(int.Parse(sec5));
                        ss = " (星期='" + days + "' and 节次='" + sec + "') ";
                        if (c == 0)
                            if (f == 1)
                                str += " and ( " + ss;
                            else
                                str += " ( " + ss;
                        else
                            str += " or " + ss;
                        c = 1;
                    }
                    if (c == 1)
                        str += " )";
                    if (!string.IsNullOrWhiteSpace(courseName.Trim()))
                    {
                        if (f == 1)
                            str += " and 课程='" + courseName + "'";
                        else
                        {
                            f = 1;
                            str = " 课程='" + courseName + "'";
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(classs.Trim()))
                    {
                        if (f == 1)
                            str += " and 班级='" + classs + "'";
                        else
                        {
                            f = 1;
                            str = " 班级='" + classs + "'";
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(tea.Trim()))
                    {
                        if (f == 1)
                            str += " and 教师='" + tea + "'";
                        else
                        {
                            f = 1;
                            str = " 教师='" + tea + "'";
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(lab.Trim()))
                    {
                        if (f == 1)
                            str += " and 实验室='" + lab + "'";
                        else
                        {
                            f = 1;
                            str = " 实验室='" + lab + "'";
                        }
                    }

                    if (string.IsNullOrWhiteSpace(str))
                    {
                        DataTable d = sortByweekSecDay(table);
                        return d;
                    }
                    DataTable dtt = table.Clone();
                    DataRow[] arry = table.Select(str);
                    for (int i = 0; i < arry.Length; i++)
                    {
                        dtt.Rows.Add(arry[i].ItemArray);
                    }
                    DataTable dttt = sortByweekSecDay(dtt);
                    return dttt;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable findMisiion(string labID)
        {
            try
            {
                DataTable dt = r.findCourse(labID);
                DataTable dd = r.findLabinfo(dt.Rows[0]["lab"].ToString());
                DataTable table = r.findDetail(labID);
                DataTable finalDt = new DataTable();
                finalDt.Columns.Add("实验室名称");
                finalDt.Columns.Add("实验室门标");
                finalDt.Columns.Add("课程名称");
                finalDt.Columns.Add("总学时");
                finalDt.Columns.Add("项目个数");
                finalDt.Columns.Add("教师");
                finalDt.Columns.Add("班级");
                finalDt.Columns.Add("人数");
                finalDt.Columns.Add("项目");
                finalDt.Columns.Add("周次");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = finalDt.NewRow();
                    int a = table.Rows.Count;
                    row[0] = dd.Rows[0]["remark2"].ToString();
                    row[1] = dd.Rows[0]["name"].ToString();
                    row[2] = dt.Rows[0]["courseName"].ToString();
                    row[3] = (a * 2).ToString();
                    row[4] = a.ToString();
                    row[5] = dt.Rows[0]["teacher"].ToString();
                    row[6] = dt.Rows[0]["classs"].ToString();
                    row[7] = dt.Rows[0]["count"].ToString();
                    row[8] = table.Rows[i]["project"].ToString();
                    row[9] = table.Rows[i]["week"].ToString();
                    finalDt.Rows.Add(row.ItemArray);
                }
                return finalDt;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public DataTable findCourseDesign(string courseName, string classs, string tea, string lab)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("序号");
                table.Columns.Add("课程");
                table.Columns.Add("班级");
                table.Columns.Add("周次");
                table.Columns.Add("组别");
                table.Columns.Add("人数");
                table.Columns.Add("地点");
                table.Columns.Add("教师");

                DataTable dd = r.findCourseDesign(courseName, classs, tea, lab);
                if (dd.Rows.Count > 0)
                {
                    for (int j = 0; j < dd.Rows.Count; j++)
                    {
                        DataTable dt = r.findDetail(dd.Rows[j]["id"].ToString());
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow row = table.NewRow();
                            row[0] = (j + 1).ToString();
                            row[1] = dd.Rows[j]["courseName"].ToString();
                            row[2] = dd.Rows[j]["classs"].ToString();
                            row[3] = dt.Rows[i]["week"].ToString();
                            row[4] = dd.Rows[j]["groups"].ToString();
                            row[5] = dd.Rows[j]["count"].ToString();
                            row[6] = dd.Rows[j]["lab"].ToString();
                            row[7] = dd.Rows[j]["teacher"].ToString();
                            table.Rows.Add(row.ItemArray);
                            break;
                        }
                    }
                    return table;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 按照周次节次星期排序
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable sortByweekSecDay(DataTable dt)
        {
            DataTable newDt = null;
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["星期"] = returnNum(dt.Rows[i]["星期"].ToString());
                    dt.Rows[i]["节次"] = returnSecNum(dt.Rows[i]["节次"].ToString());
                }
                //设置dt的周次类型为int类型  方便排序
                newDt = dt.Clone();
                newDt.Columns["周次"].DataType = typeof(int);
                foreach (DataRow row in dt.Rows)
                {
                    newDt.ImportRow(row);
                }
                DataView view = newDt.DefaultView;
                view.Sort = "周次 asc,星期 asc,节次 asc";
                newDt = view.ToTable();
                for (int i = 0; i < newDt.Rows.Count; i++)
                {
                    newDt.Rows[i]["星期"] = returnChinese(newDt.Rows[i]["星期"].ToString());
                    newDt.Rows[i]["节次"] = returnSec(newDt.Rows[i]["节次"].ToString());
                }
            }
            return newDt;
        }
        public DataTable findBy(string courseName, string classs, string tea, string lab, string user)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("课程");
                table.Columns.Add("班级");
                table.Columns.Add("教师");
                table.Columns.Add("周次");
                table.Columns.Add("星期");
                table.Columns.Add("节次");
                table.Columns.Add("人数");
                table.Columns.Add("组别");
                table.Columns.Add("实验室");
                table.Columns.Add("操作人");
                table.Columns.Add("提交时间");

                table.Columns.Add("项目名称");
                table.Columns.Add("是否综合性");
                table.Columns.Add("detailID");
                table.Columns.Add("courseID");
                DataTable dd = r.findBy(courseName, classs, tea, lab, user);
                if (dd != null)
                {
                    if (dd.Rows.Count > 0)
                    {
                        for (int j = 0; j < dd.Rows.Count; j++)
                        {
                            DataTable dt = r.findDetail(dd.Rows[j]["id"].ToString());
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataRow row = table.NewRow();
                                row[0] = dd.Rows[j][1].ToString();
                                row[1] = dd.Rows[j][2].ToString();
                                row[2] = dd.Rows[j][3].ToString();
                                row[3] = dt.Rows[i]["week"].ToString();
                                row[4] = dt.Rows[i]["remark1"].ToString();
                                row[5] = dt.Rows[i]["remark2"].ToString();
                                row[6] = dd.Rows[j]["count"].ToString();
                                row[7] = dd.Rows[j]["groups"].ToString();
                                row[8] = dd.Rows[j]["lab"].ToString();
                                row[9] = dd.Rows[j]["person"].ToString();
                                row[10] = dd.Rows[j]["time"].ToString();
                                row[11] = dt.Rows[i]["project"].ToString();
                                if (dt.Rows[i][2].ToString().Trim() == "0")
                                    row[12] = "否";
                                else
                                    row[12] = "是";
                                row[13] = dt.Rows[i][0].ToString();
                                row[14] = dd.Rows[j][0].ToString();
                                table.Rows.Add(row.ItemArray);
                            }
                        }
                    }
                    return table;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string deleteAll(LabCourse c)
        {
            r.deleteAll(c);
            return "";
        }
        public string delete(CourseDetail c)
        {
            r.delete(c);
            return "";
        }
        public string update(string project, string Is, string id)
        {
            r.update(project, Is, id);
            return "";
        }
        public string getone(string id)
        {
            return JsonCast.DataTableToJSON(r.getone(id), false).ToString();
        }
    }
}
