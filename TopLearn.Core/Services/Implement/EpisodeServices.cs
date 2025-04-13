using Microsoft.AspNetCore.Http;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Course;

namespace TopLearn.Core.Services.Implement;

public class EpisodeServices(TopLearnContext context):IEpisodeServices
{
    public int AddEpisode(CourseEpisode episode,IFormFile episodeFile)
    {
        episode.FileName = episodeFile.FileName;
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/courseFiles", episode.FileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            episodeFile.CopyTo(stream);
        }
        context.CourseEpisodes.Add(episode);
        context.SaveChanges();
        return episode.Id;
    }

    public bool CheckExistFile(string fileName)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/courseFiles", fileName);
        return File.Exists(filePath);
    }

    public List<CourseEpisode> GetListEpisodes(int courseId) =>
        context.CourseEpisodes
            .Where(s => s.CourseId == courseId)
            .ToList();

    public CourseEpisode GetEpisodeByID(int episodeId) =>
        context.CourseEpisodes.Find(episodeId);

    public void EditEpisode(CourseEpisode episode, IFormFile episodeFile)
    {
        if (episodeFile != null)
        {
            string deleteFileName = episodeFile.FileName;
            File.Delete(deleteFileName);

            episode.FileName = episodeFile.FileName;
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/courseFiles",episode.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                episodeFile.CopyTo(stream);
            }
        }

        context.CourseEpisodes.Update(episode);
        context.SaveChanges();
    }
}