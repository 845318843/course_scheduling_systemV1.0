using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Model;
using EntityClass;
using System.Data.SqlClient;
namespace BLL
{   

    public partial class CourseBuildingBLL
    {
        public static int number = 0;//要添加的数目
        CourseBuildingDAL dal = new CourseBuildingDAL();
        public SqlDataReader GetOne(string year,string term,string garde,string Class,string de)
        {   
            return dal.GetOne( year, term, garde, Class,de);
        }
        public void delete(string whole)
        {
            dal.delete(whole);
        }
        /// <summary>
        /// 获取数据库的信息
        /// </summary>
        /// <returns></returns>
        public SqlDataReader getWhole1()
        {
            return dal.getWhole2();
        }
        /// <summary>
        /// 树形导航第二个node获取
        /// </summary>
        /// <param name="name1"></param>
        /// <returns></returns>
        public DataTable GetNode2(string name1)
        {
            return dal.GetNode2(name1);
        }
        /// <summary>
        /// 树形导航第一个node获取
        /// </summary>
        /// <returns></returns>
        public DataTable GetNode1()
        {   
            return dal.GetNode1();
        }
        /// <summary>
        /// 返回所在班级的院系
        /// </summary>
        /// <returns></returns>
        public string getbuilding1(string name)
        {
            return dal.getBuilding2(name);
        }
        /// <summary>
        /// 获取教室
        /// </summary>
        /// <param name="information"></param>
        /// <returns></returns>
        public DataTable LoadCmbCs(string garde,string de)
        {
            return dal.LoadCmbCs(garde,de);
        }
        /// <summary>
        /// 获取院系
        /// </summary>
        /// <param name="information"></param>
        /// <returns></returns>
        public List<Basic_Information> LoadCmbdt(Basic_Information information)
        {
            return dal.LoadCmbdt(information);
        }
        /// <summary>
        /// 获取年级列表
        /// </summary>
        /// <returns></returns>
        public List<Basic_Information> GetLoadCobGrd()
        {
            return dal.LoadCobGrd();
        }
        /// <summary>
        /// 获取教学楼列表
        /// </summary>
        /// <returns></returns>
        public DataTable GETSome()
        {
                return dal.LoadBuilding();
        }
        /// <summary>
        /// 获取对应教学楼的教室列表
        /// </summary>
        /// <param name="Class"></param>
        /// <returns></returns>
        public DataTable SelectSome(string Class)
        {
             return dal.Class(Class);
        }
        /// <summary>
        /// 获取专业
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetMajor(string name)
        {
            return dal.GetMajor(name);
        }
        /// <summary>
        /// 获取课程
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetCourse1(string name)
        {
            return dal.GetCourse1( name);
        }

        public bool insert(string s1, string s2, string s3, string s4,string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12)
        {
            if (dal.Insert(s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 将添加的课表添加到数据库
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool insert(List<CourseBuild> course)
        {   
            if(dal.Insert(course))
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
