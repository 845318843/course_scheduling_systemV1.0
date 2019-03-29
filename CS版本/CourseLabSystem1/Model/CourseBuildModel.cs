using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityClass
{
    /// <summary> 	/// 实体类
    /// </summary>
    public class CourseBuild
    {
        #region 成员

        private string _Building_Id;
        private string _Department;
        private string _Garde;
        private string _Name;
        private string _Week;
        private string _Weekday;
        private string _Section;
        private string _Teacher;
        private string _Course;
        private string _Class;
        private string _Year;
        private string _Term;
        private string _reason;

        #endregion

        #region 属性

        /// <summary>
        /// 教学楼id
        /// </summary>
        public string Building_Id
        {
            get { return _Building_Id; }
            set { _Building_Id = value; }
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
        /// 年级
        /// </summary>
        public string Garde
        {
            get { return _Garde; }
            set { _Garde = value; }
        }
        /// <summary>
        /// 教师名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 第几周
        /// </summary>
        public string Week
        {
            get { return _Week; }
            set { _Week = value; }
        }
        /// <summary>
        /// 周几
        /// </summary>
        public string Weekday
        {
            get { return _Weekday; }
            set { _Weekday = value; }
        }
        /// <summary>
        /// 节次
        /// </summary>
        public string Section
        {
            get { return _Section; }
            set { _Section = value; }
        }
        /// <summary>
        /// 老师
        /// </summary>
        public string Teacher
        {
            get { return _Teacher; }
            set { _Teacher = value; }
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
        /// 班级
        /// </summary>
        public string Class
        {
            get { return _Class; }
            set { _Class = value; }
        }
        /// <summary>
        /// 学年
        /// </summary>
        public string Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        /// <summary>
        /// 学期
        /// </summary>
        public string Term
        {
            get { return _Term; }
            set { _Term = value; }
        }
        /// <summary>
        /// 原因
        /// </summary>
        public string reason
        {
            get { return _reason; }
            set { _reason = value; }
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
                case "Building_Id": return true;
                case "Department": return true;
                case "Garde": return true;
                case "Name": return true;
                case "Week": return true;
                case "Weekday": return true;
                case "Section": return true;
                case "Teacher": return true;
                case "Course": return true;
                case "Class": return true;
                case "Year": return true;
                case "Term": return true;
                case "reason": return true;
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
                case "Building_Id": return true;
                case "Department": return true;
                case "Garde": return true;
                case "Name": return true;
                case "Week": return true;
                case "Weekday": return true;
                case "Section": return true;
                case "Teacher": return true;
                case "Course": return true;
                case "Class": return true;
                case "Year": return true;
                case "Term": return true;
                case "reason": return true;
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
                case "Building_Id": return "教学楼id";
                case "Department": return "院系";
                case "Garde": return "年级";
                case "Name": return "教师名称";
                case "Week": return "第几周";
                case "Weekday": return "周几";
                case "Section": return "节次";
                case "Teacher": return "老师";
                case "Course": return "课程";
                case "Class": return "班级";
                case "Year": return "学年";
                case "Term": return "学期";
                case "reason": return "原因";
                default: return null;
            }
        }

        #endregion

    }
}
