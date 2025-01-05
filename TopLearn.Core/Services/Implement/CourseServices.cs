using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Course;

namespace TopLearn.Core.Services.Implement;
public class CourseServices(TopLearnContext context) : ICourseServices
{
    public List<CourseGroup> GetAllGroup() =>
        context.CourseGroups.ToList();
}
