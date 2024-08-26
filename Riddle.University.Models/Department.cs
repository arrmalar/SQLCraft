using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Department
{
    [Key]
    public int DepartmentID { get; set; } // Primary Key

    [Required]
    [StringLength(200)]
    public string DepartmentName { get; set; }
}
