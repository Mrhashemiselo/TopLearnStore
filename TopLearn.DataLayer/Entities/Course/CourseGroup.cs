using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopLearn.DataLayer.Entities.Course;
public class CourseGroup
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "عنوان گروه")]
    [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
    [MaxLength(150, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
    public string Title { get; set; }

    [Display(Name = "حذف شده")]
    public bool IsDelete { get; set; }

    [Display(Name = "گروه اصلی")]
    public int? ParentId { get; set; }

    #region Relations

    [ForeignKey("ParentId")]
    public List<CourseGroup> CourseGroups { get; set; }

    [InverseProperty("CourseGroup")]
    public List<Course> Courses { get; set; }

    [InverseProperty("SubGroup")]
    public List<Course> SubCourses { get; set; }

    #endregion
}
