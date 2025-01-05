using TopLearn.DataLayer.Entities.Course;

namespace TopLearn.Core.Services.Interfaces;
public interface ICourseServices
{
    #region Group

    List<CourseGroup> GetAllGroup();

    #endregion
}
