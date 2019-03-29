using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;

namespace BLL
{
    public class ApplyBLL
    {
        SqlDataReader sr1 = null;
        ApplyDAL dal = new ApplyDAL();
        DataTable dt = new DataTable();
        public string srID2 = null;
        //public string ceshi = null;
        /// <summary>
        /// 寻找教学楼ID
        /// </summary>
        /// <param name="sqlst">寻找教学楼ID的sql语句</param>
        /// <returns></returns>
        public SqlDataReader Building_IdShow(int key)
        {
            if (key == 2)
            {
                dal.getstr(srID2);                     //教学楼的value传递给sql语句
            }
            int KEY=key;
            sr1 = dal.Building_IdShow(KEY);
            return sr1;
        }
        /// <summary>
        /// 传递控件的值
        /// </summary>
        /// <param name="b_id">教学楼ID</param>
        /// <param name="cm">教室</param>
        /// <param name="wk">几周</param>
        /// <param name="wy">周几</param>
        public void ControlValue(CourseBuild model)
        {
            dal.GetControl(model);
        }
        /// <summary>
        /// 传递表
        /// </summary>
        /// <returns></returns>
        public DataTable dtShow(int KEY)
        {
            int key=KEY;
            dt = dal.dtShow(key);                          
            return dt;
        }
        /// <summary>
        /// 查找是否存在课程冲突
        /// </summary>
        /// <param name="top">选择课程的上限</param>
        /// <param name="down">所选课程的下限</param>
        /// <param name="model">model类</param>
        /// <returns></returns>
        public bool SelectSection(string top,string down,CourseBuild model)
        {
            int key = 2;
            int k = 0;
            int TOP = Convert.ToInt32(top);
            int DOWN = Convert.ToInt32(down);
            string st = null;
            string[] array = null;
            dal.GetControl (model);
            dt = dal.dtShow(key);
            for (int j = 0; j < dt.Rows.Count; j++)
            {

                st = dt.Rows[j][0].ToString();        //得到节次
                array = st.Split(',');                //把节次中的','删除
                int s = array.Length;
                if (TOP <= Convert.ToInt32(array[0]) && DOWN >= Convert.ToInt32(array[s - 1]))   //top=1,down=4, 3,4
                {
                    k = 1;
                    break;
                }
            }   
            if (k == 1)                              //存在课程冲突
                return false;
            else
                return true;
        }
        /// <summary>
        /// 插入申请的课程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertApply(CourseBuild model)
        {
            dal.GetControl(model);
            if (dal.InsertApply())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //生成word表格
        public void ToWord(CourseBuild model,string mm,string pe)
        {
            int key=3;
            dal.GetControl(model);    //传值
            dt = dal.dtShow(key);     //得到记录;
            dt.Rows[0][10] = mm;
            dt.Rows[0][11] = pe;
            ToWord toword = new ToWord();
            toword.CourseTable1(dt, "申请表", "申请表");
        }
    }
}
