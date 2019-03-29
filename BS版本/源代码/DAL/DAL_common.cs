using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DAL_common
    {
        string str = "";
        SqlDB sql = new SqlDB();
        public DataTable findAll<T>(T a)
        {
            try
            {
                str = DBOperate.sqlLoadAll(a);
                DataTable dt = new DataTable();
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool update<T>(T a)
        {
            try
            {
                str = DBOperate.sqlUpdtae(a);
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool delete<T>(T a)
        {
            try
            {
                str = DBOperate.sqlDelete(a);
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool insert<T>(T a)
        {
            try
            {
                str = DBOperate.sqlInsert(a);
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
