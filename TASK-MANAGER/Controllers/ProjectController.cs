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


        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                var projects = _projectService.GetAllProjectsList();
                if (projects == null) return NotFound();
                return Ok(projects);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetProjectById(int id)
        {
            try
            {
                var employees = _projectService.GetProjectDetailsById(id);
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("[action]/projectId")]
        public IActionResult UpdateProject(ProjectRequest projectModel, int projectId)
        {
            try
            {
                var model = _projectService.UpdateProject(projectModel, projectId);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                var model = _projectService.DeleteProject(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/userid")]
        public IActionResult GetPojectByUserid(int userid)
        {
            try
            {
                var employees = _projectService.GetPojectByUserid(userid);
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}