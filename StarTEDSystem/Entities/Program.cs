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
    [Table("Programs")]
    public class Program
    {
        private string _diplomaName;

        [Key]
        public int ProgramID { get; set; }

        [Required(ErrorMessage = "Program Name is required")]
        [StringLength(100, ErrorMessage = "Program Name is limited up to 100 characters")]
        public string ProgramName { get; set; }

        [StringLength(100, ErrorMessage = "Diploma Name is limited up to 100 characters")]
        public string DiplomaName
        {
            get
            {
                return _diplomaName;
            }
            set
            {
                _diplomaName = string.IsNullOrEmpty(value) ? null : value;
            }
        }

        public string SchoolCode { get; set; }

        [Required(ErrorMessage = "Tuition is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Tuition must be a value of 0 or greater")]
        public decimal Tuition { get; set; }

        [Required(ErrorMessage = "International Tuition is required")]
        [Range(0, double.MaxValue, ErrorMessage = "International Tuition must be a value of 0 or greater")]
        public decimal InternationalTuition { get; set; }
    }
}
