using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace DAL
{
    public class DAL_records
    {
        SqlDB sql = new SqlDB();
        string str = "";

        public DataTable recordDemo(string courseName, string classs, string tea, string lab)
        {
            try
            {
                int flag = 0;
                string ss = "";
                str = "select * from LabCourse ";
                if (!string.IsNullOrWhiteSpace(courseName))
                {
                    flag = 1;
                    ss += " where courseName like '%" + courseName + "%'";
                }
                if (!string.IsNullOrWhiteSpace(classs))
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        ss += " where classs like '%" + classs + "%'";
                    }
                    else
                        ss += " and classs like '%" + classs + "%'";
                }
                if (!string.IsNullOrWhiteSpace(tea))
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        ss += " where teacher like '" + tea + "%'";
                    }
                    else
                        ss += " and teacher like '" + tea + "%'";
                }
                if (!string.IsNullOrWhiteSpace(lab))
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        ss += " where lab = '" + lab + "'";
                    }
                    else
                        ss += " and lab = '" + lab + "'";
                }
                string kk = str + ss + "  order by id desc";
                DataTable dd = sql.FillDt(kk);
                int a = 0;
                a++;
                return dd;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable findLabinfo(string no)
        {
            try
            {
                str = "select * from LabInfo where name='" + no + "'";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }
        DAL_users u = new DAL_users();
        public DataTable findBy(string courseName, string classs, string tea, string lab, string user)
        {
            try
            {
                int flag = 0;
                string ss = "";
                str = "select * from LabCourse ";
                if (!string.IsNullOrWhiteSpace(courseName)&&!courseName.Equals("undefined"))
                {
                    flag = 1;
                    ss += " where courseName like '%" + courseName + "%'";
                }
                if (!string.IsNullOrWhiteSpace(classs)&&!classs.Equals("undefined"))
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        ss += " where classs like '%" + classs + "%'";
                    }
                    else
                        ss += " and classs like '%" + classs + "%'";
                }
                if (!string.IsNullOrWhiteSpace(tea)&&!tea.Equals("undefined"))
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        ss += " where teacher like '" + tea + "%'";
                    }
                    else
                        ss += " and teacher like '" + tea + "%'";
                }
                if (!string.IsNullOrWhiteSpace(lab)&&!lab.Equals("undefined"))
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        ss += " where lab = '" + lab + "'";
                    }
                    else
                        ss += " and lab = '" + lab + "'";
                }

                DataTable dt = u.findUserRole(user);
                int a = 0;
                //当需要周课表时   不需要判断权限
                if (user != "user000" && user != "admin")
                {
                    if (string.IsNullOrWhiteSpace(lab))
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                if (flag == 0)
                                {
                                    flag = 1;
                                    ss += "  where ( lab='" + dt.Rows[i][0].ToString() + "' ";
                                }
                                else
                                    ss += "  and ( lab='" + dt.Rows[i][0].ToString() + "' ";
                            }
                            else
                                ss += "     or lab='" + dt.Rows[i][0].ToString() + "'   ";
                        }
                        string kk = str + ss + " ) order by id desc";
                        return sql.FillDt(kk);
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (lab.Equals(dt.Rows[i][0].ToString()))
                            {
                                a = 1;
                            }
                        }
                    }
                    if (a == 1)
                    {
                        string kk = str + ss + "  order by id desc";
                        DataTable dd = sql.FillDt(kk);
                        return dd;
                    }
                    else
                        return null;
                }
                else
                {
                    string kk = str + ss + "  order by id desc";
                    DataTable dd = sql.FillDt(kk);
                    return dd;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable findCourse(string id)
        {
            try
            {
                str = "select * from  LabCourse where id=" + id + "";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public DataTable findCourseDesign(string courseName, string classs, string tea, string lab)
        {
            try
            {
                int flag = 0;
                string ss = "";
                str = "select * from LabCourse ";
                flag = 1;
                ss += " where courseName like '%课程设计%'";
                if (!string.IsNullOrWhiteSpace(classs)&&!classs.Equals("undefined"))
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        ss += " where classs like '" + classs + "%'";
                    }
                    else
                        ss += " and classs like '" + classs + "%'";
                }
                if (!string.IsNullOrWhiteSpace(tea)&&!tea.Equals("undefined"))
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        ss += " where teacher like '" + tea + "%'";
                    }
                    else
                        ss += " and teacher like '" + tea + "%'";
                }
                if (!string.IsNullOrWhiteSpace(lab)&&!lab.Equals("undefined"))
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        ss += " where lab like '" + lab + "%'";
                    }
                    else
                        ss += " and lab like '" + lab + "%'";
                }
                string kk = str + ss;
                DataTable dd = sql.FillDt(kk);
                return dd;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable findDetail(string id)
        {
            try
            {
                str = "select * from CourseDetail where remark3='" + id + "' order by id ASC";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }
        DAL_common co = new DAL_common();
        public bool delete(CourseDetail c)
        {
            try
            {
                str = DBOperate.sqlDelete(c);
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool deleteAll(LabCourse c)
        {
            try
            {
                str = DBOperate.sqlDelete(c);
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool update(string project, string Is, string id)
        {
            try
            {
                str = "update CourseDetail set project='" + project + "',isComprehensive='" + Is + "' where id=" + id + "";
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataTable getone(string id)
        {
            try
            {
                str = "select * from courseDetail where id=" + id + "";
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
