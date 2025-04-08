using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TopLearn.DataLayer.Entities.Users;
using static TopLearn.DataLayer.Enums.CourseEnums;

namespace TopLearn.DataLayer.Entities.Course;
public class Course
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "عنوان دوره")]
    [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
    [MaxLength(400, ErrorMessage = "{0} نباید از {1} کاراکتر بیشتر باشد")]
    public string Title { get; set; }

    [Display(Name = "توضیحات دوره")]
    [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
    public string Description { get; set; }

    [Display(Name = "قیمت دوره")]
    [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
    public int Price { get; set; }

    [Required]
    public CourseStatus CourseStatus { get; set; }

    [Required]
    public CourseLevel CourseLevel { get; set; }

    [MaxLength(500, ErrorMessage = "{0} نباید از {1} کاراکتر بیشتر باشد")]
    public string Tags { get; set; }

    public string? ImageName { get; set; }

    public string? DemoFileName { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    #region Relations
    [Required]
    public int TeacherId { get; set; }
    [ForeignKey("TeacherId")]
    public User? User { get; set; }

    [Required]
    public int GroupId { get; set; }
    [ForeignKey("GroupId")]
    public CourseGroup? CourseGroup { get; set; }

    public int? SubGroupId { get; set; }
    [ForeignKey("SubGroupId")]
    public CourseGroup? SubGroup { get; set; }

    public List<CourseEpisode>? CourseEpisodes { get; set; }
    #endregion
}
