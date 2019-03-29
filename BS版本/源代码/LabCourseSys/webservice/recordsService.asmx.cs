using BLL;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LabCourseSys.webservice
{
    /// <summary>
    /// recordsService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
   [System.Web.Script.Services.ScriptService]
    public class recordsService : System.Web.Services.WebService
    {
        BLL_records r = new BLL_records();
        ToWord toWord = new BLL.ToWord();

        [WebMethod]
        public string recordDemo(string courseName, string classs, string tea, string lab, string week, string sec1, string sec2, string sec3, string sec4, string sec5)
        {
            return JsonCast.DataTableToJSON(r.recordDemo(courseName, classs, tea, lab, week, sec1, sec2, sec3, sec4, sec5), false).ToString();
        }
        //判断word进程是否运行
        [WebMethod]
        public string wordProcess()
        {
            Process[] vProcesses = Process.GetProcesses();
            foreach (Process vProcess in vProcesses)
            {

                if (vProcess.ProcessName.Equals("WINWORD",
                StringComparison.OrdinalIgnoreCase))
                {
                    return "运行";
                }
            }
            return "未运行";
        }
        [WebMethod]
        public string mission(string labID)
        {
            DataTable dt = r.findMisiion(labID);
            DataTable newDt = dt.Clone();
            newDt.Columns["周次"].DataType = typeof(int);

            foreach (DataRow row in dt.Rows)
            {
                newDt.ImportRow(row);
            }
            DataView view = newDt.DefaultView;
            view.Sort = "周次 asc";
            newDt = view.ToTable();
            string title = "南阳理工学院";
            int m = int.Parse(DateTime.Now.Month.ToString());
            int y = int.Parse(DateTime.Now.Year.ToString());
            if (m >= 2 && m <= 8)
                title += y - 1 + "-" + y + "年第2学期实验教学任务书";
            else
                title += y + "-" + (y + 1) + "年第1学期实验教学任务书";
            string url = Server.MapPath("~//file//实验教学任务书.doc");
            toWord.mission(newDt, url, title);
            return "";
        }
        [WebMethod]
        public string newmission(string labID)
        {
            DataTable dt = r.findMisiion(labID);
            DataTable newDt = dt.Clone();
            newDt.Columns["周次"].DataType = typeof(int);

            foreach (DataRow row in dt.Rows)
            {
                newDt.ImportRow(row);
            }
            DataView view = newDt.DefaultView;
            view.Sort = "周次 asc";
            newDt = view.ToTable();
            string title = "南阳理工学院";
            int m = int.Parse(DateTime.Now.Month.ToString());
            int y = int.Parse(DateTime.Now.Year.ToString());
            if (m >= 2 && m <= 8)
                title += y - 1 + "-" + y + "年第2学期实验教学任务书";
            else
                title += y + "-" + (y + 1) + "年第1学期实验教学任务书";
            string url = Server.MapPath("~//file//实验教学任务书.doc");
            toWord.newMission(newDt, url, title);
            return "";
        }
        [WebMethod]
        public string findBy(string courseName, string classs, string tea, string lab, string user)
        {
            DataTable dd = r.findBy(courseName, classs, tea, lab, user);
            //if (dd != null)
            //{
            //    if (dd.Rows.Count > 0)
            //    {
            //        string url = Server.MapPath("~//file//排课记录.xls");
            //        n.ExportToExcel(dd, "排课记录", url);
            //    }
            //}
            if (dd != null)
            {
                string ss = JsonCast.DataTableToJSON(dd, false).ToString();
                return ss;
            }
            else
                return "";
        }
        [WebMethod]
        public string delete(string id)
        {
            CourseDetail c = new CourseDetail();
            c.id = int.Parse(id);
            r.delete(c);
            return "";
        }
        [WebMethod]
        public string deleteAll(string id)
        {
            LabCourse c = new LabCourse();
            c.id = int.Parse(id);
            r.deleteAll(c);
            return "";
        }
        [WebMethod]
        public string update(string project, string Is, string id)
        {
            r.update(project, Is, id);
            return "";
        }
        [WebMethod]
        public string getone(string id)
        {
            return r.getone(id);
        }
        [WebMethod]
        public string findCourseDesign(string courseName, string classs, string tea, string lab, string user)
        {
            try
            {
                DataTable dt = r.findCourseDesign(courseName, classs, tea, lab);
                string title = "南阳理工学院";
                int m = int.Parse(DateTime.Now.Month.ToString());
                int y = int.Parse(DateTime.Now.Year.ToString());
                if (m >= 2 && m <= 8)
                    title += y - 1 + "-" + y + "年第2学期" + lab + "课程设计汇总";
                else
                    title += y + "-" + (y + 1) + "年第1学期" + lab + "课程设计汇总";
                string url = Server.MapPath("~//file//课程设计汇总.doc");

                string str = toWord.courseDesign(dt, url, title);


                return str;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
        [WebMethod]
        public string weekCourse(string courseName, string classs, string tea, string lab, string user)
        {
            DataTable dd = r.findBy(courseName, classs, tea, lab, user);
            DataTable table = r.sortByweekSecDay(dd);
            DataTable dt = weekTable(table);
            string title = "南阳理工学院";
            int m = int.Parse(DateTime.Now.Month.ToString());
            int y = int.Parse(DateTime.Now.Year.ToString());
            if (m >= 2 && m <= 8)
                title += y - 1 + "-" + y + "年第2学期" + lab + "实验教学周课表";
            else
                title += y + "-" + (y + 1) + "年第1学期" + lab + "实验教学周课表";
            string url = Server.MapPath("~//file//实验教学周课表.doc");
            toWord.weekCourse(dt, url, title);
            return "";
        }
        public DataTable weekTable(DataTable dt)
        {
            DataTable dd = new DataTable();
            dd.Columns.Add("序号");
            dd.Columns.Add("课程名称");
            dd.Columns.Add("班级");
            dd.Columns.Add("指导教师(年龄,职称(学历))");
            dd.Columns.Add("项目名称");
            dd.Columns.Add("是否是综合性,设计性项目");
            dd.Columns.Add("周次");
            dd.Columns.Add("星期");
            dd.Columns.Add("节次");
            dd.Columns.Add("人数");
            dd.Columns.Add("组别");
            dd.Columns.Add("实验室");
            if (dt != null)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow r = dd.NewRow();
                    r["序号"] = (i + 1).ToString();
                    r["课程名称"] = dt.Rows[i]["课程"].ToString();
                    r["班级"] = dt.Rows[i]["班级"].ToString();
                    r["指导教师(年龄,职称(学历))"] = dt.Rows[i]["教师"].ToString();
                    r["项目名称"] = dt.Rows[i]["项目名称"].ToString();
                    r["是否是综合性,设计性项目"] = dt.Rows[i]["是否综合性"].ToString();
                    r["周次"] = dt.Rows[i]["周次"].ToString();
                    r["星期"] = dt.Rows[i]["星期"].ToString();
                    r["节次"] = dt.Rows[i]["节次"].ToString();
                    r["人数"] = dt.Rows[i]["人数"].ToString();
                    r["组别"] = dt.Rows[i]["组别"].ToString();
                    r["实验室"] = dt.Rows[i]["实验室"].ToString();
                    dd.Rows.Add(r.ItemArray);
                }
            return dd;
        }
    }
}
