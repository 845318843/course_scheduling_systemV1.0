using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DAL
{
    public class SettingDAL
    {
        public DataTable GetTeacher()
        {
            SqlDB db = new SqlDB();
            string strsql = "select  id as 工号,TeacherName as 姓名, Department as 学院,Major as 专业 from Teacher order by id";
            DataTable dt = db.FillDt(strsql);
            return dt;
        }

        public DataTable SearchTeacher(string id, string name)
        {
            SqlDB db = new SqlDB();
            string strsql = "select  id as 工号,TeacherName as 姓名, Department as 学院,Major as 专业 from Teacher ";
            string strwhere = "";
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (string.IsNullOrWhiteSpace(strwhere))
                    strwhere += "where";
                strwhere += " id like '%" + id + "%' ";
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrWhiteSpace(strwhere))
                {
                    strwhere += " where ";
                }
                else
                {
                    strwhere += " and ";
                }
                strwhere += " TeacherName like '%" + name + "%' ";
            }
            strsql += strwhere +"order by id";
            DataTable dt = db.FillDt(strsql);
            return dt;
        }

        public bool Addteacher(string id, string name, string department, string major)
        {
            SqlDB db = new SqlDB();
            if (db.ExecSql("insert into teacher(id,TeacherName,Department,Major) values('" + id + "','" + name + "','" + department + "','" + major + "')"))
            {
                return true;
            }
            return false;
        }

        public bool Deleteteacher(string id)
        {
            SqlDB db = new SqlDB();
            string strsql = "delete from teacher where id='" + id + "'";
            if (db.ExecSql(strsql))
            {
                return true;
            }
            return false;
        }

        public bool ChangeTea(int id, string Teachername, string department, string major)
        {
            SqlDB db = new SqlDB();
            string strsql = "update Teacher set TeacherName = '" + Teachername + "',Department = '" + department + "', Major ='" + major + "' where id = '" + id + "'";
            if (db.ExecSql(strsql))
                return true;
            return false;
        }

        public DataTable GetAdmin()
        {
            SqlDB db = new SqlDB();
            string strsql = "select  id as ID,UsersName as 用户名, PassWord as 密码 from Users";
            DataTable dt = db.FillDt(strsql);
            return dt;
        }

        public string GetMd5Hash(string input)//讲 string型 转换为MD5加密
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(input))).Replace("-", "");
            }
        }

        public bool Addadmin(string id, string name, string pwd,string role)
        {
            SqlDB db = new SqlDB();
            string Md5str = GetMd5Hash(pwd);
            string str = "insert into Users(id,UsersName,PassWord,role) values('" + id + "','" + name + "','" + Md5str + "','"+role+"')";
            if (db.ExecSql(str))
            {
                return true;
            }
            return false;
        }

        public bool Deleteadmin(string name)
        {
            SqlDB db = new SqlDB();
            string strsql = "delete from Users where UsersName='" + name + "'";
            if (db.ExecSql(strsql))
            {
                return true;
            }
            return false;
        }

        public bool ChangeAdmin(int id, string name, string pwd)
        {
            SqlDB db = new SqlDB();
            string Md5str = GetMd5Hash(pwd);
            string strsql = "update Users set UsersName = '" + name + "',PassWord = '" + Md5str+ "' where id = '" + id + "'";
            if (db.ExecSql(strsql))
                return true;
            return false;
        }
    }
}
