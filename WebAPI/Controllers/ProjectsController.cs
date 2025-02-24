using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [EnableCors("MyPolicy")]
    [HttpPost]
    public async Task<IActionResult> Create(ProjectRegistrationForm form)
    {
        if (ModelState.IsValid)
        {
            var result = await _projectService.CreateProjectAsync(form);
            if (result)
                return Ok("Project created successfully.");
        }

        return BadRequest();
    }

    [EnableCors("MyPolicy")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllProjectsAsync();

        if (projects != null && projects.Any())
            return Ok(projects);

        return NotFound();
    }

    [EnableCors("MyPolicy")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var project = await _projectService.GetProjectAsync(x => x.Id == id);

        if (project != null)
            return Ok(project);

        return NotFound();
    }

    [EnableCors("MyPolicy")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var project = await _projectService.GetProjectAsync(x => x.Id == id);
        if (project == null)
            return NotFound();

        await _projectService.DeleteProject(project);
        project = await _projectService.GetProjectAsync(x => x.Id == id);
        if (project == null)
            return NoContent();

        return Problem();
    }

    [EnableCors("MyPolicy")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProjectUpdateForm form)
    {
        if (id != form.Id || form == null)
            return BadRequest();

        if(!await _projectService.ProjectExistsAsync(x => x.Id == id))
            return NotFound();

        await _projectService.UpdateProject(form);
        return NoContent();
    }
}
