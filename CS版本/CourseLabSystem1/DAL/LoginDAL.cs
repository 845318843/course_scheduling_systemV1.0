using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class LoginDAL
    {
        SqlDB sqlDB = new SqlDB();
        DataTable dt = new DataTable();

        public bool ExiseUser(string userid)//判断用户是否存在
        {
            bool exise = false;
            string sql = string.Format("select * from Users where UsersName='{0}'", userid);
            using (SqlDataReader myreader = sqlDB.GetDataReader(sql))
            {
                if (myreader.HasRows)//如果返回的有结果
                {
                    exise = true;
                }
            }
            return exise;
        }
        public string UserPwd(string user)//根据名字找 pwd
        {
            string sql = "select PassWord from Users where UsersName='" + user + "'";
            dt = sqlDB.FillDt(sql);
            return dt.Rows[0]["PassWord"].ToString();
        }
        public int Role(string user)
        {
            int role;
            string sql = "select role from Users where UsersName='" + user + "'";
            dt = sqlDB.FillDt(sql);
            role = Convert.ToInt32(dt.Rows[0]["role"]);
            return role;
        }
        public bool BackPwd(UsersModel user)//修改密码 后更新
        {
            string sql = "update Users set PassWord='" + user.PassWord + "' where id='" + user.id + "' and UsersName='" + user.UsersName+"'";
            return sqlDB.ExecSql(sql);
            
        }
    }
}
