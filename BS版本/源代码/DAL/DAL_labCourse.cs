using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_labCourse
    {
        DAL_common c = new DAL_common();
        SqlDB sql = new SqlDB();
        string str = "";
        public bool insert(LabCourse l)
        {
            return c.insert(l);
        }
        public DataTable findCourseByLab(string labNo)
        {
            try
            {
                str = "select * from LabCourse where remark1='" + labNo + "'";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable findDetailByCno(string cno)
        {
            try
            {
                str = "select * from CourseDetail where remark3='" + cno + "' ";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string num()
        {
            str = "select top 1 id from LabCourse order by id desc";
            return sql.FillDt(str).Rows[0][0].ToString();
        }

        public bool function(Functions f)
        {
            str = "select * from Functions where no='" + f.no + "' and [type]='"+f.type+"'";
            DataTable dd = sql.FillDt(str);
            if (dd != null)
            {
                if (dd.Rows.Count > 0)
                    return sql.ExecSql("delete from Functions where no='" + f.no + "' and [type]='" + f.type + "'");
            }
            return c.insert(f);
        }

        public DataTable findFunction(string num)
        {
            try
            {
                str = "select * from functions where num='" + num + "' order by [type]";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable  findSec(string type)
        {
            try
            {
                str = "select * from functions  where type='"+type+"'";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool insertDetail(CourseDetail cc)
        {
            try
            {
                return c.insert(cc);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool fresh(string user)
        {
            str = "delete from Functions where remark1='"+user+"'";
            sql.ExecSql(str);
            str = "dbcc checkident(Functions,reseed,0) ";
            sql.ExecSql(str);
            return true;
        }
    }
}
