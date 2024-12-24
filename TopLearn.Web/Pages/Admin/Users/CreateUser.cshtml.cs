﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.AdminPanel;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Pages.Admin.Users;

public class CreateUserModel(IAdminPanel adminPanel,
    IPermissionService permissionService) : PageModel
{
    [BindProperty]
    public CreateUserViewModel CreateUserViewModel { get; set; }

    public void OnGet()
    {
        ViewData["Roles"] = permissionService.GetRoles();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            ViewData["Roles"] = permissionService.GetRoles();
            return Page();
        }

        int userId = adminPanel.AddUserFromAdmin(CreateUserViewModel);
        if (userId == -1)
        {
            ModelState.AddModelError("", "لطفا فقط تصویر بارگزاری کنید");
            ViewData["Roles"] = permissionService.GetRoles();
            return Page();
        }
        permissionService.AddRolesToUser(CreateUserViewModel.SelectedRoles, userId);
        return Redirect("/Admin/Users");
    }
}
