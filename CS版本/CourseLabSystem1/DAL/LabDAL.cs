using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LabDAL
    {
       

        public static DataTable update()//static。
        {
            string sql = "select ABS(building_id) as 教学楼,name as 教室名称,ABS(classroom_id) as 教室门牌号,people as 教室可容纳人数,manager as 教室管理员,descride as 教室信息 from classroom order by ABS(building_id) ,ABS(classroom_id) asc";
            SqlDB db = new SqlDB();
            DataTable dt = db.FillDt(sql);
            return dt;
        }

        public bool add(string build, string name,string classroom_id, string people, string manager, string descride)
        {
            string str = "insert into classroom(classroom_id,building_id,name,people,manager,descride)values(" + "'" +classroom_id+"','"+ build + "','" + name + "','" + people + "','" + manager + "','" + descride + "')";
            SqlDB db = new SqlDB();
            db.ExecSql(str);
            return true;
        }

        public bool modify(string _build, string _name,string _classroom_id, string _people, string _manager, string _descride)
        {
            string str = "update Classroom set Building_id='" + _build + "',Name='" + _name +"',classroom_id='"+_classroom_id+"',People='" + _people + "',Manager='" + _manager + "',Descride='" + _descride + "'where classroom_id='" + _classroom_id + "'";
            SqlDB db = new SqlDB();
            db.ExecSql(str);
            return true;
        }

        public bool delete(string _classroom_id)//(string _build, string _name, string _people, string _manager, string _descride)
        {
            string str = "delete from classroom where classroom_id='" + _classroom_id + "'";
            SqlDB db = new SqlDB();
            db.ExecSql(str);
            return true;
        }
    }
}
