using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityClass
{
	/// <summary>
	/// 管理员实验室权限实体类
	/// </summary>
	public class UserRole
	{
		#region 成员

		private Int64 _id;
		private string _uName;
		private string _doorNum;
		private string _remark1;
		private string _remark2;
		private string _remark3;

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
		/// 用户名字
		/// </summary>
		public string uName
		{
			get { return _uName; }
			set { _uName = value; }
		}
		/// <summary>
		/// 门牌号
		/// </summary>
		public string doorNum
		{
			get { return _doorNum; }
			set { _doorNum = value; }
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
				case "uName": return true;
				case "doorNum": return true;
				case "remark1": return true;
				case "remark2": return true;
				case "remark3": return true;
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
				case "uName": return true;
				case "doorNum": return true;
				case "remark1": return true;
				case "remark2": return true;
				case "remark3": return true;
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
				case "uName": return "用户名字";
				case "doorNum": return "门牌号";
				case "remark1": return "备注1";
				case "remark2": return "备注2";
				case "remark3": return "备注3";
				 default: return null;
			}
		}

		#endregion

	}
}

