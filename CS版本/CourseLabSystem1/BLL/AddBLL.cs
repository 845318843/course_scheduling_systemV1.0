using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddBLL
    {
        AddDAL addDal = new AddDAL();
        public bool AddClass(Basic_Information basic)
        {
            return addDal.AddClass(basic);
        }
        public bool AddLesson(AddCourse addCourse)
        {
            return addDal.AddLesson(addCourse);
        }
        public bool UpdateClass(string oldGarde,int oldClassId,string oldClass,string oldDepartment,Basic_Information basic)
        {
            return addDal.UpdateClass(oldGarde, oldClassId, oldClass, oldDepartment,basic);
        }
        public bool DeleteClass(int classID)
        {
            return addDal.DeleteClass(classID);
        }
        public bool UpdateLesson(int oldCourse_Id, string oldCourse, string oldDepartment, AddCourse add)
        {
            return addDal.UpdateLesson(oldCourse_Id, oldCourse, oldDepartment, add);
        }
        public bool DeleteLesson(int course_id)
        {
            return addDal.DeleteLesson(course_id);
        }

        public DataTable upData()
        {
            return addDal.upData();
        }
        public DataTable upDataL()
        {
            return addDal.upDataL();
        }
    }
}
