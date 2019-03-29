using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    /// <summary> 	/// 实体类
    /// </summary>
    public class Basic_Information
    {
        #region 成员

        private string _Garde;
        private int _ClassId;
        private string _Class;
        private string _Department;

        #endregion

        #region 属性

        /// <summary>
        /// 年级
        /// </summary>
        public string Garde
        {
            get { return _Garde; }
            set { _Garde = value; }
        }
        /// <summary>
        /// 班级号
        /// </summary>
        public int ClassId
        {
            get { return _ClassId; }
            set { _ClassId = value; }
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
                case "Garde": return true;
                case "ClassId": return false;
                case "Class": return true;
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
                case "Garde": return true;
                case "ClassId": return true;
                case "Class": return true;
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
                case "Garde": return "年级";
                case "ClassId": return "班级号";
                case "Class": return "班级";
                case "Department": return "院系";
                default: return null;
            }
        }

        #endregion

    }
}
