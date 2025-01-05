using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.ViewComponents;

public class CourseGroupComponent(ICourseServices courseServices) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult((IViewComponentResult)View("CourseGroup", courseServices.GetAllGroup()));
    }
}
