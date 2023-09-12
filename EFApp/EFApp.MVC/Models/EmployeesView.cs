using System.ComponentModel.DataAnnotations;

namespace EFApp.MVC.Models
{
    public class EmployeesView
    {
        public int EmployeeID { get; set; }
        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(24)]
        public string HomePhone { get; set; }
    }
}