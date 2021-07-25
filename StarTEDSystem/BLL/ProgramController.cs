using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Addtional Namespace
using System.ComponentModel;
using StarTEDSystem.DAL;
using StarTEDSystem.Entities;
using System.Data.SqlClient;
using System.Data.Entity;
#endregion

namespace StarTEDSystem.BLL
{
    [DataObject(true)]
    public class ProgramController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Program> ListAllPrograms()
        {
            using (StartTEDSystemContext context = new StartTEDSystemContext())
            {
                return context.Programs.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Program> Programs_FindByProgramName(string programName)
        {
            using (StartTEDSystemContext context = new StartTEDSystemContext())
            {
                IEnumerable<Program> results = context.Database.SqlQuery<Program>("Programs_FindByProgramName @ProgramName", new SqlParameter("ProgramName", programName));

                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Program> Programs_FindBySchool(string schoolCode)
        {
            using (StartTEDSystemContext context = new StartTEDSystemContext())
            {
                IEnumerable<Program> results = context.Database.SqlQuery<Program>("Programs_FindBySchool @SchoolCode", new SqlParameter("SchoolCode", schoolCode));

                return results.ToList();
            }
        }

        public int Program_Add(Program item)
        {
            using (StartTEDSystemContext context = new StartTEDSystemContext())
            {
                Program addedItem = context.Programs.Add(item);

                context.SaveChanges();

                return addedItem.ProgramID;
            }
        }

        public int Program_Update(Program item)
        {
            using (StartTEDSystemContext context = new StartTEDSystemContext())
            {

                context.Entry(item).State = EntityState.Modified;

                return context.SaveChanges();

            }
        }

        public int Program_Delete(int programID)
        {
            using (StartTEDSystemContext context = new StartTEDSystemContext())
            {
                context.Programs.Remove(context.Programs.Find(programID));

                return context.SaveChanges();
            }
        }
    }
}
