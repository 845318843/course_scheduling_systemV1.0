using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityClass
{
    /// <summary> 	/// 实体类
    /// </summary>
    public class Teacher
    {
        #region 成员

        private int _id;
        private string _TeacherName;
        private string _Department;
        private string _Major;

        #endregion

        #region 属性

        /// <summary>
        /// 工号
        /// </summary>
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 老师姓名
        /// </summary>
        public string TeacherName
        {
            get { return _TeacherName; }
            set { _TeacherName = value; }
        }
        /// <summary>
        /// 院系
        /// </summary>
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
        /// <summary>
        /// 专业
        /// </summary>
        public string Major
        {
            get { return _Major; }
            set { _Major = value; }
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
                case "id": return false;
                case "TeacherName": return true;
                case "Department": return true;
                case "Major": return true;
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
                case "id": return true;
                case "TeacherName": return true;
                case "Department": return true;
                case "Major": return true;
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
                case "id": return "工号";
                case "TeacherName": return "老师姓名";
                case "Department": return "院系";
                case "Major": return "专业";
                default: return null;
            }
        }

        #endregion

    }
}
