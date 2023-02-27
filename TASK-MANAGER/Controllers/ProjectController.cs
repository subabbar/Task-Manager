using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TASK_MANAGER.Models;
using TASK_MANAGER.Service;

namespace TASK_MANAGER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        IProjectService _projectService;
        public ProjectController(IProjectService service)
        {
            _projectService = service;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveProject(ProjectRequest projectModel)
        {
            try
            {
                var model = _projectService.SaveProject(projectModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}