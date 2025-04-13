using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Entities.Course;

namespace TopLearn.Web.Pages.Admin.Episode;

public class CreateEpisodeModel(IEpisodeServices episodeServices) : PageModel
{
    [BindProperty]
    public CourseEpisode CourseEpisode { get; set; }

    public void OnGet(int id)
    {
        CourseEpisode = new CourseEpisode();
        CourseEpisode.CourseId = id;
    }

    public IActionResult OnPost(IFormFile fileEpisode)
    {
        if (!ModelState.IsValid || fileEpisode == null)
            return Page();

        if (episodeServices.CheckExistFile(fileEpisode.FileName))
        {
            ViewData["IsExistFile"] = true;
            return Page();
        }

        episodeServices.AddEpisode(CourseEpisode, fileEpisode);
        return Redirect($"/admin/episode/index/{CourseEpisode.CourseId}");
    }
}
