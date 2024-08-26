using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ExamResult
{
    [Key]
    public int ResultID { get; set; } // Primary Key

    [Required]
    [ForeignKey("Exam")]
    public int ExamID { get; set; } // Foreign Key

    [Required]
    [ForeignKey("Student")]
    public int StudentID { get; set; } // Foreign Key

    [Required]
    public int MarksObtained { get; set; }

    [Required]
    [StringLength(2)]
    public string Grade { get; set; }

    // Navigation property for Exam
    public virtual Exam Exam { get; set; }

    // Navigation property for Student
    public virtual Student Student { get; set; }
}
