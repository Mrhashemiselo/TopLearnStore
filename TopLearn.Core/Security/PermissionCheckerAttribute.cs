using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Core.Security;
public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private IPermissionServices _permissionService;
    private int _permissionId = 0;
    public PermissionCheckerAttribute(int permissionId)
    {
        _permissionId = permissionId;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        _permissionService = context.HttpContext.RequestServices.GetService(typeof(IPermissionServices)) as IPermissionServices;
        var username = context.HttpContext.User.Identity.Name;
        if (context.HttpContext.User.Identity.IsAuthenticated)
        {
            if (!_permissionService.CheckPermission(_permissionId, username))
                context.Result = new RedirectResult("/login");

        }
        else
        {
            context.Result = new RedirectResult("/login");
        }
    }
}
