using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_users
    {
        DAL_common d = new DAL_common();
        SqlDB sql = new SqlDB();
        string str = "";
        Users u = new Users();
        //重置任务完成情况
        public bool reset()
        {
            try
            {
                str = "update Users set remark1='未完成'";
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// sql语句备份数据库
        /// </summary>
        /// <returns></returns>
        public bool backUp()
        {
            str = "BACKUP DATABASE LabCourseSystem TO DISK='" + System.Web.HttpContext.Current.Server.MapPath("../backUp/") + "LabCourseSystem.bak' ;";
            //str += "BACKUP log LabCourseSystem TO DISK='" + System.Web.HttpContext.Current.Server.MapPath("../backUp/") + "LabCourseSystemLog.bak' ;";
            //删除原有的备份
            System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath("../backUp/") + "LabCourseSystemLog.bak");
            System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath("../backUp/") + "LabCourseSystem.bak");
            return sql.ExecSql(str);
        }
        /// <summary>
        /// sql语句还原数据库
        /// </summary>
        /// <returns></returns>
         public bool reBack()
        {
             //先离线再上线以此获得数据库的  访问权限
            str = "ALTER DATABASE LabCourseSystem SET OFFLINE WITH ROLLBACK IMMEDIATE ;";
            str += "ALTER database LabCourseSystem set online ;";
            str += "use master ;RESTORE database LabCourseSystem FROM DISK = '" + System.Web.HttpContext.Current.Server.MapPath("../backUp/") + "LabCourseSystem.bak' with replace;use LabCourseSystem;";
            //str += "use master ;RESTORE log LabCourseSystem FROM DISK = '" + System.Web.HttpContext.Current.Server.MapPath("../backUp/") + "LabCourseSystemLog.bak' with replace;use LabCourseSystem;";
            return sql.ExecSql(str);
        }

        public bool clear()
        {
            try
            {
                str = "delete from LabCourse";
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataTable findAll()
        {
            return d.findAll(u);
        }
        /// <summary>
        /// 反馈排课完成情况
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool updateMission(string name)
        {
            try
            {
                str = "update Users set remark1='已完成' where name='"+name+"'";
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }
        //判断用户名重复
        public bool judgeRepeat(string name)
        {
            try
            {
                bool b = false;
                str = "select name from Users where name='" + name + "'";
                DataTable dt = sql.FillDt(str);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        b = true;
                    }
                }
                return b;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //获取该用户的所有   管理的实验室的门标
        public DataTable findUserRole(string name)
        {
            try
            {
                str = "select name from LabInfo where remark3='"+name+"' ";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool delete(string id)
        {
            u.id = int.Parse(id);
            return d.delete(u);
        }

        public bool update(Users u)
        {
            return d.update(u);
        }

        public bool insert(Users u)
        {
            return d.insert(u);
        }
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="str1">用户名</param>
        /// <returns>bool值</returns>
        public bool judgeName(string str1)
        {
            try
            {
                str = "select name from Users where name='" + str1 + "'";
                DataTable dd = sql.FillDt(str);
                if (dd.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 判断用户名与密码是否匹配
        /// </summary>
        /// <param name="str1">用户名</param>
        /// <param name="str2">密码</param>
        /// <returns>bool值</returns>
        public string judgeIs(string str1, string str2)
        {
            try
            {
                str = "select name,role from Users where name='" + str1 + "' and pwd='" + str2 + "'";
                DataTable dd = sql.FillDt(str);
                if (dd.Rows.Count > 0)
                    return dd.Rows[0][1].ToString();
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        public void pwd(string name,string pwd)
        {
            str = "update Users set pwd='"+pwd+"' where name='"+name+"'";
            sql.ExecSql(str);
        }
        public bool judgeExist(string name)
        {
            str = "select * from Users where name='"+name+"'";
            if (sql.FillDt(str).Rows.Count > 0)
                return false;
            return true;
        }
        public DataTable getOne(string id)
        {
            try
            {
                str = "select * from Users where id=" + id + "";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
