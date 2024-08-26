using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Class
{
    [Key]
    public int ClassID { get; set; } // Primary Key

    [Required]
    [ForeignKey("Course")]
    public int CourseID { get; set; } // Foreign Key

    [Required]
    [ForeignKey("Faculty")]
    public int FacultyID { get; set; } // Foreign Key

    [Required]
    [StringLength(20)]
    public string Semester { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    [StringLength(50)]
    public string ClassRoom { get; set; }

    [Required]
    [StringLength(100)]
    public string Schedule { get; set; }

    // Navigation property for Course
    public Course Course { get; set; }

    // Navigation property for Faculty
    public Faculty Faculty { get; set; }
}
