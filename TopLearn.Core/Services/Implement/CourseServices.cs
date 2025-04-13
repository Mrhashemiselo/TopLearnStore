using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs.Course;
using TopLearn.Core.Generator;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Course;

namespace TopLearn.Core.Services.Implement;
public class CourseServices(TopLearnContext context) : ICourseServices
{
    #region Group
    public List<CourseGroup> GetAllGroup() =>
        context.CourseGroups.ToList();

    public List<SelectListItem> GetGroupForManageCourse()
    {
        return context.CourseGroups.Where(w => w.ParentId == null)
            .Select(s => new SelectListItem()
            {
                Text = s.Title,
                Value = s.Id.ToString()
            }).ToList();
    }

    public List<SelectListItem> GetSubGroupForManageCourse(int groupId)
    {
        return context.CourseGroups.Where(w => w.ParentId == groupId)
            .Select(s => new SelectListItem()
            {
                Text = s.Title,
                Value = s.Id.ToString()
            }).ToList();
    }
    #endregion

    public List<SelectListItem> GetTeachers() =>
        context.UserRoles
        .Where(w => w.RoleId == 2)
        .Include(r => r.User)
        .Select(s => new SelectListItem()
        {
            Value = s.UserId.ToString(),
            Text = s.User.Username
        }).ToList();

    #region Course
    public int AddCourse(Course course, IFormFile image, IFormFile demo)
    {
        course.CreateDate = DateTime.Now;
        course.ImageName = "no-photo.jpg";

        if (image != null && image.IsImage())
        {
            course.ImageName = GuidGenerator.GenerateUniqueId() + Path.GetExtension(image.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/image", course.ImageName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            ImageConvertor imgResizer = new();
            string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/thumb", course.ImageName);
            imgResizer.Image_resize(imagePath, thumbPath, 150);
        }
        if (demo != null)
        {
            course.DemoFileName = GuidGenerator.GenerateUniqueId() + Path.GetExtension(demo.FileName);
            string demoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/demoes", course.DemoFileName);
            using (var stream = new FileStream(demoPath, FileMode.Create))
            {
                demo.CopyTo(stream);
            }
        }

        context.Add(course);
        context.SaveChanges();

        return course.Id;
    }

    public List<ShowCourseForAdminViewModel> GetCoursesForAdmin() =>
        context.Courses
               .Select(s => new ShowCourseForAdminViewModel()
               {
                   Id = s.Id,
                   ImageName = s.ImageName,
                   Title = s.Title,
                   EpisodeCount = s.CourseEpisodes.Count
               }).ToList();

    public Course GetCourseById(int courseId) =>
        context.Courses.Find(courseId);

    public void UpdateCourse(Course course, IFormFile imgCourse, IFormFile courseDemo)
    {
        course.UpdateDate = DateTime.Now;

        if (imgCourse != null && imgCourse.IsImage())
        {
            if (course.ImageName != "no-photo.jpg")
            {
                string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/image", course.ImageName);
                if (File.Exists(deleteimagePath))
                {
                    File.Delete(deleteimagePath);
                }

                string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/thumb", course.ImageName);
                if (File.Exists(deletethumbPath))
                {
                    File.Delete(deletethumbPath);
                }
            }
            course.ImageName = GuidGenerator.GenerateUniqueId() + Path.GetExtension(imgCourse.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/image", course.ImageName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                imgCourse.CopyTo(stream);
            }

            ImageConvertor imgResizer = new ImageConvertor();
            string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/thumb", course.ImageName);

            imgResizer.Image_resize(imagePath, thumbPath, 250);
        }

        if (courseDemo != null)
        {
            if (course.DemoFileName != null)
            {
                string deleteDemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/demoes", course.DemoFileName);
                if (File.Exists(deleteDemoPath))
                {
                    File.Delete(deleteDemoPath);
                }
            }
            course.DemoFileName = GuidGenerator.GenerateUniqueId() + Path.GetExtension(courseDemo.FileName);
            string demoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/demoes", course.DemoFileName);
            using (var stream = new FileStream(demoPath, FileMode.Create))
            {
                courseDemo.CopyTo(stream);
            }
        }

        context.Courses.Update(course);
        context.SaveChanges();
    }
    #endregion
}
