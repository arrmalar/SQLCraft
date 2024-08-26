using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

public class Course
{
    [Key]
    public int CourseID { get; set; } // Primary Key

    [Required]
    [StringLength(200)]
    public string CourseName { get; set; }

    [Required]
    [StringLength(20)]
    public string CourseCode { get; set; }

    [Required]
    public int Credits { get; set; }

    [Required]
    [ForeignKey("Department")]
    public int DepartmentID { get; set; } // Foreign Key

    // Navigation property for Department
    public virtual Department Department { get; set; }
}
