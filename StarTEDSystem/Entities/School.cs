using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Addtional Namespace
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace StarTEDSystem.Entities
{
    [Table("Schools")]
    public class School
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(10, ErrorMessage = "School code is limited up to 10 characters")]
        public string SchoolCode { get; set; }

        [Required(ErrorMessage = "School Name is required")]
        [StringLength(50, ErrorMessage = "School Name is limited up to 50 characters")]
        public string SchoolName { get; set; }
    }
}
