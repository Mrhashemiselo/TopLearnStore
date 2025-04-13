using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Entities.Course;

namespace TopLearn.Web.Pages.Admin.Episode;

public class EditEpisodeModel(IEpisodeServices episodeServices) : PageModel
{
    [BindProperty]
    public CourseEpisode CourseEpisode { get; set; }

    public void OnGet(int id)
    {
        CourseEpisode = episodeServices.GetEpisodeByID(id);
    }

    public IActionResult OnPost(IFormFile? fileEpisode)
    {
        if (!ModelState.IsValid)
            return Page();

        if (fileEpisode != null)
        {
            if (episodeServices.CheckExistFile(fileEpisode.FileName))
            {
                ViewData["IsExistFile"] = true;
                return Page();
            }
        }

        episodeServices.EditEpisode(CourseEpisode, fileEpisode);
        return Redirect($"/admin/episode/index/{CourseEpisode.CourseId}");
    }
}