using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
	/// <summary>
	/// 实验课选课实体类
	/// </summary>
	public class LabCourse
	{
		#region 成员

		private Int64 _id;
		private string _courseName;
		private string _class;
		private string _teacher;
		private string _week;
		private string _section;
		private string _count;
		private string _groups;
		private string _lab;
		private string _time;
		private string _person;
		private string _remark1;
		private string _remark2;
		private string _remark3;
		private string _remark4;

		#endregion

		#region 属性

		/// <summary>
		/// 主键
		/// </summary>
		public Int64 id
		{
			get { return _id; }
			set { _id = value; }
		}
		/// <summary>
		/// 课程名
		/// </summary>
		public string courseName
		{
			get { return _courseName; }
			set { _courseName = value; }
		}
		/// <summary>
		/// 班级
		/// </summary>
		public string classs
		{
			get { return _class; }
			set { _class = value; }
		}
		/// <summary>
		/// 指导教师
		/// </summary>
		public string teacher
		{
			get { return _teacher; }
			set { _teacher = value; }
		}
		/// <summary>
		/// 星期
		/// </summary>
		public string week
		{
			get { return _week; }
			set { _week = value; }
		}
		/// <summary>
		/// 节次
		/// </summary>
		public string section
		{
			get { return _section; }
			set { _section = value; }
		}
		/// <summary>
		/// 人数
		/// </summary>
		public string count
		{
			get { return _count; }
			set { _count = value; }
		}
		/// <summary>
		/// 组别
		/// </summary>
		public string groups
		{
			get { return _groups; }
			set { _groups = value; }
		}
		/// <summary>
		/// 实验室
		/// </summary>
		public string lab
		{
			get { return _lab; }
			set { _lab = value; }
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public string time
		{
			get { return _time; }
			set { _time = value; }
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public string person
		{
			get { return _person; }
			set { _person = value; }
		}
		/// <summary>
		/// 备注1
		/// </summary>
		public string remark1
		{
			get { return _remark1; }
			set { _remark1 = value; }
		}
		/// <summary>
		/// 备注2
		/// </summary>
		public string remark2
		{
			get { return _remark2; }
			set { _remark2 = value; }
		}
		/// <summary>
		/// 备注3
		/// </summary>
		public string remark3
		{
			get { return _remark3; }
			set { _remark3 = value; }
		}
		/// <summary>
		/// 备注4
		/// </summary>
		public string remark4
		{
			get { return _remark4; }
			set { _remark4 = value; }
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
				case "courseName": return true;
				case "class": return true;
				case "teacher": return true;
				case "week": return true;
				case "section": return true;
				case "count": return true;
				case "groups": return true;
				case "lab": return true;
				case "time": return true;
				case "person": return true;
				case "remark1": return true;
				case "remark2": return true;
				case "remark3": return true;
				case "remark4": return true;
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
				case "id": return false;
				case "courseName": return true;
				case "class": return true;
				case "teacher": return true;
				case "week": return true;
				case "section": return true;
				case "count": return true;
				case "groups": return true;
				case "lab": return true;
				case "time": return true;
				case "person": return true;
				case "remark1": return true;
				case "remark2": return true;
				case "remark3": return true;
				case "remark4": return true;
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
				case "id": return "主键";
				case "courseName": return "课程名";
				case "class": return "班级";
				case "teacher": return "指导教师";
				case "week": return "星期";
				case "section": return "节次";
				case "count": return "人数";
				case "groups": return "组别";
				case "lab": return "实验室";
				case "time": return "上传时间";
				case "person": return "操作人";
				case "remark1": return "备注1";
				case "remark2": return "备注2";
				case "remark3": return "备注3";
				case "remark4": return "备注4";
				 default: return null;
			}
		}

		#endregion

	}
}

