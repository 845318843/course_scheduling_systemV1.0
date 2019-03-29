using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityClass;

namespace BLL
{
    public class RecordBLL
    {
        public RecordBLL()
        {

        }
        //创建DAL类的实例
        RecordDAL recordDAL = new RecordDAL();
       // CourseBuildMODEL courseBuildMODEL = new CourseBuildMODEL();
        public List<DataTable> FormLoad()//窗体加载时的事件
        {
            return recordDAL.FormLoad();
        }
        public DataTable Department_TextChanged(string department)//Department系别改变时 
        {
            return recordDAL.Department_TextChanged(department);
        }
        public DataTable Garde_TextChanged(string garde)//Garde年级改变时
        {
            return recordDAL.Garde_TextChanged(garde);
        }
        public DataTable Search(int num,CourseBuild courseBuild)//查找
        {
            return recordDAL.Search(num, courseBuild);
        }
        public void DtToExcel(DataTable dt)//保存为Excel格式
        {
           recordDAL.DtToExcel(dt);
        }
    }
}
