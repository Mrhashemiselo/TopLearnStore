using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.DTOs.Course;
using TopLearn.DataLayer.Entities.Course;

namespace TopLearn.Core.Services.Interfaces;
public interface ICourseServices
{
    #region Group
    List<CourseGroup> GetAllGroup();
    List<SelectListItem> GetGroupForManageCourse();
    List<SelectListItem> GetSubGroupForManageCourse(int groupId);
    #endregion

    List<SelectListItem> GetTeachers();

    #region Course
    List<ShowCourseForAdminViewModel> GetCoursesForAdmin();
    int AddCourse(Course course, IFormFile image, IFormFile demo);
    #endregion
}
