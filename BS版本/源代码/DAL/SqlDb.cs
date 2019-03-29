using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public  class SqlDB
{
    public SqlConnection conn = null;
    public SqlCommand cmd = null;
    public SqlDataAdapter dA = null;
    public SqlCommandBuilder cmdB = null;
    private SqlDataReader sdr = null;

    public SqlDB()
    {
        //conn = new SqlConnection(@"server=.;DataBase=LabCourseSystem;uid=sa;pwd=123");
        //string conStr = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnetString"].ConnectionString.ToString());
        // conn = new SqlConnection(@"server=.;DataBase=StockDb;uid=sa;pwd=123");
        //conn = new SqlConnection(@"Data Source=FISH-PC\SQLSERVER;Initial Catalog=NYFood1;User ID=sa;Password=sa;Trusted_Connection=False;");
        //conn = new SqlConnection(@"Data Source=DUODUO\SQLSERVER;Initial Catalog=NYFood1;Integrated Security=True"); 
        cmd = new SqlCommand();
        cmd.Connection = conn;

    }

    public SqlDB(string conStr)
    {
        conn = new SqlConnection(conStr);
        cmd = new SqlCommand();
        cmd.Connection = conn;
        dA = new SqlDataAdapter("", conn);
    }
    /// <summary>
    /// 执行各种SQL语句 删除、插入
    /// </summary>
    /// <param name="sqlStr">true表示执行成功,false表示执行失败</param>
    /// <returns></returns>
    public bool ExecSql(string sqlStr)
    {
        try
        {
            int i;
            conn.Open();
            cmd = new SqlCommand(sqlStr, conn);
            i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 对连接执行 Transact-SQL 语句并返回受影响的行数。错误返回-1
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <param name="para"></param>
    /// <returns></returns>
    public bool executeSql(string sqlstr, SqlParameter[] para = null)
    {
        int i = -1;
        conn.Open();
        SqlCommand sc = new SqlCommand(sqlstr, conn);
        try
        {
            foreach (SqlParameter item in para)
            {
                sc.Parameters.Add(item);
            }
            i = sc.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            sc.Dispose();
        }
        return i > 0;
    }

    /// <summary>
    /// 根据查询语句，将查询结果以DataTable类型返回，如果执行的是各种更新语句，则返回值无意义。
    /// </summary>
    /// <param name="selectSql"></param>
    /// <returns>查询结果</returns>
    public DataTable FillDt(string selectSql)
    {
        DataTable dt = new DataTable();
        dA = new SqlDataAdapter(selectSql, conn);
        dA.Fill(dt);
        return dt;
    }

    /// <summary>
    /// 根据查询语句，将查询结果以DataSet类型返回，如果执行的是各种更新语句，则返回值无意义。
    /// </summary>
    /// <param name="selectSql"></param>
    /// <returns>查询结果</returns>
    public DataSet FillDs(string selectSql)
    {
        DataSet ds = new DataSet();
        dA.SelectCommand.CommandText = selectSql;
        dA.Fill(ds);
        return ds;
    }

    /// <summary>
    /// 获得DataReader对象，使用完毕后必须关闭DataReader，而且要关闭数据连接
    /// </summary>
    /// <param name="strSql">sql语句</param>
    /// <returns></returns>
    public SqlDataReader GetDataReader(string strSql)
    {
        conn.Open();
        cmd = new SqlCommand(strSql, conn);
        sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return sdr;
    }

    /// <summary>
    /// 执行更新语句，将dt中的数据更新到数据库中，其更新语句由 Select语句通过SqlCommandBuilder对象自动生成。
    /// </summary>
    /// <param name="selectSql"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public bool UpdateDt(string selectSql, DataTable dt)
    {
        try
        {
            bool r = false;
            dA.SelectCommand.CommandText = selectSql;
            cmdB = new SqlCommandBuilder(dA);
            dA.Update(dt);
            r = true;
            return r;
        }
        catch (Exception)
        {

            return false;
        }

    }
    /// <summary>
    /// 执行多条SQL语句，实现数据库事务。
    /// </summary>
    /// <param name="SQLStringList">多条SQL语句</param>    
    public int ExecuteSqlTran(List<String> SQLStringList)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        SqlTransaction tx = conn.BeginTransaction();
        cmd.Transaction = tx;
        try
        {
            int count = 0;
            for (int n = 0; n < SQLStringList.Count; n++)
            {
                string strsql = SQLStringList[n];
                if (strsql.Trim().Length > 1)
                {
                    cmd.CommandText = strsql;
                    count += cmd.ExecuteNonQuery();
                }
            }
            tx.Commit();
            return count;
        }
        catch
        {
            tx.Rollback();
            return 0;
        }
    }
    /// <summary>
    /// 执行存储过程，返回影响的行数     
    /// </summary>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数</param>
    /// <param name="rowsAffected">影响的行数</param>
    /// <returns></returns>
    //public int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
    //{
    //    int result;
    //    conn.Open();
    //    SqlCommand command = new SqlCommand(storedProcName, conn);
    //    command.CommandType = CommandType.StoredProcedure;
    //    if (parameters != null && parameters.Length > 0)
    //    {
    //        foreach (SqlParameter pp in parameters)//把参数集全部加进去
    //            command.Parameters.Add(pp);
    //    }
    //    command.Parameters.Add("@return", "").Direction = ParameterDirection.ReturnValue;
    //    rowsAffected = command.ExecuteNonQuery();
    //    result = (int)command.Parameters["@return"].Value;
    //    conn.Close();
    //    return result;
    //}
    /// <summary>
    /// 执行存储过程
    /// </summary>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数</param>
    /// <param name="tableName">DataSet结果中的表名</param>
    /// <returns>DataSet</returns>
    public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
    {
        DataSet dataSet = new DataSet();
        SqlCommand com = new SqlCommand(storedProcName, conn);
        com.CommandType = CommandType.StoredProcedure;
        if (parameters != null && parameters.Length > 0)
        {
            foreach (SqlParameter pp in parameters)//把参数集全部加进去
                com.Parameters.Add(pp);
        }

        SqlDataAdapter adpter = new SqlDataAdapter(com);
        adpter.Fill(dataSet, tableName);
        return dataSet;
    }
}

