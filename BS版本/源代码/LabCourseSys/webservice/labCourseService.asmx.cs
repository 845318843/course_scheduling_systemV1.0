using BLL;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LabCourseSys.webservice
{
    /// <summary>
    /// labCourseService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class labCourseService : System.Web.Services.WebService
    {
        BLL_labCourse l = new BLL_labCourse();
        LabCourse ll = new LabCourse();
        CourseDetail cc = new CourseDetail();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string insertDetail(string project, string Is, string week, string day, string section, string courseID)
        {
            if (project == "undefined")
            {
                project = "";
            }
            cc.project = project;
            cc.isComprehensive = Is;
            cc.week = week;
            cc.remark1 = day;
            cc.remark2 = section;
            cc.remark3 = courseID;
            l.insertDetail(cc);
            return "";
        }


        BLL_users u = new BLL_users();
        //获取该用户的所有   管理的实验室的门标

        [WebMethod]
        public string findUserRole(string name)
        {
            string str= u.findUserRole(name);
            return str;
        }


        [WebMethod]
        public string fresh(string user)
        {
            l.fresh(user);
            return "";
        }
        [WebMethod]
        public string insert(string course, string classs, string teacher, string count, string num, string lab, string labNo, string person)
        {
            ll.classs = classs;
            ll.count = count;
            ll.teacher = teacher;
            ll.courseName = course;
            ll.groups = num;
            ll.lab = lab;
            ll.remark1 = labNo;
            ll.time = DateTime.Now.ToString();
            ll.person = person;
            l.insert(ll);
            return nums();
        }
        public string nums()
        {
            string ss = l.num();
            return "{\"id\"," + ss + "}";
        }
        [WebMethod]
        public string function(string no, string type, string num, string user)
        {
            Functions f = new Functions();
            f.remark1 = user;
            f.no = no;
            f.num = num;
            f.type = type;
            l.function(f);
            return "";
        }

        [WebMethod]
        public string designOne(string one, string num, string user)
        {
            if (one == "1")
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (i <= 5 || i >= 8)
                    {
                        Functions f = new Functions();
                        f.no = i.ToString();
                        f.num = num;
                        f.remark1 = user;
                        f.type = "section";
                        l.function(f);
                    }
                }
            }
            else
            {
                for (int i = 15; i <= 26; i++)
                {
                    if (i <= 19 || i >= 22)
                    {
                        Functions f = new Functions();
                        f.no = i.ToString();
                        f.num = num;
                        f.remark1 = user;
                        f.type = "section";
                        l.function(f);
                    }
                }
            }
            return "";
        }
        [WebMethod]
        public string findFunction(string num)
        {
            return l.findFunction(num);
        }
        [WebMethod]
        public string findSec(string type)
        {
            return l.findSec(type);
        }
        [WebMethod]
        public string findRecord(string labNo)
        {
            return l.findRecord(labNo);
        }
 
        ToWord t = new ToWord();
        [WebMethod]
        public string createCourse(string labNo)
        {
            int a = 0;
            DataTable dt = l.createCourse(labNo);
            DataTable dd = new DataTable();
            dd.Columns.Add("节次");
            dd.Columns.Add("一");
            dd.Columns.Add("二");
            dd.Columns.Add("三");
            dd.Columns.Add("四");
            dd.Columns.Add("五");
            dd.Columns.Add("六");
            dd.Columns.Add("日");
            for (int i = 6; i < dt.Rows.Count; i++)
            {
                DataRow r = dd.NewRow();
                if (i == 6)
                    r[0] = "1.2";
                else if (i == 7)
                    r[0] = "3.4";
                else if (i == 8)
                    r[0] = "5.6";
                else if (i == 9)
                    r[0] = "7.8";
                else if (i == 10)
                    r[0] = "9.10";
                for (int j = 0; j < dt.Columns.Count + 1; j++)
                {
                    if (j != 0)
                        r[j] = dt.Rows[i][j - 1].ToString();
                }
                dd.Rows.Add(r.ItemArray);
            }
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            return JsonCast.DataTableToJSON(dt, false).ToString();
        }
        [WebMethod]
        public string createT(string labNo)
        {
            int a = 0;
            DataTable dt = l.createCourse(labNo);
            DataTable dd = new DataTable();
            dd.Columns.Add("节次");
            dd.Columns.Add("一");
            dd.Columns.Add("二");
            dd.Columns.Add("三");
            dd.Columns.Add("四");
            dd.Columns.Add("五");
            dd.Columns.Add("六");
            dd.Columns.Add("日");
            for (int i = 6; i < dt.Rows.Count; i++)
            {

                DataRow r = dd.NewRow();
                if (i == 6)
                    r[0] = "1.2";
                else if (i == 7)
                    r[0] = "3.4";
                else if (i == 8)
                    r[0] = "5.6";
                else if (i == 9)
                    r[0] = "7.8";
                else if (i == 10)
                    r[0] = "9.10";
                for (int j = 0; j < dt.Columns.Count + 1; j++)
                {
                    if (j != 0)
                        r[j] = dt.Rows[i][j - 1].ToString();
                }
                dd.Rows.Add(r.ItemArray);
            }
            string url = Server.MapPath("~//file//课表.doc");
            t.CourseTable1(dd, url, dt.Rows[5][0].ToString());
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            return "";
        }
    }
}
