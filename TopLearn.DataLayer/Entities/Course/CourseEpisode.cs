using System.ComponentModel.DataAnnotations;

namespace TopLearn.DataLayer.Entities.Course;
public class CourseEpisode
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "عنوان بخش")]
    [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
    [MaxLength(400, ErrorMessage = "{0} نباید از {1} کاراکتربیشتر باشد")]
    public string Title { get; set; }

    [Display(Name = "مدت زمان")]
    [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
    public TimeSpan Time { get; set; }

    [Display(Name = "فایل")]
    public string FileName { get; set; }

    [Display(Name = "رایگان")]
    public bool IsFree { get; set; }

    #region
    public int CourseId { get; set; }
    public Course Course { get; set; }
    #endregion
}
