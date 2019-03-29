using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using EntityClass;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DAL
{
    public class CourseBuildingDAL
    {
        public SqlDataReader GetOne(string year, string term, string garde, string Class,string de)
        {
            string sql = "select *from CourseBuild where Year='" + year + "' and Term='" + term + "' and garde='" + garde + "' and Class='" + Class + "' and Department='"+de+"'";
            SqlDB db = new SqlDB();
            return db.GetDataReader(sql);
        }
        public void delete(string whole)
        {
            string[] Sum = whole.Split('|');
                string sql = "delete from CourseBuild where Building_Id='" + Sum[1] + "' AND Department='" + Sum[0] + "' AND Garde='" + Sum[6] + "' AND Name='" + Sum[2] + "' AND Week='" + Sum[5] + "' AND Weekday='" + Sum[8] + "' AND Section='" + Sum[9] + "' AND Teacher='" + Sum[4] + "' AND Course='" + Sum[3] + "' AND Class='" +Sum[7]+ "' AND Year='" + Sum[10] + "' AND Term='" + Sum[11] + "'";
            SqlDB db = new SqlDB();
            db.ExecSql(sql);
        }
        /// <summary>
        /// 返回数据库信息
        /// </summary>
        /// <returns></returns>
        public SqlDataReader getWhole2()
        {
            SqlDB db = new SqlDB();
            string sql = "select * from CourseBuild";
            SqlDataReader reader=db.GetDataReader(sql);
            return reader;
        }
        /// <summary>
        /// 返回list实体类的年级信息
        /// sqldb是基层辅助类 用来对数据库的基本操作
        /// </summary>
        /// <returns></returns>
       public List<Basic_Information> LoadCobGrd()
        {
            List<Basic_Information> list = new List<Basic_Information>();
            string sql = "select Garde from Basic_Information GROUP BY Garde";
            SqlDB db = new SqlDB();
            DataTable dt = db.FillDt(sql);
            foreach (DataRow item in dt.Rows)
            {
                Basic_Information information = new Basic_Information();
                information.Garde =item["Garde"].ToString();
                list.Add(information);
            }
            return list;
        }
       SqlDataReader reader = null;
       public string getBuilding2(string Class)
       {
           SqlDB db = new SqlDB();

           string sql = "select distinct department from Basic_Information WHERE class='" + Class + "'";
           string name = "";
           reader=db.GetDataReader(sql);
           while (reader.Read())
           {   
               name += reader.GetString(0);
           }
           reader.Close();
           return name;
       }
        /// <summary>
        /// 根据年级查找院系并将班级list实体化返回
        /// </summary>
        /// <param name="Grade"></param>
        /// <returns></returns>
       public DataTable LoadCmbCs(string garde,string de)
       {
           SqlDB db = new SqlDB();
           string sql = "select ClassId,Class from Basic_Information where Department='" + de + "' and Garde='" + garde + "'";
           DataTable dt = new DataTable();
           dt = db.FillDt(sql);
           return dt;
       }
        /// <summary>
       /// 根据院系查找班级并将班级list实体化返回
        /// </summary>
        /// <param name="Grade"></param>
        /// <returns></returns>
       public List<Basic_Information> LoadCmbdt(Basic_Information Grade)
       {
           SqlDB db = new SqlDB();
           string sql = "select distinct Department from Basic_Information where Garde='" + Grade.Garde + "'";
           List<Basic_Information> list = new List<Basic_Information>();
           DataTable dt = new DataTable();
           dt = db.FillDt(sql);
           foreach (DataRow item in dt.Rows)
           {
               Basic_Information information = new Basic_Information();
               information.Department = item["Department"].ToString();
               list.Add(information);
           }
           return list;
       }
        /// <summary>
        /// 返回教学楼列表
        /// </summary>
        /// <returns></returns>
       public DataTable LoadBuilding()
       {
           List<Classroom> list = new List<Classroom>();
           SqlDB db = new SqlDB();
           DataTable dt = new DataTable();
           string sql = "select distinct ABS(Building_Id) as Building_Id from Classroom order by ABS(Building_Id) ";
           dt = db.FillDt(sql);

           return dt;
       }
        /// <summary>
        /// 根据教学楼的id返回对应教室的集合
        /// </summary>
        /// <param name="xx"></param>
        /// <returns></returns>
       public DataTable Class(string xx)
        {
            DataTable dt = new DataTable();
                SqlDB db = new SqlDB();
                string sql = "select Classroom_Id,Name from Classroom where Building_Id='" + xx + "' order by Classroom_Id";
                dt = db.FillDt(sql);

                return dt;
        }
        /// <summary>
        /// 得到treeview的第一个节点
        /// </summary>
        /// <returns></returns>
       public DataTable GetNode1()
       {   
           DataTable ds=new DataTable();
           string strsql = "select Department from Teacher GROUP BY Department";
           SqlDB db = new SqlDB();
           ds = db.FillDt(strsql);
           return ds;
       }
        /// <summary>
       /// 得到treeview的第2个节点
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
       public DataTable GetNode2(string name)
       {
           DataTable ds = new DataTable();
           string strql = "select TeacherName from Teacher where Department='" + name + "'";
           SqlDB db = new SqlDB();
           ds = db.FillDt(strql);
           return ds;
       }
       public string GetMajor(string name)
       {
           DataTable ds = new DataTable();
           string strql = "select Major from Teacher where TeacherName='" + name + "'";
           SqlDB db = new SqlDB();
           ds = db.FillDt(strql);
           string major = ds.Rows[0][0].ToString();

           return major;
       }
       public DataTable GetCourse1(string name)
       {
           DataTable dt = new DataTable();
           string sql = "select Course,Course_Id from AddCourse where Department='" + name + "'";
           SqlDB db = new SqlDB();
           dt = db.FillDt(sql);
           return dt;
       }
        /// <summary>
        /// 将课表数据插入数据库
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool Insert(List<CourseBuild> course)
        {
            string sql="INSERT INTO CourseBuild(Building_Id,Department,Garde,Name,Week,Weekday,Section,Teacher,Course,Class,Year,Term,reason)";
            for (int i = 0; i <course.Count-1; i++ )
            {
                sql += "select " + course[i].Building_Id + ",'" + course[i].Department + "'," + "'" + course[i].Garde + "'," + "'" + course[i].Name + "'," + "'" + course[i].Week + "'," + "'" + course[i].Weekday + "'," + "'" + course[i].Section + "'," + "'" + course[i].Teacher + "'," + "'" + course[i].Course + "'," + "'" + course[i].Class + "'," + "'" + course[i].Year + "'," + "'" + course[i].Term + "'," + "'" + course[i].reason + "' union all ";
            }
            sql += "select " + course[course.Count - 1].Building_Id + ",'" + course[course.Count - 1].Department + "'," + "'" + course[course.Count - 1].Garde + "'," + "'" + course[course.Count - 1].Name + "'," + "'" + course[course.Count - 1].Week + "'," + "'" + course[course.Count - 1].Weekday + "'," + "'" + course[course.Count - 1].Section + "'," + "'" + course[course.Count - 1].Teacher + "'," + "'" + course[course.Count - 1].Course + "'," + "'" + course[course.Count - 1].Class + "'," + "'" + course[course.Count - 1].Year + "'," + "'" + course[course.Count - 1].Term + "'," + "'" + course[course.Count - 1].reason +"'";
                SqlDB db = new SqlDB();
                if (db.ExecSql(sql))
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        public bool Insert(string s1, string s2, string s3, string s4,string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12)
        {
            string sql = "INSERT INTO CourseBuild(Building_Id,Department,Garde,Name,Week,Weekday,Section,Teacher,Course,Class,Year,Term,reason) values ('" +s1+"','"+s2+"','"+s3+"','"+s4+"','"+s5+"','"+s6+"','"+s7+"','"+s8+"','"+s9+"','"+s10+"','"+s11+"','"+s12 +"' ,'"+" ')";
            SqlDB db = new SqlDB();
            if (db.ExecSql(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
