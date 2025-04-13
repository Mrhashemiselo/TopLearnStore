using Microsoft.AspNetCore.Http;
using TopLearn.DataLayer.Entities.Course;

namespace TopLearn.Core.Services.Interfaces;

public interface IEpisodeServices
{
    int AddEpisode(CourseEpisode episode, IFormFile episodeFile);
    bool CheckExistFile(string fileName);
    List<CourseEpisode> GetListEpisodes(int courseId);
    CourseEpisode GetEpisodeByID(int episodeId);
    void EditEpisode(CourseEpisode episode, IFormFile episodeFile);
}