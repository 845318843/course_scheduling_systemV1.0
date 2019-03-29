using BLL;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LabCourseSys.webservice
{
    /// <summary>
    /// userService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class userService : System.Web.Services.WebService
    {
        BLL_users u = new BLL_users();
        [WebMethod]
        public string judgeRepeat(string name)
        {
          
            if (u.judgeRepeat(name))
                return "重复";
            return "不";
        }

        /// <summary>
        /// 管理员重新启动  word生成通道
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string closeWordProcess()
        {
            Process[] vProcesses = Process.GetProcesses();
            foreach (Process vProcess in vProcesses)
            {

                if (vProcess.ProcessName.Equals("WINWORD",
                StringComparison.OrdinalIgnoreCase))
                {
                    //vProcess.Close();
                    vProcess.Kill();
                }
            }
            return "";
        }
        [WebMethod]
        public string reset()
        {
            u.reset();
            return "";
        }
        [WebMethod]
        public string clear()
        {
            u.clear();
            return "";
        }
        [WebMethod]
        public string updateMission(string name)
        {
            u.updateMission(name);
            return "";
        }
        [WebMethod]
        public string findUserRole(string name)
        {
            u.findUserRole(name);
            return "";
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string findAll()
        {
            string str = u.findAll();
            return str;
        }
          [WebMethod]
        public string backUp()
        {
           du.backUp();
           return "";
        }
          [WebMethod]
        public string reBack()
        {
           du.reBack();
           return "";
        }
        [WebMethod]
        public string login(string name, string pwd)
        {
            return u.judge(name, pwd);
        }
        BLL_users du = new BLL_users();


        [WebMethod]
        public string delete(string id)
        {
            du.delete(id);
            return "";
        }
        [WebMethod]
        public string insert(string name, string pwd, string role, string des)
        {
            Users u = new Users();
            u.remark1 = "未完成";
            u.name = name;
            u.pwd = pwd;
            u.role = role;
            u.describe = des;
            du.insert(u);
            return "";
        }
        [WebMethod]
        public string update(string name, string pwd, string role, string des, string id, string mission)
        {
            Users u = new Users();
            u.remark1 = mission;
            u.name = name;
            u.pwd = pwd;
            u.role = role;
            u.describe = des;
            u.id = int.Parse(id);
            du.updata(u);
            return "";
        }
        [WebMethod]
        public string pwd(string name, string pwd)
        {
            du.pwd(name, pwd);
            return "";
        }
        [WebMethod]
        public string getOne(string id)
        {
            return du.getOne(id);
        }
    }
}
