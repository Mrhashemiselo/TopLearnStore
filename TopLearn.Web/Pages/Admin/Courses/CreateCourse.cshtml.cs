using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Entities.Course;
using TopLearn.DataLayer.Enums;
using static TopLearn.DataLayer.Enums.CourseEnums;

namespace TopLearn.Web.Pages.Admin.Courses;

public class CreateCourseModel(ICourseServices courseServices) : PageModel
{
    [BindProperty]
    public Course Course { get; set; }

    public SelectList CourseLevels { get; set; }
    public SelectList CourseStatuses { get; set; }

    public void OnGet()
    {
        var courseLevels = Enum.GetValues(typeof(CourseLevel))
                               .Cast<CourseLevel>()
                               .Select(e => new SelectListItem
                               {
                                   Value = e.ToString(),
                                   Text = EnumHelper.GetDescription(e)
                               }).ToList();

        CourseLevels = new SelectList(courseLevels, "Value", "Text");

        var courseStatuses = Enum.GetValues(typeof(CourseStatus))
                               .Cast<CourseStatus>()
                               .Select(e => new SelectListItem
                               {
                                   Value = e.ToString(),
                                   Text = EnumHelper.GetDescription(e)
                               }).ToList();

        CourseStatuses = new SelectList(courseStatuses, "Value", "Text");

        var groups = courseServices.GetGroupForManageCourse();
        ViewData["Groups"] = new SelectList(items: groups, "Value", "Text");
        var subGroups = courseServices.GetSubGroupForManageCourse(int.Parse(groups.First().Value));
        ViewData["SubGroups"] = new SelectList(items: subGroups, "Value", "Text");
        var teachers = courseServices.GetTeachers();
        ViewData["Teachers"] = new SelectList(items: teachers, "Value", "Text");
    }

    public IActionResult OnPost(IFormFile imgCourse, IFormFile demoFile)
    {

        if (!ModelState.IsValid)
        {
            var courseLevels = Enum.GetValues(typeof(CourseLevel))
                                  .Cast<CourseLevel>()
                                  .Select(e => new SelectListItem
                                  {
                                      Value = e.ToString(),
                                      Text = EnumHelper.GetDescription(e)
                                  }).ToList();

            CourseLevels = new SelectList(courseLevels, "Value", "Text");

            var courseStatuses = Enum.GetValues(typeof(CourseStatus))
                                   .Cast<CourseStatus>()
                                   .Select(e => new SelectListItem
                                   {
                                       Value = e.ToString(),
                                       Text = EnumHelper.GetDescription(e)
                                   }).ToList();

            CourseStatuses = new SelectList(courseStatuses, "Value", "Text");

            var groups = courseServices.GetGroupForManageCourse();
            ViewData["Groups"] = new SelectList(items: groups, "Value", "Text");
            var subGroups = courseServices.GetSubGroupForManageCourse(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(items: subGroups, "Value", "Text");
            var teachers = courseServices.GetTeachers();
            ViewData["Teachers"] = new SelectList(items: teachers, "Value", "Text");

            return Page();
        }
        courseServices.AddCourse(Course, imgCourse, demoFile);

        return RedirectToPage("Index");
    }
}
