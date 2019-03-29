using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DAL
{
    public class AddDAL
    {
        SqlDB db = new SqlDB();
        public bool AddClass(Basic_Information basic)
        {
            string sql = "insert into Basic_Information(Garde,ClassId,Class,Department) values(" +
                  basic.Garde + ",'" + Convert.ToInt32(basic.ClassId) + "','" + basic.Class + "','"+basic.Department+"')";
            return db.ExecSql(sql);
        }
        public bool UpdateClass(string oldGarde, int oldClassId, string oldClass, string oldDepartment, Basic_Information basic)
        {
            try
            {
                string sql = "update Basic_Information set Garde='" + basic.Garde + "',ClassId='" + basic.ClassId + "',Class='" + basic.Class + "',Department='" + basic.Department + "' where Garde='" + oldGarde + "' and ClassId='" + oldClassId + "' and Class='" + oldClass + "' and Department='" + oldDepartment + "'";
                return db.ExecSql(sql);
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteClass(int ClassID)
        {
            try
            {
                string sql = "delete from Basic_Information where ClassId ='" + ClassID + "'";
                return db.ExecSql(sql);
            }
            catch
            {
                return false;
            }
        }
        public bool AddLesson(AddCourse addCourse)
        {
            string sql = "insert into AddCourse(Course_Id,Course,Department) values('" +
                  Convert.ToInt32(addCourse.Course_Id) + "','" +addCourse.Course + "','" + addCourse.Department + "')";
            return db.ExecSql(sql);
        }
        public bool UpdateLesson(int oldCourse_Id, string oldCourse, string oldDepartment, AddCourse add)
        {
            try
            {
                string sql = "update AddCourse set Course_Id='" + add.Course_Id + "',Course='" + add.Course + "',Department='" + add.Department + "' where Course_Id='" + oldCourse_Id + "'AND Course='" + oldCourse + "'AND Department='" + oldDepartment + "'";
                return db.ExecSql(sql);
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteLesson(int Course_Id)
        {
            try
            {
                string sql = "delete from AddCourse where Course_Id='" + Course_Id + "'";
                return db.ExecSql(sql);
            }
            catch
            {
                return false;
            }
        }
        DataTable dt = new DataTable();
        public DataTable upData()
        {
            string sql = "select distinct Class as 班级, ClassId as 班级代号, Garde as 年级,Department as 院系 from Basic_Information order by Garde ,Department ,ClassId";
            dt = db.FillDt(sql);
            return dt;
        }
        public DataTable upDataL()
        {
            string sql = "select distinct Course as 课程 ,Course_Id as 课程代号,Department as 系别 from AddCourse order by Department,Course_Id";
            dt = db.FillDt(sql);
            return dt;
        }
    }
}
