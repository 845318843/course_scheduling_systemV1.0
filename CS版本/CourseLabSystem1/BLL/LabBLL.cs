using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{

    public class LabBLL
    {
        LabDAL labdal = new LabDAL();       
        public static DataTable update()
        {
            return LabDAL.update();
        }
        public object Stable(object sql)
        {
            throw new NotImplementedException();
        }
        public bool add(string building,string name,string classroom_id,string people,string manager,string descride)
        {                      
            return labdal.add(building,name,classroom_id,people,manager,descride);
        }
        public bool modify(string build, string name, string classroom_id ,string people, string manager, string descride)
        {
            return labdal.modify(build, name,classroom_id, people, manager, descride);
        }
        public bool delete(string classroom_id)
        {
            return labdal.delete(classroom_id);
        }
    }
}
