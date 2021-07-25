using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Addtional Namespace
using System.ComponentModel;
using StarTEDSystem.DAL;
using StarTEDSystem.Entities;
#endregion

namespace StarTEDSystem.BLL
{
    [DataObject(true)]
    public class SchoolController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<School> ListAllSchools()
        {
            using (StartTEDSystemContext context = new StartTEDSystemContext())
            {
                return context.Schools.ToList();
            }
        }


    }
}
