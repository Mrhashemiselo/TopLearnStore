using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.Course;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Pages.Admin.Courses;

public class IndexModel(ICourseServices courseServices) : PageModel
{
    public List<ShowCourseForAdminViewModel> ListCourses { get; set; }
    public void OnGet()
    {
        ListCourses = courseServices.GetCoursesForAdmin();
    }
}
