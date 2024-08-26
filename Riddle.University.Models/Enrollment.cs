using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Enrollment
{
    [Key]
    public int EnrollmentID { get; set; } // Primary Key

    [Required]
    [ForeignKey("Student")]
    public int StudentID { get; set; } // Foreign Key

    [Required]
    [ForeignKey("Course")]
    public int CourseID { get; set; } // Foreign Key

    [Required]
    public DateTime EnrollmentDate { get; set; }

    public string Grade { get; set; } // Nullable

    // Navigation property for Student
    public virtual Student Student { get; set; }

    // Navigation property for Course
    public virtual Course Course { get; set; }
}
