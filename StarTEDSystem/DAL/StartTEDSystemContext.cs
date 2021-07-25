using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Addtional Namespace
using System.Data.Entity;
using StarTEDSystem.Entities;
#endregion
namespace StarTEDSystem.DAL
{
    internal class StartTEDSystemContext : DbContext
    {
        public StartTEDSystemContext() : base("StarTEDDb")
        {

        }

        public DbSet<Program> Programs { get; set; }

        public DbSet<School> Schools { get; set; }
    }
}
