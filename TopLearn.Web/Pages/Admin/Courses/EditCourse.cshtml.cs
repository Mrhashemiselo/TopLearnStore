using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Entities.Course;
using TopLearn.DataLayer.Enums;
using static TopLearn.DataLayer.Enums.CourseEnums;

namespace TopLearn.Web.Pages.Admin.Courses;

public class EditCourseModel(ICourseServices courseService) : PageModel
{
    [BindProperty]
    public Course Course { get; set; }

    public SelectList CourseLevels { get; set; }
    public SelectList CourseStatuses { get; set; }

    public void OnGet(int id)
    {
        Course = courseService.GetCourseById(id);

        var groups = courseService.GetGroupForManageCourse();
        ViewData["Groups"] = new SelectList(groups, "Value", "Text", Course.GroupId);

        var subGroups = courseService.GetSubGroupForManageCourse(int.Parse(groups.First().Value));
        ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text", Course.SubGroupId ?? 0);

        var teachers = courseService.GetTeachers();
        ViewData["Teachers"] = new SelectList(teachers, "Value", "Text", Course.TeacherId);

        var courseLevels = Enum.GetValues(typeof(CourseLevel))
                              .Cast<CourseLevel>()
                              .Select(e => new SelectListItem
                              {
                                  Value = e.ToString(),
                                  Text = EnumHelper.GetDescription(e)
                              }).ToList();

        CourseLevels = new SelectList(courseLevels, "Value", "Text", Course.CourseLevel);

        var courseStatuses = Enum.GetValues(typeof(CourseStatus))
                               .Cast<CourseStatus>()
                               .Select(e => new SelectListItem
                               {
                                   Value = e.ToString(),
                                   Text = EnumHelper.GetDescription(e)
                               }).ToList();

        CourseStatuses = new SelectList(courseStatuses, "Value", "Text", Course.CourseStatus);

    }

    public IActionResult OnPost(IFormFile? imgCourseUp, IFormFile? demoUp)
    {
        if (!ModelState.IsValid)
        {
            var groups = courseService.GetGroupForManageCourse();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text", Course.GroupId);

            var subGroups = courseService.GetSubGroupForManageCourse(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text", Course.SubGroupId ?? 0);

            var teachers = courseService.GetTeachers();
            ViewData["Teachers"] = new SelectList(teachers, "Value", "Text", Course.TeacherId);

            var courseLevels = Enum.GetValues(typeof(CourseLevel))
                                  .Cast<CourseLevel>()
                                  .Select(e => new SelectListItem
                                  {
                                      Value = e.ToString(),
                                      Text = EnumHelper.GetDescription(e)
                                  }).ToList();

            CourseLevels = new SelectList(courseLevels, "Value", "Text", Course.CourseLevel);

            var courseStatuses = Enum.GetValues(typeof(CourseStatus))
                                   .Cast<CourseStatus>()
                                   .Select(e => new SelectListItem
                                   {
                                       Value = e.ToString(),
                                       Text = EnumHelper.GetDescription(e)
                                   }).ToList();

            CourseStatuses = new SelectList(courseStatuses, "Value", "Text", Course.CourseStatus);
        }

        courseService.UpdateCourse(Course, imgCourseUp, demoUp);

        return RedirectToPage("Index");
    }
}
