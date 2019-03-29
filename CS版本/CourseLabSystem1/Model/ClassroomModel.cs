using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityClass
{
    /// <summary> 	/// 实体类
    /// </summary>
    public class Classroom
    {
        #region 成员

        public string _Classroom_Id;
        public string _Building_Id;
        public string _Name;
        public string _Descride;
        public int _People;
        public string _manager;

        #endregion

        #region 属性

        /// <summary>
        /// 门牌号
        /// </summary>
        public string Classroom_Id
        {
            get { return _Classroom_Id; }
            set { _Classroom_Id = value; }
        }
        /// <summary>
        /// 教学楼id
        /// </summary>
        public string Building_Id
        {
            get { return _Building_Id; }
            set { _Building_Id = value; }
        }
        /// <summary>
        /// 教室名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 教室简介
        /// </summary>
        public string Descride
        {
            get { return _Descride; }
            set { _Descride = value; }
        }
        /// <summary>
        /// 可容纳人数
        /// </summary>
        public int People
        {
            get { return _People; }
            set { _People = value; }
        }
        /// <summary>
        /// 管理员
        /// </summary>
        public string manager
        {
            get { return _manager; }
            set { _manager = value; }
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
                case "Classroom_Id": return false;
                case "Building_Id": return true;
                case "Name": return true;
                case "Descride": return true;
                case "People": return true;
                case "manager": return true;
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
                case "Classroom_Id": return true;
                case "Building_Id": return true;
                case "Name": return true;
                case "Descride": return true;
                case "People": return true;
                case "manager": return true;
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
                case "Classroom_Id": return "门牌号";
                case "Building_Id": return "教学楼id";
                case "Name": return "教室名称";
                case "Descride": return "教室简介";
                case "People": return "可容纳人数";
                case "manager": return "管理员";
                default: return null;
            }
        }

        #endregion

    }
}
