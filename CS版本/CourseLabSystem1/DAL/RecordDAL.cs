using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using NPOI;
using EntityClass;

namespace DAL
{
    public class RecordDAL
    {
        string sql = "";
        DataTable dt;//声明一个表格对象，用于返回
        List<DataTable> list = new List<DataTable>();
        SqlDB sqldb = new SqlDB();

        //窗体加载的时候加载 系别 年级 老师
        public List<DataTable> FormLoad()
        {
            sql = "select distinct Department from CourseBuild";
            list.Add(sqldb.FillDt(sql));
            sql = "select distinct Garde from Basic_Information ";
            list.Add(sqldb.FillDt(sql));
            sql = "select distinct TeacherName from Teacher where TeacherName in (select teacher from CourseBuild)";
            list.Add(sqldb.FillDt(sql));
            return list;
        }
        //department系别改变 时 加载 教室名称
        public DataTable Department_TextChanged(string department)
        {
            string sql = "select distinct Name from CourseBuild where Department='" + department + "'";
            dt = sqldb.FillDt(sql);
            return dt;
        }
        //garde年级改变 时 加载 班级
        public DataTable Garde_TextChanged(string garde)
        {
            string sql = "select distinct Class from CourseBuild where Garde = '" + garde + "'";
            dt = sqldb.FillDt(sql);
            return dt;
        }
        //查找
        public DataTable Search(int num, CourseBuild CourseBuild)
        {
            string sql = "select Building_Id as 教学楼,Department as 系院,Garde as 年级, Name as 教室,Week as 周节,Weekday as 星期,Section 节次,Teacher as 任课老师,Course as 课程名称,Class as 班级, Year as 学年,Term as 学期,reason as 说明 from CourseBuild where";
            switch (num)
            {
                case 1://根据系别
                    sql += " Department= '" + CourseBuild.Department + "'";
                    break;
                case 2://根据系别和教室
                    sql += " Department= '" + CourseBuild.Department + "' and Name='" + CourseBuild.Name + "'";
                    break;
                case 3://根据老师
                    sql += " Teacher='" + CourseBuild.Teacher + "'";
                    break;
                case 4://根据年级
                    sql += " Garde='" + CourseBuild.Garde + "'";
                    break;
                case 5://根据年级和班级
                    sql += " Garde='" + CourseBuild.Garde + "' and Class='" + CourseBuild.Class + "'";
                    break;
            }
            return sqldb.FillDt(sql);
            // return dt;
        }

        //导出Excel
        public void DtToExcel(DataTable dt)
        {
            NPOI.DtToExcel(dt, "默认文件名");
        }
    }
}
