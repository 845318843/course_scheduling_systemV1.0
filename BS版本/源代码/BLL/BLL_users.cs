using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_users
    {
        DAL_users du = new DAL_users();
        public bool updateMission(string name)
        {
            return du.updateMission(name);
        }
        public bool reset()
        {
            return du.reset();
        }
        public bool backUp()
        {
            return du.backUp();
        }
        public bool reBack()
        {
            return du.reBack();
        }
        public bool clear()
        {
            return du.clear();
        }
        public void pwd(string name, string pwd)
        {
            du.pwd(name, pwd);
        }
        public bool judgeExist(string name)
        {
            return du.judgeExist(name);
        }
        //判断用户名重复
        public bool judgeRepeat(string name)
        {
            return du.judgeRepeat(name);
        }
        //获取该用户的所有   管理的实验室的门标
        public string  findUserRole(string name)
        {
            return JsonCast.DataTableToJSON( du.findUserRole(name),false).ToString();
        }
        public string findAll()
        {
            return JsonCast.DataTableToJSON( du.findAll(),false).ToString();
        }
        public string delete(string id)
        {
            du.delete(id);
            return "";
        }

        public string insert(Users u)
        {
            du.insert(u);
            return "";
        }

        public string updata(Users u)
        {
            du.update(u);
            return "";
        }

        public string judge(string str1, string str2)
        {
            //if (du.judgeName(str1) == false)
            //    return "用户名不存在";
            //else
            //{
                string  str = du.judgeIs(str1, str2);
                if (string.IsNullOrWhiteSpace(str))
                    return "用户名与密码不匹配";
                else
                    return str;
            //}
        }
        public string getOne(string id)
        {
            return JsonCast.DataTableToJSON(du.getOne(id), false).ToString();
        }
    }
}
