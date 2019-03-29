using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityClass;

namespace DAL
{
    
    public class ApplyDAL
    {
        
        SqlDB db = new SqlDB();
        public string sr2 = null;
        DataTable dt = new DataTable();
        string B_ID=null;
        string CM = null;
        string WK = null;
        string WY = null;
        string Term = null;
        string Year = null;
        string Course = null;
        string Garde = null;
        string Department = null;
        string Class = null;
        string Teacher = null;
        string Reason = null;
        string Section = null;
        //SqlParameter[] paras = null;
        /// <summary>
        /// 教学楼显示出来
        /// </summary>
        /// <returns></returns>
        public SqlDataReader Building_IdShow(int key)
        {
            string sqlst = null;
            if (key == 1)                     //找教学楼
            {
                sqlst = "SELECT DISTINCT ABS(Building_Id) FROM Classroom order by ABS(Building_Id)";
            }
            else if(key==2)                   //通过教学楼找教室
            {
                sqlst = "SELECT DISTINCT name FROM Classroom WHERE Building_Id='" + sr2 + "' order by name";
            }
            SqlDataReader sr1 = db.GetDataReader(sqlst);//找出来
            return sr1;
        }
        /// <summary>
        /// 返回表的操作
        /// </summary>
        /// <param name="KEY">key值决定调用那条sql语句</param>
        /// <returns></returns>
        public DataTable dtShow(int KEY)
        {
            string sqlst = null ;
            int key = KEY;
            if (KEY == 1)            //通过教学楼，教室，第几周，周几查出详细课程
            {
                sqlst = "SELECT DISTINCT Building_Id AS 教学楼,Name AS 教室,'" + WK + "' AS 第几周,Weekday AS 周几,Section AS 节次 FROM CourseBuild WHERE Building_Id='" + B_ID + "' AND Name='" + CM + "' AND Week LIKE '%" + WK + "%' AND Weekday='" + WY + "' order by Section";
            }
            else if (KEY == 2)       //查出节次
            {
                sqlst = "SELECT Section FROM CourseBuild WHERE Building_Id='"+B_ID+"' AND Name='"+CM+"' AND Week LIKE '%"+WK+"%' AND Weekday='"+WY+"'";
            }
            else if (KEY == 3)
            {
                sqlst = "SELECT Building_Id,Name,Week,Weekday,Section,Course,Garde,Department,Class,Teacher,Year,Term,reason From CourseBuild WHERE Building_Id='" + B_ID + "'AND Name='" + CM + "' AND Week LIKE '%" + WK + "%' AND Weekday='" + WY + "' AND Section='" + Section + "' AND Course='" + Course + "' AND Garde='" + Garde + "' AND Department='" + Department + "' AND Class='" + Class + "' AND Teacher ='"+Teacher+"'";
            }
            dt = db.FillDt(sqlst);
            return dt;
        }
        public bool InsertApply()
        {
            //插入活动
            try
            {
                string sqlit = "INSERT INTO CourseBuild(Building_Id,Department,Garde,Name,Week,Weekday,Section,Teacher,Course,Class,Year,Term,reason) Values ('" + B_ID + "','" + Department + "','" + Garde + "','" + CM + "','" + WK + "','" + WY + "','" + Section + "','" + Teacher + "','" + Course + "','" + Class + "','" + Year + "','" + Term + "','" + Reason + "')";
                if (db.ExecSql(sqlit))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 教学楼id
        /// </summary>
        /// <param name="str"></param>
        public void getstr(string str)
        {
            sr2 = str;
        }
        /// <summary>
        /// 传递控件的值
        /// </summary>
        /// <param name="model"></param>
        public void GetControl(CourseBuild model)
        {
            //SqlParameter[] paras = { new SqlParameter("@B_ID", model.Building_Id), new SqlParameter("@CM", model.Name), new SqlParameter("@WK", model.Week), new SqlParameter("@WY", model.Weekday)};
            B_ID = model.Building_Id;
            CM = model.Name;
            WK = model.Week;
            WY = model.Weekday;
            Term = model.Term;
            Year = model.Year;
            Course = model.Course;
            Garde = model.Garde;
            Department = model.Department;
            Class = model.Class;
            Teacher = model.Teacher;
            Reason = model.reason;
            Section = model.Section;
        }

    }
}
