using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    /// <summary> 	/// 实体类
    /// </summary>
    public class AddCourse
    {
        #region 成员

        private int _Course_Id;
        private string _Course;
        private string _Department;

        #endregion

        #region 属性

        /// <summary>
        /// 课程ID
        /// </summary>
        public int Course_Id
        {
            get { return _Course_Id; }
            set { _Course_Id = value; }
        }
        /// <summary>
        /// 课程
        /// </summary>
        public string Course
        {
            get { return _Course; }
            set { _Course = value; }
        }
        /// <summary>
        /// 院系
        /// </summary>
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 判断实体（表）主键，如果是主键返回 false,否则返回true
        /// </summary>
        /// <param name=AttributeName>属性名</param>
        /// <returns></returns>
        static public bool primary(string AttributeName)
        {
            switch (AttributeName)
            {
                case "Course_Id": return false;
                case "Course": return true;
                case "Department": return true;
                default: return true;
            }
        }
        /// <summary>
        /// 判断实体（表）字段是否自增，如果是自增返回 false,否则返回true
        /// </summary>
        /// <param name=AttributeName>属性名</param>
        /// <returns></returns>
        static public bool remind(string AttributeName)
        {
            switch (AttributeName)
            {
                case "Course_Id": return true;
                case "Course": return true;
                case "Department": return true;
                default: return true;
            }
        }
        /// <summary>
        ///返回每个字段的的注释
        /// </summary>
        /// <param name=AttributeName>属性名</param>
        /// <returns></returns>
        static public string Note(string AttributeName)
        {
            switch (AttributeName)
            {
                case "Course_Id": return "课程ID";
                case "Course": return "课程";
                case "Department": return "院系";
                default: return null;
            }
        }

        #endregion

    }
}
