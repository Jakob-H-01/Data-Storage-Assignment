using Business.Dtos;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> Create(ProjectRegistrationForm form)
    {
        if (ModelState.IsValid)
        {
            var result = await _projectService.CreateProjectAsync(form);
            if (result)
                return Ok();
        }

        return BadRequest();
    }
}
