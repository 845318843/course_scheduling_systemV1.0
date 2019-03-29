using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public class SettingBLL
    {
        SettingDAL std = new SettingDAL();

        /// <summary>
        /// 得到老师数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTeacher()
        {
            return std.GetTeacher();
        }

        /// <summary>
        /// 按条件搜索
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable SearchTeacher(string id, string name)
        {
            return std.SearchTeacher(id, name);
        }

        public bool Addteacher(string id, string name, string department, string major)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(major))
            {
                if (std.Addteacher(id, name, department, major))
                    return true;
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("请完善信息");
                return false;
            }
        }

        public bool Deleteteacher(bool b,string id)
        {
            if (b)
            {
                if (std.Deleteteacher(id))
                    return true;
                return false;
            }
            else
                return false;
        }

        public bool ChangeTea(int id, string Teachername, string department, string major)
        {
            return std.ChangeTea(id, Teachername, department, major);
        }

        /// <summary>
        /// 得到管理员数据
        /// </summary>
        public DataTable GetAdmin()
        {
            return std.GetAdmin();
        }


        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="major"></param>
        /// <returns></returns>
        public bool Addadmin(string id, string name, string pwd,string role)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(pwd) && !string.IsNullOrEmpty(role))
            {
                if (std.Addadmin(id, name, pwd,role))
                    return true;
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("请完善信息");
                return false;
            }
        }

        public bool Deleteadmin(bool b, string name)
        {
            if (b)
            {
                if (std.Deleteadmin(name))
                    return true;
                return false;
            }
            else
                return false;
        }


        public bool ChangeAdmin(int id, string name, string pwd)
        {
            return std.ChangeAdmin(id,name,pwd);
        }
    }
}
