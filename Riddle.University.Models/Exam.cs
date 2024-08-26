using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Exam
{
    [Key]
    public int ExamID { get; set; } // Primary Key

    [Required]
    [ForeignKey("Class")]
    public int ClassID { get; set; } // Foreign Key

    [Required]
    public DateTime ExamDate { get; set; }

    [Required]
    [StringLength(50)]
    public string ExamType { get; set; }

    [Required]
    public int TotalMarks { get; set; }

    // Navigation property for Class
    public virtual Class Class { get; set; }

}
