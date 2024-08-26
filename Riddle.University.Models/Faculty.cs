using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Faculty
{
    [Key]
    public int FacultyID { get; set; } // Primary Key

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(20)]
    public string Phone { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    [Required]
    [ForeignKey("Department")]
    public int DepartmentID { get; set; } // Foreign Key

    // Navigation property for Department
    public Department Department { get; set; }

}
